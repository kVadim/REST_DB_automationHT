using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RESTautomationHT        
{
       public class DataObject             
    {
        public string Name { get; set; }
    }

    public class Rclient
    {
        private const string URL = "http://172.30.23.9:8080/ServletToDoList/";
        private static string urlParameters = "?api_key=123";       // made static by me

        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body. Blocking!
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;
                foreach (var d in dataObjects)
                {
                    Console.WriteLine("{0}", d.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}


//Create rest client
//1. Nuget - > install Microsoft.AspNet.WebApi.Client

// client.Authenticator = new HttpBasicAuthenticator("username", "password"); https://changelog.com/posts/restsharp-simple-rest-and-http-api-client-for-net

// http://stackoverflow.com/questions/9620278/how-do-i-make-calls-to-a-rest-api-using-c
//Current guidance from Microsoft is to use the Microsoft ASP.NET Web API Client Libraries
//Microsoft.AspNet.WebApi.Client