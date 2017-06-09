using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Http;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace ServiceLayer.APIs.Google
{
    public class GoogleBookSearch
    {
        private BooksService service;

        public GoogleBookSearch(string applicationName, string apiKey)
        {
            try
            {
                Run().Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
        }


        private async Task Run()
        {
            UserCredential credential;
            var path = Directory.GetCurrentDirectory() + @"\wwwroot\client_secrets.json";

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                dsAuthorizationBroker.RedirectUri = "http://localhost:54213/search";
                credential = await dsAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets,
                    new[] { BooksService.Scope.Books },
                    "sulejmanilirim@gmail.com", CancellationToken.None, new FileDataStore("c://tmep")
                    );
                //credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                //    GoogleClientSecrets.Load(stream).Secrets,
                //    new[] { BooksService.Scope.Books },
                //    "sulejmanilirim@gmail.com", CancellationToken.None, new FileDataStore("c://tmep")
                //    );
            }

            // Create the service.
            var service = new BooksService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Paluga",
                
            });
            // Revoke the credential.
            Console.WriteLine("\n!!!REVOKE ACCESS TOKEN!!!\n");
            await credential.RevokeTokenAsync(CancellationToken.None);

            // Reauthorize the user. A browser should be opened, and the user should enter his or her credential again.
            await GoogleWebAuthorizationBroker.ReauthorizeAsync(credential, CancellationToken.None);

        }

        public async Task<IList<Volume>> Search(string search)
        {
            using (service)
            {
                var result = await service.Volumes.List(search).ExecuteAsync();
                if (result != null && result.Items != null)
                {
                    return result.Items;
                }
                return null;
            }
        }

        public  async Task<Volume> SearchISBN(string isbn)
        {
            using (service)
            {

                var request =  service.Volumes.List(isbn);
                //request.UserIp = "192.168.0.100";  
                var result = await request.ExecuteAsync();
                if (result != null && result.Items != null)
                {
                    var item = result.Items.FirstOrDefault();
                    return item;
                }
                return null;
            }
        }
    }

    public class GBookRequest : IConfigurableHttpClientInitializer
    {
        public void Initialize(ConfigurableHttpClient httpClient)
        {
           
            httpClient.DefaultRequestHeaders.Add("country", "AL");
        }
    }
}
