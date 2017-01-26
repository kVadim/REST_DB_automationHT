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
         
        }
    }
}
