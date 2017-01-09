using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RESTautomationHT.nunitTests
{
    class CrudTests: TestBase
    {
        [Test]
        public void GetAllitems()
        {
            Console.WriteLine("------> getAllitems <------");
        }

        [Test]
        public void CreateNewitems()
        {          
            Console.WriteLine("------> createNewItems <------");
            string listName = "NewList_" + random.Next(1, 1000);
            string listDate = String.Format(); 

        }

    }
}


//@Test
//    public void createNewListTest() throws IOException {
//        System.out.println("------> createNewListTest <------");
//        System.out.println("Create new List Item");
//        String listName = "NewList_" + random.nextInt();
//        String listDate = "2016-01-01";



//        ClientResponse createResponse = client.createListItem(Constants.Users.TEST_USER, listName, listDate);

//        System.out.println("Validate response's  Status Code");
//        StatusCodeValidator.Validate("201", createResponse);

//        System.out.println("Verify if list can be found by Date filter.");
//        ClientResponse filterByDateResponse = client.filterListsByDate("=",listDate);

//        Assert.assertTrue(
//                String.format("Created listItem: %s : %s, could not be found by date filter.", listName, listDate),
//                BodyValidator.verifyIfListItemIsPresent(listName,listDate,filterByDateResponse)
//        );
//    }

//@Test
//    public void getAllListsTest() throws Exception {
//        System.out.println("------> getAllListsTest <------");

//        System.out.println("Get all Lists");
//        ClientResponse getAllListsResponse = client.getAllLists();

//        System.out.println("Validate response's  Status Code");
//        StatusCodeValidator.Validate("200", getAllListsResponse);

//        System.out.println("Verify response's headers");
//        Map<String, String> expectedHeaders = new HashMap<>();
//        expectedHeaders.put("Content-Type", MediaType.APPLICATION_JSON);
//        HeadersValidator.Validate(expectedHeaders, getAllListsResponse);

//    }