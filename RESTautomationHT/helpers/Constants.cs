using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RESTautomationHT.helpers
{
    public static class Constants
    {
        public static class Users {
            public static string TEST_USER = ConfigurationManager.AppSettings["user"];
            public static string TEST_USER_PASSWORD = ConfigurationManager.AppSettings["password"];
        }   
        
        public static class Urls {
            public static string APP_URL = ConfigurationManager.AppSettings["app_url"];
            public static string LOGIN_URL = APP_URL + "Login";
            public static string GET_LISTS_URL = APP_URL + "GetLists";
            public static string CREATE_LISTS_URL = APP_URL + "CreateList";
            public static string DELETE_LISTS_URL = APP_URL + "DeleteList";
        }
    }
}

