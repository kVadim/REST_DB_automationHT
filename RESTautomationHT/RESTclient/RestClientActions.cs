using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RESTautomationHT.helpers;

namespace RESTautomationHT.RESTclient
{
    public class RestClientActions: RestClient
    {
        //static CookieContainer myContainer = new CookieContainer();

        public void login(string user, string password)  
        {
            HttpWebResponse firstrequest = sendRequest(Constants.Urls.APP_URL, HttpMethod.GET);
            string authContentType = "application/x-www-form-urlencoded";
            string credentialsBody = String.Format("name={0}&password={1}", user, password);
           // var data = Encoding.ASCII.GetBytes(credentialsBody);

            HttpWebResponse request = sendRequest(Constants.Urls.LOGIN_URL, HttpMethod.POST, credentialsBody, authContentType);

            //HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(Constants.Urls.LOGIN_URL);
            //request1.CookieContainer = myContainer;
            //request1.Accept = "*/*";
            //request1.Method = HttpMethod.POST.ToString();
            //request1.ContentType = authContentType;
            //request1.ContentLength = data.Length;
            //using (var stream = request1.GetRequestStream())
            //{
            //    stream.Write(data, 0, data.Length);
            //}
            //HttpWebResponse response1;
            //try
            //{
            //    response1 = (HttpWebResponse)request1.GetResponse();
            //}
            //catch (System.Net.WebException ex)
            //{
            //    response1 = ex.Response as HttpWebResponse;
            //    var encoding = ASCIIEncoding.ASCII;
            //    using (var reader = new System.IO.StreamReader(response1.GetResponseStream(), encoding))
            //    {
            //        string responseText = reader.ReadToEnd();
            //    }
            //    Console.WriteLine("Status 500");
            //    Console.WriteLine("That's strange");
            //}

        }
    }
}
