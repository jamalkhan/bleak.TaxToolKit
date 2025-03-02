using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.IO;
using bleak.TaxToolKit.ConsoleApp.Configuration;
using bleak.Api.Rest;

namespace bleak.TaxToolKit.ConsoleApp
{
    public static class Program
    {
        static JsonSerializer _serializer = new JsonSerializer();
        static RestManager _restManager = new RestManager(_serializer, _serializer);

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Replace these with your actual credentials
            
            // API endpoint
            //string endpoint = "api.coinbase.com/api/v3/brokerage/products";
            string endpoint = "/api/v3/brokerage/orders/historical/batch";
            string baseUrl = "https://api.coinbase.com";
            string url = $"{baseUrl}{endpoint}";
            
            
            var response = _restManager.ExecuteRestMethod<string, string>(
                uri: new Uri(url), 
                verb: HttpVerbs.GET
            );

            Console.WriteLine(response);
            Console.WriteLine(response.Results);
            Console.ReadLine();
        }


  
    }
}

