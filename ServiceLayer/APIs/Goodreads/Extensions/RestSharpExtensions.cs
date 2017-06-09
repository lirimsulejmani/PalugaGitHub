using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Goodreads.Exceptions;
using Goodreads.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Extensions;

namespace Goodreads.Extensions
{
    internal static class RestSharpExtensions
    {
        public static void ApiTest(RestClient client)
        {
           // var client = new RestClient("url");
            var request = new RestRequest(Method.GET);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            var jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);

        }

        public static Task<IRestResponse> GetResponseContentAsync(IRestClient theClient, IRestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

        public static async Task<T> ExecuteTask<T>(this IRestClient client, IRestRequest request)
           where T : ApiResponse, new()
        {
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            return response.ThrowIfException().Deserialize<T>();
        }


        public static async Task<T> ExecuteTask<T>(this IRestClient client, IRestRequest request, Action<IRestResponse> callback)
            where T : ApiResponse, new()
        {


            IRestResponse response;
            try
            {
                //HttpWebRequest requestA = WebRequest.Create("url");
                // HttpWebResponse responseA = (HttpWebResponse)request.GetResponse();

                var webRequest = client.ExecuteAsync(request, callback).WebRequest;
                var result = new RestRequestAsyncHandle(webRequest);
                if (!webRequest.HaveResponse)
                {
                    var webResponse = await webRequest.GetResponseAsync().ConfigureAwait(false);
                    response = (IRestResponse)webResponse;/* Construct an IRestResponse using webResponse */
                }
                else
                {
                    var webResponse = await webRequest.GetRequestStreamAsync().ConfigureAwait(false);
                    response = (IRestResponse)webResponse;
                }

            }
            catch (Exception ex)
            {
                response = (IRestResponse)ex.InnerException;/* Construct an IRestResponse with error information */
            }
            callback(response);

            return response.ThrowIfException().Deserialize<T>();
        }




        public static async Task<IRestResponse> ExecuteTaskRaw(this IRestClient client, IRestRequest request)
        {
            var ret = await client.ExecuteTaskRaw(request).ConfigureAwait(false);
            request.OnBeforeDeserialization(ret);
            return ret.ThrowIfException();
        }

        public static T Deserialize<T>(this IRestResponse response)
            where T : ApiResponse, new()
        {
            response.Request.OnBeforeDeserialization(response);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            try
            {
                var document = XDocument.Parse(response.Content);
                if (document == null ||
                    document.Root == null ||
                    document.Root.Name == "error")
                {
                    return null;
                }
                else
                {
                    var root = document.Element("GoodreadsResponse");
                    var contentRoot = root.Element(response.Request.RootElement);
                    var responseObject = new T();
                    responseObject.Parse(contentRoot);
                    return responseObject;
                }
            }
            catch (XmlException)
            {
                return null;
            }
        }

        private static IRestResponse ThrowIfException(this IRestResponse response)
        {
            // Something seriously wrong happened
            if (response.ErrorException != null)
            {
                throw new ApiException(
                    "There was an an exception thrown during the request.",
                    response.ErrorException);
            }

            // The HTTP request didn't even finish
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw response.ResponseStatus.ToWebException();
            }

            // Usually we return null for 404s instead of throwing an exception
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return response;
            }

            // Try and find an error from the Goodreads response
            string error = null;
            try
            {
                var document = XDocument.Parse(response.Content);

                // Goodreads returns several different types of errors...
                if (document != null && document.Root != null)
                {
                    if (document.Root.Name == "error")
                    {
                        // One is a single XML error node
                        var element = document.Element("error");
                        if (element != null)
                        {
                            error = element.Value;
                        }
                    }
                    else if (document.Root.Name == "errors")
                    {
                        // Another one is a list of XML error nodes
                        var element = document.Element("errors");
                        var children = element.Descendants("error");
                        if (children != null && children.Count() > 0)
                        {
                            error = string.Join(Environment.NewLine, children.Select(x => x.Value));
                        }
                    }
                    else if (document.Root.Name == "hash")
                    {
                        // And another one is in a "hash" XML object
                        var element = document.Element("hash");
                        if (element != null)
                        {
                            var status = element.ElementAsString("status");
                            var message = element.ElementAsString("error");
                            error = string.Join(" ", status, message);
                        }
                    }
                    else
                    {
                        // Yet another one is an entire XML structure with multiple messages...
                        var element = document.Element("GoodreadsResponse/error");
                        if (element != null)
                        {
                            // There are three total error messages
                            var genericMessage = element.ElementAsString("generic");
                            var detailMessage = element.ElementAsString("detail");
                            var friendlyMessage = element.ElementAsString("friendly");

                            // Use the best message that exists...
                            error = friendlyMessage ?? detailMessage ?? genericMessage;
                        }
                    }
                }
            }
            catch (XmlException)
            {
                // We don't really care if any exception was thrown above
                // we're just trying to find an error message after all...
            }

            // Show an error for 500s even if we didn't find a message
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                var hasError = !string.IsNullOrWhiteSpace(error);
                var message = string.Format(
                    CultureInfo.CurrentCulture,
                    "Received a {0} from Goodreads{1}",
                    (int)response.StatusCode,
                    hasError ? ":" + Environment.NewLine + error : ".");

                throw new ApiException(response.StatusCode, message);
            }

            // If we found any error at all above, throw an exception
            if (!string.IsNullOrWhiteSpace(error))
            {
                throw new ApiException(response.StatusCode, "Received an error from Goodreads: " + error);
            }

            return response;
        }
    }
}
