using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace RESTautomationHT.helpers
{
    public static class myJsonConverter
    {
        public static string getJson(string task, string date)
        {

            var data = new Task { TaksName = task, Date = date };
            string serialized = JsonConvert.SerializeObject(data, Formatting.Indented);
            return serialized;
        }
    }
    struct Task
    {
        public string TaksName;
        public string Date;
    }

 

    //public class myTask
    //{
    //    public string TName { get; set; }
    //    public string D { get; set; }
    //    public User User { get; set; }

    //    public myTask(string taskname, string date, User user)
    //    {
    //        TName = taskname;
    //        D = date;
    //        User = user;
    //    }
    //}

    //public class User
    //{
    //    public string Name { get; set; }       
    //    public User(string name)
    //    {
    //        Name = name;
    //    }
    //}


}
