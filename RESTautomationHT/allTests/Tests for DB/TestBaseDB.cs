using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



//============================================================================================
//public class DbTestBase {
///    protected static ToDoListDbClient client = new ToDoListDbClient();
///   protected Random random = new Random();

//    public DbTestBase() {
//    }

///    @Before
///    public void setUp() throws Exception {
///        System.out.println("Connect to DB");
//        client.connectToDb(Urls.DB_URL, Users.DB_ADMIN, Users.DB_ADMIN_PASSWORD);
//    }

//    @After
//    public void tearDown() throws Exception {
//        System.out.println("Disconnect from db");
//        client.disconnectFromDb();
//    }
//}
