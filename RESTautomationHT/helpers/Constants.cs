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
            public static string DB_ADMIN = ConfigurationManager.AppSettings["db_user"];
            public static string DB_ADMIN_PASSWORD = ConfigurationManager.AppSettings["db_password"];
        }   
        
        public static class Urls {
            public static string APP_URL = ConfigurationManager.AppSettings["app_url"];
            public static string DB_URL = ConfigurationManager.AppSettings["db_url"];
            public static string LOGIN_URL = APP_URL + "Login";
            public static string GET_LISTS_URL = APP_URL + "GetLists";
            public static string CREATE_LISTS_URL = APP_URL + "CreateList";
            public static string DELETE_LISTS_URL = APP_URL + "DeleteList";
        }
        public static class DB
        {
            public static string DB_NAME = ConfigurationManager.AppSettings["db_name"];
           
        }
    }
}

//public class Constants {
//    private static ConnectionProperties properties = ConnectionProperties.getInstance();

//    public Constants() {
//    }

//    public static class Users {
//        public static final String TEST_USER;
//        public static final String TEST_USER_PASSWORD;
//        public static final String DB_TEST_USER;
//        public static final String DB_TEST_USER_PASSWORD;
//        public static final String DB_ADMIN;
//        public static final String DB_ADMIN_PASSWORD;

//        public Users() {
//        }

//        static {
//            TEST_USER = Constants.properties.prop.getProperty("test_user");
//            TEST_USER_PASSWORD = Constants.properties.prop.getProperty("test_user_password");
//            DB_TEST_USER = Constants.properties.prop.getProperty("db_test_user");
//            DB_TEST_USER_PASSWORD = Constants.properties.prop.getProperty("db_test_user_password");
//            DB_ADMIN = Constants.properties.prop.getProperty("db_admin_user");
//            DB_ADMIN_PASSWORD = Constants.properties.prop.getProperty("db_admin_password");
//        }
//    }

//    public static class Urls {
//        public static final String APP_URL;
//        public static final String DB_URL;
//        public static final String LOGIN_URL;
//        public static final String GET_LISTS_URL;
//        public static final String CREATE_LISTS_URL;
//        public static final String DELETE_LISTS_URL;

//        public Urls() {
//        }

//        static {
//            APP_URL = Constants.properties.prop.getProperty("app_url");
//            DB_URL = Constants.properties.prop.getProperty("db_url");
//            LOGIN_URL = APP_URL + "Login";
//            GET_LISTS_URL = APP_URL + "GetLists";
//            CREATE_LISTS_URL = APP_URL + "CreateList";
//            DELETE_LISTS_URL = APP_URL + "DeleteList";
//        }
//    }
//}

