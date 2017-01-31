using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RESTautomationHT.helpers
{
    public static class OutputResponceContent
    {
        public static void Print(HttpWebResponse response)
        {
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                string responseText = sr.ReadToEnd();
                char[] charSeparators = new char[] { ',', '{', '}' };
                string[] tasks = responseText.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                foreach (string task in tasks)
                {
                    Console.WriteLine(task);
                }
            }

        } 
    }
}
