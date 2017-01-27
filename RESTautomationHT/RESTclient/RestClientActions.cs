﻿using System;
using System.Net;
using RESTautomationHT.helpers;

// - coockiestorage,
namespace RESTautomationHT.RESTclient
{
    public class RestClientActions : RestClient
    {
        //static CookieContainer myContainer = new CookieContainer(); // WHY DO WE NEED IT HERE ?
        // why  not void
        public void login(string user, string password)
        {
            HttpWebResponse firstresponse = sendRequest(Constants.Urls.APP_URL, HttpMethod.GET);
            //myContainer.GetCookies();
            string authContentType = "application/x-www-form-urlencoded";
            string credentialsBody = String.Format("name={0}&password={1}", user, password);
            HttpWebResponse responce = sendRequest(Constants.Urls.LOGIN_URL, HttpMethod.POST, credentialsBody, authContentType);
        }

        public HttpWebResponse getAllitems()
        {
            return sendRequest(Constants.Urls.GET_LISTS_URL, HttpMethod.GET);
        }

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

        public void logout()
        {
            var cookies = myContainer.GetCookies(new Uri(Constants.Urls.APP_URL));                foreach (Cookie co in cookies)                {                  co.Expires = DateTime.Now.Subtract(TimeSpan.FromDays(1));                }
        }

        public HttpWebResponse filterListsByDate(string operation, string taskDate)
        {
            string filterRequest = String.Format("{0}?filterValue={1}&dateValue={2}", Constants.Urls.GET_LISTS_URL, operation, taskDate);
            return sendRequest(filterRequest, HttpMethod.GET);
        }

    }
}






