using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace RESTautomationHT
{
    #region ASP.NET example
    class Program
    {


       
        
       
        //static async Task<Product> GetProductAsync(string path)
        //{
        //    Product product = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        product = await response.Content.ReadAsAsync<Product>();
        //    }
        //    return product;
        //}
    }
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
    #endregion


    public class RESTclient
    {
        
        

        static HttpClient client = new HttpClient();
       
      

        
       
        //Switcher
        //Executor
    }

      public class CRUDtests
    {
        RESTclient restclient = new RESTclient();

        //create entity
          public void CreateEntity(){
              //
          }
        //rename entity
        //update entity
        //delete entity
    }
}

