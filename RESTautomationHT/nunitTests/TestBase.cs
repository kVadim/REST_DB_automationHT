using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RESTautomationHT.helpers;
using RESTautomationHT.RESTclient;
using System.Net;

namespace RESTautomationHT.nunitTests
{
    [TestFixture]
    public class TestBase
    {
        protected Random random = new Random();
        protected DateTime today = DateTime.Today;
        protected static RestClientActions client = new RestClientActions();
        
    //    @BeforeClass
    //public static void init(){
    //    HttpUtils.SetSystemKeepAlive(true);
    //    HttpUtils.SetSystemProxy();
    //}



        [SetUp]
        public void Login()
        {       
            client.login(Constants.Users.TEST_USER, Constants.Users.TEST_USER_PASSWORD);
            Console.WriteLine("Logged in");
        }

        [TearDown]
        public void Logout()
        {
            Console.WriteLine("Logged out");
            client.Logout();
        }

    }
}


//@BeforeClass
//    public static void init(){
//        HttpUtils.SetSystemKeepAlive(true);
//        HttpUtils.SetSystemProxy();
//    }

