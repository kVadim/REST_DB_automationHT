using System;
using System.Text;
using System.Net.Http;
using RESTautomationHT.helpers;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RESTautomationHT
{
    public abstract class RestClient
    {
        public HttpWebResponse response = null; 
        // protected static WebHeaderCollection Headers;
        protected static CookieContainer myContainer = new CookieContainer();
        public enum HttpMethod
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        protected HttpWebResponse sendRequest(string Url, HttpMethod Method, string Body = null, string ContentType = null)
        {
            string method = Method.ToString();
            string accept = "application/json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.CookieContainer = myContainer;
            var data = Encoding.ASCII.GetBytes(Body);
            var encoding = ASCIIEncoding.ASCII;
            try
            {
                switch (method)
                {
                    case "GET":
                        if (Url.Contains("Login")) accept = "*/*";
                        request.CookieContainer = myContainer;
                        request.Method = Method.ToString();
                        request.Accept = accept;
                        request.ContentType = ContentType;
                        using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                        {
                            string responseText = reader.ReadToEnd();
                        }
                        return (HttpWebResponse)request.GetResponse();

                    case "POST":
                        request.CookieContainer = myContainer;
                        request.Method = Method.ToString();
                        request.Accept = accept;
                        request.ContentType = ContentType;
                        request.ContentLength = data.Length;
                        using (var stream = request.GetRequestStream())
                        {
                            stream.Write(data, 0, data.Length);
                        }
                        try
                        {
                            response = (HttpWebResponse)request.GetResponse();
                        }
                        catch (System.Net.WebException ex)
                        {
                            response = ex.Response as HttpWebResponse;
                            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                            {
                                string responseText = reader.ReadToEnd();
                            }
                            Console.WriteLine("Status 500");
                            Console.WriteLine("That's strange");
                        }
                        return response;

                    case "PUT":
                        request.CookieContainer = myContainer;
                        request.Method = Method.ToString();
                        request.Accept = "application/json";
                        request.ContentType = ContentType;
                        return (HttpWebResponse)request.GetResponse();

                    case "DELETE":
                        request.CookieContainer = myContainer;
                        request.Method = Method.ToString();
                        request.Accept = "application/json";
                        request.ContentType = ContentType;
                        return (HttpWebResponse)request.GetResponse();
                }
            }
            catch (Exception)
            {
                response = null;              
            }
            return response;
        }
    }
}





//



//var encoding = ASCIIEncoding.ASCII;
//using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
//{
//    string responseText = reader.ReadToEnd();
//} 

// https://www.asp.net/web-api/overview/advanced/calling-a-web-api-from-a-net-client
