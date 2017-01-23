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
        public HttpWebResponse response; 
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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.CookieContainer = myContainer;
            try
            {
                switch (method)
                {
                    case "GET":
                        request.CookieContainer = myContainer;
                        request.Method = Method.ToString();
                        request.ContentType = ContentType;
                        return (HttpWebResponse)request.GetResponse();

                    case "POST":
                        var data = Encoding.ASCII.GetBytes(Body);
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


      

        public HttpWebResponse getAllitems()
        {
            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(Constants.Urls.GET_LISTS_URL);
            request2.CookieContainer = myContainer;
            request2.Accept = "application/json";
            request2.Method = HttpMethod.GET.ToString();
            HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(response2.GetResponseStream(), encoding))
            {
                string responseText = reader.ReadToEnd();
            }
            return response2;
        }


        public HttpWebResponse createItems(string taskName, string taskDate)
        {
            // string data = serialize.createJson(taskName, taskDate);
            string taskjson = string.Format("{0}\"{2}\":{0}\"{3}\":\"{4}\"{1}{1}", "{", "}", Constants.Users.TEST_USER, taskName, taskDate);

            var task = Encoding.ASCII.GetBytes(taskjson);

            HttpWebRequest request3 = (HttpWebRequest)WebRequest.Create(Constants.Urls.CREATE_LISTS_URL);
            request3.CookieContainer = myContainer;
            request3.Accept = "*/*";
            request3.Method = HttpMethod.POST.ToString();
            request3.ContentType = "application/json";
            request3.ContentLength = task.Length;
            using (var stream = request3.GetRequestStream())
            {
                stream.Write(task, 0, task.Length);
            }
            HttpWebResponse response3 = (HttpWebResponse)request3.GetResponse();

            return response3;
        }

        public HttpWebResponse deleteItems(string taskName, string taskDate)
        {
            string dRequest = String.Format("{0}?tasks={1}:{2}:{3}", Constants.Urls.DELETE_LISTS_URL, Constants.Users.TEST_USER, taskName, taskDate);

            HttpWebRequest deleteRequest = (HttpWebRequest)WebRequest.Create(dRequest);
            deleteRequest.CookieContainer = myContainer;
            deleteRequest.Accept = "application/json";
            deleteRequest.Method = HttpMethod.POST.ToString();
            HttpWebResponse deleteResponse = (HttpWebResponse)deleteRequest.GetResponse();
            return deleteResponse;
        }

        public void Logout()
        {
            
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
