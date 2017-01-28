using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RESTautomationHT.helpers;
using RESTautomationHT.RESTclient;
using System.Net;

namespace RESTautomationHT.allTests.Tests_for_REST
{
    [TestFixture]
    public class TestBaseREST
    {
        protected Random random = new Random();
        protected DateTime today = DateTime.Today;
        protected static RestClientActions client = new RestClientActions();

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
            client.logout();
        }

    }
}




