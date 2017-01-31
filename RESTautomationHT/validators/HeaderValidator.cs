using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace RESTautomationHT.validators
{
    public class HeadersValidator   
    {
        public static void Validate(Dictionary<String, String> ExpectedHeaders, HttpWebResponse ActualResponse)
        {
            for (int i = 0; i < ExpectedHeaders.Count; i++)
            {
                bool currentHeaderIsFound = false;
                for (int j = 0; j < ActualResponse.Headers.Count; j++)
                {
                    if (ActualResponse.Headers.Keys[j] != null)
                    {
                        if (ExpectedHeaders.Keys.ElementAt(i) == ActualResponse.Headers.Keys[j])
                        {
                            currentHeaderIsFound = true;
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
                if (!currentHeaderIsFound)
                {
                    throw new Exception(String.Format("Expected Header: {0} is not found among actual headers", ExpectedHeaders.Keys.ElementAt(i)));
                }
            }
        }
    }
}

