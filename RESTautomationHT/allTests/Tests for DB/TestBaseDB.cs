using System;
using RESTautomationHT.Clients.DBclient;
using NUnit.Framework;
using RESTautomationHT.helpers;

namespace RESTautomationHT.allTests.Tests_for_DB
{
    public class TestBaseDB
    {
        protected Random random = new Random();
        protected DateTime today = DateTime.Today;
        protected static DBclientActions client = new DBclientActions();

        [SetUp]
        public void ConnectToDB()
        {
            Console.WriteLine("Connect to DB");
            client.connectToDb(Constants.Urls.DB_URL,
                               Constants.DB.DB_NAME,
                               Constants.Users.DB_ADMIN,
                               Constants.Users.DB_ADMIN_PASSWORD);
        }

        [TearDown]
        public void DisconnectFromDB()
        {
            client.disconnectFromDb();
            Console.WriteLine("Disconnected from db");
        }

    }
}

