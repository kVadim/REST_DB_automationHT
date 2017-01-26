using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RESTautomationHT.helpers;

namespace RESTautomationHT.RESTclient
{
    public class RestClientActions : RestClient
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
        }

        //public ClientResponse createListItem(String user, String name, String date)
        //{
        //    String body = ListItemTools.generateListItemBody(user, name, date);
        //    return sendRequest(Constants.Urls.CREATE_LISTS_URL, HttpMethod.POST, body, null, null);
        //}

        public HttpWebResponse createItems(string userName, string taskName, string taskDate)
        {
            string taskjsonBody = string.Format("{0}\"{2}\":{0}\"{3}\":\"{4}\"{1}{1}", "{", "}", userName, taskName, taskDate);
            return sendRequest(Constants.Urls.CREATE_LISTS_URL, HttpMethod.POST, taskjsonBody);
        }

        public HttpWebResponse deleteItems(string userName, string taskName, string taskDate)
        {
            string deleteRequest = String.Format("{0}?tasks={1}:{2}:{3}", Constants.Urls.DELETE_LISTS_URL, userName, taskName, taskDate);
            return sendRequest(deleteRequest, HttpMethod.POST, "");
        }

        public void Logout()
        {

        }

        public HttpWebResponse filterListsByDate(string operation, string taskDate)
        {
            string filterRequest = String.Format("{0}?filterValue={1}&dateValue={2}", Constants.Urls.GET_LISTS_URL, operation, taskDate);
            return sendRequest(filterRequest, HttpMethod.GET);
        }

    }
}






