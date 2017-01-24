using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Net;
using RESTautomationHT.helpers;

namespace RESTautomationHT.nunitTests
{
    class CrudTests: TestBase
    {
        [Test]
        public void GetAllitems()
        {
            Console.WriteLine("------> getAllitems <------");
            Console.WriteLine("Get all Lists");
            HttpWebResponse GetAllItemsresponse = client.getAllitems();
            Console.WriteLine("Validate response's  Status Code");

            Assert.IsTrue(GetAllItemsresponse.StatusCode.ToString() =="OK");
            Console.WriteLine("Verify response's headers");

        //ClientResponse getAllListsResponse = client.getAllLists();

        //System.out.println("Validate response's  Status Code");
        //StatusCodeValidator.Validate("200", getAllListsResponse);

        //System.out.println("Verify response's headers");
        //Map<String, String> expectedHeaders = new HashMap<>();
        //expectedHeaders.put("Content-Type", MediaType.APPLICATION_JSON);
        //HeadersValidator.Validate(expectedHeaders, getAllListsResponse);
        }

        [Test]
        public void CreateNewItem()
        {          
            Console.WriteLine("------> createNewItems <------");
            string taskName = "NewTask_" + random.Next(1, 1000);
            string taskDate = today.ToString("yyyy-MM-dd");
            HttpWebResponse createItemResponse = client.createItems(taskName, taskDate);
            Console.WriteLine("Validate response's  Status Code");

            
            Assert.IsTrue(createItemResponse.StatusCode.ToString() == "Created");
            Console.WriteLine("Verify response's headers");
        }

        [Test]
        public void DleteItem()
        {
            Console.WriteLine("------> deleteListTest <------");
            Console.WriteLine("Create new List Item");
            string taskName = "NewTask_" + random.Next(1, 1000);
            string taskDate = today.ToString("yyyy-MM-dd");
            HttpWebResponse createItemResponse = client.createItems(taskName, taskDate);
            Console.WriteLine("Verify if task can be found by Date filter.");

            //HttpWebResponse filterByDateResponse = client.filterListsByDate("=", taskDate);

            HttpWebResponse deleteItemResponse = client.deleteItems(taskName, taskDate);
            Console.WriteLine("Validate response's  Status Code");

            Console.WriteLine(deleteItemResponse.StatusCode.ToString());
            Assert.IsTrue(deleteItemResponse.StatusCode.ToString() == "OK");
            Console.WriteLine("Verify response's headers");
        }

    //     @Test
    //public void deleteListTest() throws IOException {
    //    System.out.println("------> deleteListTest <------");

    //    System.out.println("Create new List Item");
    //    String listName = "NewListDelete_" + random.nextInt();
    //    String listDate = "2016-01-02";
    //    client.createListItem(Constants.Users.TEST_USER, listName, listDate);

    //    System.out.println("Verify if list can be found by Date filter.");
    //    ClientResponse filterByDateResponse = client.filterListsByDate("=", listDate);

    //    Assert.assertTrue(
    //            String.format("Created listItem: %s : %s, could not be found by date filter.", listName, listDate),
    //            BodyValidator.verifyIfListItemIsPresent(listName,listDate,filterByDateResponse)
    //    );

    //    System.out.println(String.format("Delete List Item -> %s : %s", listName, listDate));
    //    ClientResponse deleteResponse = client.deleteListItem(Constants.Users.TEST_USER, listName, listDate);

    //    System.out.println("Validate response's  Status Code");
    //    StatusCodeValidator.Validate("200", deleteResponse);

    //    filterByDateResponse = client.filterListsByDate("=", listDate);
    //    Assert.assertFalse(
    //            String.format("Created listItem: %s : %s, could not be found by date filter.", listName, listDate),
    //            BodyValidator.verifyIfListItemIsPresent(listName, listDate, filterByDateResponse)
    //    );


    }
}
