using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net;
using RESTautomationHT.helpers;
using RESTautomationHT.validators;

namespace RESTautomationHT.nunitTests
{
    class CrudTests: TestBase
    {
        [Test]
        public void GetAllitems()
        {
            Console.WriteLine("------> getAllitems <------");
            Console.WriteLine("Get all Lists");
            HttpWebResponse getAllItemsresponse = client.getAllitems();
            Console.WriteLine("Validate response's  Status Code");
            StatusCodeValidator.Validate("OK", getAllItemsresponse);
            Console.WriteLine("Verify response's headers");
            Dictionary<String, String> expectedHeaders = new Dictionary<String, String>();
            expectedHeaders.Add("Content-Type", "application/json");
            HeadersValidator.Validate(expectedHeaders, getAllItemsresponse);
        }


        [Test]
        public void CreateNewItem()
        {          
            Console.WriteLine("------> createNewItems <------");
            string taskName = "NewTask_" + random.Next(1, 1000);
            string taskDate = today.ToString("yyyy-MM-dd");
            HttpWebResponse createItemResponse = client.createItems(Constants.Users.TEST_USER, taskName, taskDate);
            Console.WriteLine("Validate response's  Status Code");
            StatusCodeValidator.Validate("Created", createItemResponse);
            Console.WriteLine("Verify if task can be found by Date filter.");
            HttpWebResponse filterByDateResponse = client.filterListsByDate("=", taskDate);

            Assert.IsTrue(BodyValidator.verifyIfListItemIsPresent(taskName, taskDate, filterByDateResponse),
                String.Format("Created listItem: {0} : {1}, can not be found by date filter.", taskName, taskDate));
        }

        [Test]
        public void DleteItem()
        {
            Console.WriteLine("------> deleteListTest <------");
            Console.WriteLine("Create new List Item");
            string taskName = "NewTask_" + random.Next(1, 1000);
            string taskDate = today.ToString("yyyy-MM-dd");
            HttpWebResponse createItemResponse = client.createItems(Constants.Users.TEST_USER, taskName, taskDate);
            Console.WriteLine("Verify if task can be found by Date filter.");
            HttpWebResponse filterByDateResponse = client.filterListsByDate("=", taskDate);

            Assert.IsTrue( BodyValidator.verifyIfListItemIsPresent(taskName, taskDate, filterByDateResponse),
                String.Format("Created listItem: {0} : {1}, can not be found by date filter.", taskName, taskDate) );

            Console.WriteLine("Delete List Item -> {0} : {0}", taskName, taskDate);
            HttpWebResponse deleteItemResponse = client.deleteItems(Constants.Users.TEST_USER, taskName, taskDate);
            Console.WriteLine("Validate response's  Status Code");
            StatusCodeValidator.Validate("OK", deleteItemResponse);

            Console.WriteLine("Verify if task can not be found by Date filter.");
            filterByDateResponse = client.filterListsByDate("=", taskDate);

            Assert.IsFalse( BodyValidator.verifyIfListItemIsPresent(taskName, taskDate, filterByDateResponse),
                String.Format("Created listItem: {0} : {1}, can be found by date filter.", taskName, taskDate) );
        }
    }
}

 

  

    
