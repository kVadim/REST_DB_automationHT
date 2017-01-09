using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

// https://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client
namespace RESTautomationHT
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }

    class RestClient
    {
        static HttpClient client = new HttpClient();
        

            static void Main()
        {
            RunAsync().Wait();
        }       

        static async Task RunAsync()
        {
            // New code:
            client.BaseAddress = new Uri("http://172.30.23.9:8080/ServletToDoList/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;

            Console.WriteLine("____ POST check ___");
            Product pr = new Product();
            pr.Id = "1";
            pr.Name = "first";
            pr.Price = 100;
            pr.Category = "Other";
            response = await client.PostAsJsonAsync("some path", pr);
            if (response.IsSuccessStatusCode)
            {
                Uri productURI=  response.Headers.Location;
                Console.WriteLine("____ Uhhu !! ___" + productURI);

                #region  REST Client C# Console Part 2 (GET,POST,PUT,DELETE)
                pr.Name = "new name";
                response = await client.PutAsJsonAsync("some path", pr);

                response = await client.DeleteAsync("some path");

                #endregion
            }

            Console.WriteLine("____ PUT check ___");

            
            Console.WriteLine("____ GET check ___");
            response = await client.GetAsync("some path");
            if (response.IsSuccessStatusCode)
            {
                Product product = await response.Content.ReadAsAsync<Product>();            
            Console.WriteLine("____ Yeah !! ___");
            Console.WriteLine("{0}\t(1)\t(2)\t(3)\t(4)", product.Id, product.Name, product.Price, product.Category);
            }


            Console.WriteLine("____ GET all check ___");
            response = await client.GetAsync("some path");
            if (response.IsSuccessStatusCode)
            {
                List<Product> products = await response.Content.ReadAsAsync<List<Product>>();
                Console.WriteLine("____ Yeah aLl !! ___");
                for (int i = 0; i < products.Count; i++)
                {
                    Console.WriteLine("{0}\t(1)\t(2)\t(3)\t(4)", products[i].Id, products[i].Name, products[i].Price, products[i].Category);
                }
            }
        }

    }
    
}
