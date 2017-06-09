using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HtmlAgilityPack;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ServiceLayer.APIs.ComparePrices
{
    public class BookFinderPrices
    {
        public string _Destination = "sz";
        public string _Currency = "CHF";
        public string _BookFinderURL = "https://www.bookfinder.com/search/?isbn={0}&new_used=*&destination={1}&currency={2}&mode=basic&st=sr&ac=qr";
        public static HtmlDocument _HtmlDocument;

        public BookFinderPrices(string isbn)
        {
            try
            {
                var getPricesUrl = String.Format(_BookFinderURL, isbn, _Destination, _Currency);
                GetHtmlContent(getPricesUrl).Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
        }

        public async Task<List<BookComparePrice>> GetComparePrices()
        {
            var BookPricesResult = new List<BookComparePrice>();
            var document = _HtmlDocument;
            var arePricesShown = document.DocumentNode.SelectSingleNode("//div[@itemprop='offers']");
            if (arePricesShown != null)
            {
                var tables = document.DocumentNode.SelectNodes("//table[@class='results-table-Logo']");
                foreach (var table in tables)
                {
                    var bookCondition = "";
                    if (table.PreviousSibling.PreviousSibling != null)
                    {
                        bookCondition = table.PreviousSibling.PreviousSibling.InnerText.Split(' ').First();
                    }
                    var rows = table.SelectNodes(".//tr");
                    foreach (var element in rows)
                    {
                        if (element.Attributes["class"] != null)
                        {
                            //check if row is not header 
                            if (element.Attributes["class"].Value != "results-table-header-row")
                            {
                                var bookFinderPrice = new BookComparePrice();
                                bookFinderPrice.Condition = bookCondition;
                                var data = element.SelectNodes("td");
                                foreach (var item in data)
                                {
                                    //take provider by checking if child element of ts contains div
                                    var div = item.SelectNodes(".//div");
                                    var a = item.SelectNodes(".//a");
                                    var img = item.SelectNodes(".//img");
                                    //take provider
                                    if (a != null && img != null && div == null)
                                    {
                                        // take provider url
                                        var attributeUrl = a.First().Attributes["href"];
                                        if (attributeUrl != null)
                                        {
                                            //var providerUrl = GetText(attributeUrl.Value.Trim());
                                            bookFinderPrice.PrivderUrl = attributeUrl.Value;
                                        }

                                        // take provider name
                                        if (img != null)
                                        {
                                            var attributeTitle = img.First().Attributes["title"];
                                            if (attributeTitle != null)
                                            {
                                                string providerName = attributeTitle.Value;
                                                bookFinderPrice.ProviderName = providerName;
                                            }
                                        }
                                    }
                                    else if(a != null && div != null && img == null)  //take price
                                    {
                                        bookFinderPrice.Price = a.First().InnerText.Trim();
                                    }
                                }

                                BookPricesResult.Add(bookFinderPrice);
                            }
                        }
                    }
                }
            }
            // var resultPrices = BookPricesResult.Select(t => t.Price).ToArray();
            // int parsed = 0;
            //var prices = resultPrices.Where(x => int.TryParse(x, out parsed)).Select(x => parsed);
            //var result = from element in BookPricesResult
            //             group element by new { element.Price, element.ProviderName, element.Condition }
            //   into groups
            //             select groups.OrderBy(p => new { p.Price, p.ProviderName }).First();
            var result = new List<BookComparePrice>();
            foreach (var item in BookPricesResult)
            {
                if (result.Find(t=>t.ProviderName == item.ProviderName && t.Condition == item.Condition) == null)
                {
                    result.Add(item);
                }
            }
          

            return await result.ToAsyncEnumerable().ToList();
        }

        private string GetText(string val)
        {
            Match match = Regex.Match(val, @"'([^']*)");
            if (match.Success)
            {
                string yourValue = match.Groups[1].Value;
                return yourValue;
            }
            return "";
        }

        public async Task GetHtmlContent(string url)
        {
            //client.Headers["User-Agent"] = "MOZILLA/5.0 (WINDOWS NT 6.1; WOW64) APPLEWEBKIT/537.1 (KHTML, LIKE GECKO) CHROME/21.0.1180.75 SAFARI/537.1";

            // instance or static variable
            HttpClient client = new HttpClient();

            // get answer in non-blocking way
            using (var response = await client.GetAsync(url))
            {
                using (var content = response.Content)
                {
                    // read answer in non-blocking way
                    var result = content.ReadAsStringAsync().Result;
                  
                    var document = new HtmlDocument();
                    document.LoadHtml(result);
                    _HtmlDocument = document;
                    //var nodes = document.DocumentNode.SelectNodes("Your nodes");
                    //Some work with page....
                }
            }
        }
    }

    public class BookComparePrice
    {
        public string ProviderName { get; set; }
        public string PrivderUrl { get; set; }
        public string Price { get; set; }
        public string Condition { get; set; }
    }


}
