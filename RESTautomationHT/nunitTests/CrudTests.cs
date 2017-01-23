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

            HttpWebResponse deleteItemResponse = client.deleteItems(taskName, taskDate);
            Console.WriteLine("Validate response's  Status Code");

            Console.WriteLine(deleteItemResponse.StatusCode.ToString());
            Assert.IsTrue(deleteItemResponse.StatusCode.ToString() == "OK");
            Console.WriteLine("Verify response's headers");
        }
    }
}
