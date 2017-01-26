using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
            UserTasks userTasks = Newtonsoft.Json.JsonConvert.DeserializeObject<UserTasks>(responseText);

            for (int i = 0; i < userTasks.User3.Count; i++)
            {
                if (ExpectedName == userTasks.User3.Keys.ElementAt(i))
                {
                    if (ExpectedDate == userTasks.User3.Values.ElementAt(i))
                    {
                        return true;
                    }
                }
            }
            return false;
        //Map<String,Map<String,String>> convertedResponse = JsonConverter.allListsJsonToMap(ActualResponse.getEntity(String.class));

        //for(String user : convertedResponse.keySet()){
        //    for(Map.Entry<String,String> listItem : convertedResponse.get(user).entrySet()){
        //        if(listItem.getKey().equalsIgnoreCase(ExpectedName)){
        //            if(listItem.getValue().equalsIgnoreCase(ExpectedDate)){
        //                return true;
        //            }
        //        }
        //    }
        //}
            
        }
    }


    //public class User3
    //{
    //    public string NewTask_439 { get; set; }
    //    public string NewTask_28 { get; set; }
    //}

    //public class UserTasks
    //{
    //    public User3 user3 { get; set; }
    //}

    

    public class UserTasks
    {
        public Dictionary<string, string> User3 { get; set; }
    }
}
