using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTautomationHT.helpers
{
    public static class Constants
    {
        public static class Users {
            public static string TEST_USER = "user3";
            public static string TEST_USER_PASSWORD = "user3";
        }   
        
        public static class Urls {
            public static string APP_URL = "http://172.30.23.9:8080/ServletToDoList/";
            public static string LOGIN_URL = APP_URL + "Login";
            public static string GET_LISTS_URL = APP_URL + "GetLists";
            public static string CREATE_LISTS_URL = APP_URL + "CreateList";
            public static string DELETE_LISTS_URL = APP_URL + "DeleteList";
        }
    }
}

