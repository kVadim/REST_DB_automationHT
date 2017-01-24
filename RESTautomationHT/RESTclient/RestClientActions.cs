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
        //static CookieContainer myContainer = new CookieContainer(); // WHY DO WE NEED IT HERE

        public void login(string user, string password)  
        {
            HttpWebResponse firstresponce = sendRequest(Constants.Urls.APP_URL, HttpMethod.GET);
            string authContentType = "application/x-www-form-urlencoded";
            string credentialsBody = String.Format("name={0}&password={1}", user, password);
            HttpWebResponse responce = sendRequest(Constants.Urls.LOGIN_URL, HttpMethod.POST, credentialsBody, authContentType);

        //    if (!String.valueOf(loginResponse.getStatusCode()).equals("200"))
        //    {
        //        // da u nas uspeshni login eto 500
        //        throw new Exception("Looks like you didn't log in, buddy");
        //    }
        //    return loginResponse;
        }

        //public ClientResponse getAllLists()
        //{
        //    return sendRequest(Constants.Urls.GET_LISTS_URL, HttpMethod.GET, "", null, null);
        //}

        public HttpWebResponse getAllitems()
        {
            return sendRequest(Constants.Urls.GET_LISTS_URL, HttpMethod.GET);

            // HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(Constants.Urls.GET_LISTS_URL);
            // request2.CookieContainer = myContainer;
            //request2.Accept = "application/json";
            //request2.Method = HttpMethod.GET.ToString();
            //HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
            //var encoding = ASCIIEncoding.ASCII;
            //using (var reader = new System.IO.StreamReader(response2.GetResponseStream(), encoding))
            //{
            //    string responseText = reader.ReadToEnd();
            //}
            //return response2;
        }

        //public ClientResponse createListItem(String user, String name, String date)
        //{
        //    String body = ListItemTools.generateListItemBody(user, name, date);
        //    return sendRequest(Constants.Urls.CREATE_LISTS_URL, HttpMethod.POST, body, null, null);
        //}

        public HttpWebResponse createItems(string taskName, string taskDate)
        {
            string taskjsonBody = string.Format("{0}\"{2}\":{0}\"{3}\":\"{4}\"{1}{1}", "{", "}", Constants.Users.TEST_USER, taskName, taskDate);

            return sendRequest(Constants.Urls.CREATE_LISTS_URL, HttpMethod.POST, taskjsonBody);


          //  var task = Encoding.ASCII.GetBytes(taskjson);
           // HttpWebRequest request3 = (HttpWebRequest)WebRequest.Create(Constants.Urls.CREATE_LISTS_URL);
           // request3.CookieContainer = myContainer;
          //  request3.Accept = "*/*";
           // request3.Method = HttpMethod.POST.ToString();
           // request3.ContentType = "application/json";
           // request3.ContentLength = task.Length;
            //using (var stream = request3.GetRequestStream())
            //{
            //    stream.Write(task, 0, task.Length);
            //}
            //HttpWebResponse response3 = (HttpWebResponse)request3.GetResponse();
            //return response3;
        }

    //     public ClientResponse deleteListItem(String UserName, String listItemName, String listItemDate) {
    //    MultivaluedMap<String, String> deleteQuery = new MultivaluedMapImpl<>();
    //    deleteQuery.add("tasks", String.format("%s:%s:%s", UserName, listItemName, listItemDate));

    //    return sendRequest(Constants.Urls.DELETE_LISTS_URL, HttpMethod.POST, "", deleteQuery, null);
    //}

        public HttpWebResponse deleteItems(string taskName, string taskDate)
        {
            string dRequest = String.Format("{0}?tasks={1}:{2}:{3}", Constants.Urls.DELETE_LISTS_URL, Constants.Users.TEST_USER, taskName, taskDate);
            //return sendRequest(Constants.Urls.DELETE_LISTS_URL, HttpMethod.POST, "", dRequest);
            return sendRequest(dRequest, HttpMethod.POST,"");

            //HttpWebRequest deleteRequest = (HttpWebRequest)WebRequest.Create(dRequest);
            //deleteRequest.CookieContainer = myContainer;
            //deleteRequest.Accept = "application/json";
            //deleteRequest.Method = HttpMethod.POST.ToString();
            //HttpWebResponse deleteResponse = (HttpWebResponse)deleteRequest.GetResponse();
            //return deleteResponse;
        }

        public void Logout()
        {

        }

        public HttpWebResponse filterListsByDate(string p, string taskDate)
        {
            return sendRequest(Constants.Urls.GET_LISTS_URL, HttpMethod.GET);
        }

        //public ClientResponse filterListsByDate(String filterValue, String dateValue) {
        //MultivaluedMap<String, String> filterQuery = new MultivaluedMapImpl<>();
        //filterQuery.add("filterValue", filterValue);
        //filterQuery.add("dateValue", dateValue);

        //return sendRequest(Constants.Urls.GET_LISTS_URL, HttpMethod.GET, "", filterQuery, null);

    }

}

