using System;
using System.Text;
using System.Net;

namespace RESTautomationHT
{
    public abstract class RestClient
    {
        protected static CookieContainer myContainer = new CookieContainer();
        public enum HttpMethod
        {
            GET,
            POST,
            PUT,
            DELETE
        }
      
        protected HttpWebResponse sendRequest(string Url, HttpMethod Method, string Body = null, string ContentType = "application/json")
        {
            string method = Method.ToString();
            string accept = "application/json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.CookieContainer = myContainer;
            try
            {
                switch (method)
                {
                    case "GET":
                        if (Url.Contains("Login")) accept = "*/*";
                        request.Method = Method.ToString();
                        request.Accept = accept;
                        request.ServicePoint.ConnectionLimit = 100;
                        return (HttpWebResponse)request.GetResponse();

                    case "POST":
                        var data = Encoding.ASCII.GetBytes(Body);
                        request.Method = Method.ToString();
                        request.Accept = accept;
                        request.ServicePoint.ConnectionLimit = 100;
                        request.ContentType = ContentType;
                        request.ContentLength = data.Length;
                        using (var stream = request.GetRequestStream())
                            {
                                stream.Write(data, 0, data.Length);
                            }
                       return (HttpWebResponse)request.GetResponse();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);        
            }
            return null;
        }
    }
}




