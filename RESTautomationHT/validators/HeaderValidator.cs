using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RESTautomationHT.validators
{
    public class HeadersValidator
    {
        public static void Validate(Dictionary<String, String> ExpectedHeaders, HttpWebResponse ActualResponse) 
        {
            for (int i = 0; i < ExpectedHeaders.Count; i++)
            {
                if (ActualResponse.GetResponseHeader(ExpectedHeaders.Keys.ElementAt(i)) == ExpectedHeaders.Values.ElementAt(i))
                {
                               
                }
                else
                {
                    String.Format("Expected Header: {0} Value: {1} is not equal to extected Value: {2}",
                       ExpectedHeaders.Keys.ElementAt(i), 
                       ExpectedHeaders.Values.ElementAt(i), 
                       ActualResponse.GetResponseHeader(ExpectedHeaders.Keys.ElementAt(i)));
                }
            }
            //for (Map.Entry<String, String> expectedHeader : ExpectedHeaders.entrySet()) {
            //    for (Map.Entry<String, List<String>> actualHeader : ActualResponse.getHeaders().entrySet()) {
            //        if (actualHeader.getKey() != null) {
            //            if (expectedHeader.getKey().equalsIgnoreCase(actualHeader.getKey())) {
            //                if (actualHeader.getValue().contains(expectedHeader.getValue())) {
            //                    break;
            //                } else {
            //                    throw new Exception(
            //                            String.format(
            //                                    "Expected Header: %s Value: %s is not equal to extected Value: %s",
            //                                    expectedHeader.getKey(), expectedHeader.getValue(), actualHeader.getValue()
            //                            )
            //                    );
            //                }

            //            }
            //        }
            //    }

            //}
        }
    }
}
