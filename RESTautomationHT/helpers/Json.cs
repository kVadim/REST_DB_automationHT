using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTautomationHT.helpers
{

   //{"user3":{"task6":"2017-01-17"}}
    public class Taskobject
    {
        public User3 user3 { get; set; } 
    }

    public class User3
    {
        public string task6 { get; set; }
        public User3(string taskDate)
        {
            task6 = taskDate;
        }
    }
  

    public static class serialize
    {
        public static string createJson(string taskName, string taskDate)
        {
            Taskobject tObj = new Taskobject { user3 = new User3("2017-01-17") };
            string serialized = JsonConvert.SerializeObject(tObj, Formatting.Indented);
            return serialized;
        }
    }
    

}
