using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESTautomationHT.Clients.DBclient;
using RESTautomationHT.helpers;
using System.Data.SqlClient;
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
            List<Dictionary<string, object>> allTasks = new List<Dictionary<string, object>>();
            try
            {
                DataTable Tasks = this.executeQuery(String.Format("SELECT * FROM LISTS"));
                if (Tasks.Rows.Count == 0)
                {
                    Console.WriteLine("Table is empty");
                }
                foreach (DataRow drCurrent in Tasks.Rows)
                {
                    string id = drCurrent[0].ToString();
                    string user = drCurrent[1].ToString();
                    string taskName = drCurrent[2].ToString();
                    string taskDate = DateTime.Parse(drCurrent[3].ToString()).ToString("yyyy-M-dd");
                    string currentRow = String.Format("{0} : {1} : {2}: {3}", id, user, taskName, taskDate);
                    Console.WriteLine(currentRow);
                }
                allTasks = this.serializeResult(Tasks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return allTasks;
        }



        public void createNewTask(string taskName, string taskDate)
        {
            try
            {
                this.ExecuteNonQuery(String.Format("INSERT INTO LISTS (OWNER,NAME,DATE) VALUES('{0}','{1}','{2}')", Constants.Users.TEST_USER, taskName, taskDate ));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void deleteTask(string taskName, string taskDate)
        {
            try
            {
                this.ExecuteNonQuery(String.Format("DELETE FROM LISTS WHERE OWNER = '{0}' AND NAME ='{1}' AND DATE = '{2}'", Constants.Users.TEST_USER, taskName, taskDate));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        //public List<string> getUniqueTask(string taskName, string taskDate)
        //{
        //    List<string> uniqueTask = new List<string>();
        //    try
        //    {
        //      uniqueTask = this.executeQuery(String.Format("SELECT * FROM LISTS WHERE NAME = '{0}' AND DATE = '{1}'",  taskName, taskDate));
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.StackTrace);
        //    }

        //    return uniqueTask;
        //}

        public List<Dictionary<string, object>> getUniqueTask(string taskName, string taskDate)
        {
            DataTable Tasks = new DataTable();
            List<Dictionary<string, object>> uniqueTask = new List<Dictionary<string, object>>();

            try
            {
                Tasks = this.executeQuery(String.Format("SELECT * FROM LISTS WHERE NAME = '{0}' AND DATE = '{1}'", taskName, taskDate));
                foreach (DataRow drCurrent in Tasks.Rows)
                {
                    string df = Tasks.Columns[0].ToString(); 
                    string id = drCurrent[0].ToString();
                    //string id = drCurrent["ID"].ToString();
                    string owner = drCurrent["OWNER"].ToString();
                    string name = drCurrent["NAME"].ToString();
                    string date = drCurrent["DATE"].ToString();

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
                            task.Add(datatable.Columns[i].ToString(), datatable.Rows[i]);
                           
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



//public class ToDoListDbClient extends DbClient {
//    private static String currentUser = "";

//    public ToDoListDbClient() {
//    }

//    public void connectToDb(String dbUrl, String user, String password) throws Exception {
//        if(user.equalsIgnoreCase("sa")) {
//            currentUser = "admin";
//        }

//        this.connect(dbUrl, user, password);
//    }

//    public void disconnectFromDb() {
//        super.disconnect();
//    }

//    public List<Map<String, Object>> getAllTasks() throws Exception {
//        Object list = new ArrayList();

//        try {
//            ResultSet e = this.executeQuery("SELECT * FROM LISTS");
//            list = this.serializeResult(e);
//        } catch (SQLException var3) {
//            var3.printStackTrace();
//        }

//        return (List)list;
//    }

//    public List<Map<String, Object>> getUniqueTask(String name, String date) throws Exception {
//        Object list = new ArrayList();

//        try {
//            ResultSet e = this.executeQuery(String.format("SELECT * FROM LISTS WHERE NAME = \'%s\' AND DATE = \'%s\'", new Object[]{name, date}));
//            list = this.serializeResult(e);
//        } catch (SQLException var5) {
//            var5.printStackTrace();
//        }

//        return (List)list;
//    }

//    public void createNewTask(String name, String date) {
//        try {
//            this.execute(String.format("INSERT INTO LISTS (OWNER,NAME,DATE) VALUES(\'%s\',\'%s\',\'%s\')", new Object[]{currentUser, name, date}));
//        } catch (Exception var4) {
//            var4.printStackTrace();
//        }

//    }

//    public void deleteTask(String name, String date) {
//        try {
//            this.execute(String.format("DELETE FROM LISTS WHERE OWNER = \'%s\' AND NAME =\'%s\' AND DATE = \'%s\'", new Object[]{currentUser, name, date}));
//        } catch (Exception var4) {
//            var4.printStackTrace();
//        }

//    }

//    private List<Map<String, Object>> serializeResult(ResultSet resultSet) {
//        ArrayList list = new ArrayList();

//        try {
//            while(resultSet.next()) {
//                HashMap e = new HashMap();

//                for(int i = 1; i <= resultSet.getMetaData().getColumnCount(); ++i) {
//                    e.put(resultSet.getMetaData().getColumnName(i), resultSet.getObject(i));
//                }

//                list.add(e);
//            }
//        } catch (SQLException var5) {
//            var5.printStackTrace();
//        }

//        return list;
//    }
//}
