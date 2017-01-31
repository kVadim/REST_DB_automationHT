using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RESTautomationHT.helpers
{
    public static class SendToOutput
    {
        public static void SendHttpResponse(HttpWebResponse response)
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

        public static void SendSQLResponse(DataTable tasks)
        {
            foreach (DataRow drCurrent in tasks.Rows)
            {
                string id = drCurrent[0].ToString();
                string user = drCurrent[1].ToString();
                string Name = drCurrent[2].ToString();
                string Date = DateTime.Parse(drCurrent[3].ToString()).ToString("yyyy-MM-dd");
                string currentRow = String.Format("{0} : {1} : {2} : {3}", id, user, Name, Date);
                Console.WriteLine(currentRow);
            }
        } 
    }
}


