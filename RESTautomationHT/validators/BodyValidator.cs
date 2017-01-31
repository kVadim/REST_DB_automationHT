using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;

namespace RESTautomationHT.validators
{
    public class BodyValidator
    {
        public static bool verifyIfListItemIsPresent(String ExpectedName, String ExpectedDate, HttpWebResponse ActualResponse)
        {
            string responseText;
            using (StreamReader sr = new StreamReader(ActualResponse.GetResponseStream()))
            {
                responseText = sr.ReadToEnd();
            }

            Dictionary<string, Dictionary<string, string>> userTasks = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(responseText);

            for (int i = 0; i < userTasks.Values.ElementAt(0).Count; i++)
            {
                if (ExpectedName.Equals(userTasks.Values.ElementAt(0).Keys.ElementAt(i)))
                {
                    if (ExpectedDate.Equals(userTasks.Values.ElementAt(0).Values.ElementAt(i)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
   
