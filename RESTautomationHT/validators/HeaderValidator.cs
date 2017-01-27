using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RESTautomationHT.validators
{
    public class HeadersValidator    // incorrect validator
    {
        public static void Validate(Dictionary<String, String> ExpectedHeaders, HttpWebResponse ActualResponse) 
        {
            for (int i = 0; i < ExpectedHeaders.Count; i++)
            {
                for (int j = 0; j < ActualResponse.Headers.Count; j++)
                {
                    if (ActualResponse.Headers.Keys[j] != null)
                    {
                        if (ExpectedHeaders.Keys.ElementAt(i) == ActualResponse.Headers.Keys[j])
                        {
                            if (ExpectedHeaders.Values.ElementAt(i) == ActualResponse.GetResponseHeader(ActualResponse.Headers.Keys[j]))
                            {
                                break;
                            }
                            else
                            {
                                throw new Exception(
                                                    String.Format("Expected Header: {0} Value: {1} is not equal to extected Value: {2}",
                                                        ExpectedHeaders.Keys.ElementAt(i),
                                                        ExpectedHeaders.Values.ElementAt(i),
                                                        ActualResponse.GetResponseHeader(ActualResponse.Headers.Keys[j]))
                                                   );
                            }
                        }
                    }
                }
            }
        }
    }
}

