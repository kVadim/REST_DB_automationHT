using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RESTautomationHT.helpers;

namespace RESTautomationHT.validators
{
    public class BodyValidator
    {

        public static bool verifyIfListItemIsPresent(String ExpectedName, String ExpectedDate, HttpWebResponse ActualResponse)
        {
            string responseText;
            var encoding = ASCIIEncoding.ASCII;
            using (var reader = new System.IO.StreamReader(ActualResponse.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
            }


            Dictionary<string, Dictionary<string, string>> userTasks = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(responseText);

            for (int i = 0; i < userTasks.Values.ElementAt(0).Count; i++)
            {
                if (ExpectedName == userTasks.Values.ElementAt(0).Keys.ElementAt(i))
                {
                    if (ExpectedDate == userTasks.Values.ElementAt(0).Values.ElementAt(i))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
   
