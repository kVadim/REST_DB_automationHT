using System;
using System.Collections.Generic;
using RESTautomationHT.helpers;
using System.Data;

namespace RESTautomationHT.Clients.DBclient
{
    public class DBclientActions : DBclient
    {
        public void connectToDb(string db_url, string db_name, string db_user, string db_password)
        {
             this.connect(db_url, db_name, db_user, db_password);
        }

        public void disconnectFromDb()
        {
            base.disconnect();
        }

        public List<Dictionary<string, object>> getAllTasks()
        {
            List<Dictionary<string, object>> allTasks =  new List<Dictionary<string, object>>();
            try
            {
                DataTable Tasks = this.executeQuery(String.Format("SELECT * FROM LISTS"));
                if (Tasks.Rows.Count == 0)
                {
                    Console.WriteLine("Table is empty");
                }
                else
                {
                    foreach (DataRow drCurrent in Tasks.Rows)
                    {
                        string id = drCurrent[0].ToString();
                        string user = drCurrent[1].ToString();
                        string Name = drCurrent[2].ToString();
                        string Date = DateTime.Parse(drCurrent[3].ToString()).ToString("yyyy-MM-dd");
                        string currentRow = String.Format("{0} : {1} : {2} : {3}", id, user, Name, Date);
                        Console.WriteLine(currentRow);
                    }
                }
                allTasks = this.serializeResult(Tasks);
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                allTasks = null;
            }
            return allTasks;
        }

        public bool createNewTask(string taskName, DateTime taskDate)
        {
            bool isCreated = false;
            try
            {
                this.ExecuteNonQuery(String.Format("INSERT INTO LISTS (OWNER,NAME,DATE) VALUES('{0}','{1}','{2}')", Constants.Users.TEST_USER, taskName, taskDate ));
                isCreated = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return isCreated;
        }

        public bool deleteTask(string taskName, DateTime taskDate)
        {
            bool isDeleted = false;
            try
            {
                this.ExecuteNonQuery(String.Format("DELETE FROM LISTS WHERE OWNER = '{0}' AND NAME ='{1}' AND DATE = '{2}'", Constants.Users.TEST_USER, taskName, taskDate));
                isDeleted = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            return isDeleted;
        }

        public List<Dictionary<string, object>> getUniqueTask(string taskName, DateTime taskDate)
        {
            List<Dictionary<string, object>> uniqueTask = new List<Dictionary<string, object>>();

            try
            {
                DataTable Tasks = this.executeQuery(String.Format("SELECT * FROM LISTS WHERE NAME = '{0}' AND DATE = '{1}'", taskName, taskDate.ToString("yyyy-MM-dd")));

                foreach (DataRow drCurrent in Tasks.Rows)
                {
                    string id = drCurrent[0].ToString();
                    string user = drCurrent[1].ToString();
                    string Name = drCurrent[2].ToString();
                    string Date = DateTime.Parse(drCurrent[3].ToString()).ToString("yyyy-MM-dd");
                    string currentRow = String.Format("{0} : {1} : {2} : {3}", id, user, Name, Date);
                    Console.WriteLine(currentRow);
                }
                uniqueTask = this.serializeResult(Tasks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return uniqueTask;
        }

        private List<Dictionary<string, object>> serializeResult(DataTable datatable)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            try
            {
                 foreach (DataRow drCurrent in datatable.Rows)
                {
                   Dictionary<string, object> task = new Dictionary<string, object>();
                   for (int i = 0; i < datatable.Columns.Count; ++i)
                        {
                            task.Add(datatable.Columns[i].ToString(), drCurrent[i]);
                           
                        }
                     list.Add(task);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return list;
        }
    }
}
