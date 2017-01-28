using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RESTautomationHT.Clients.DBclient;

namespace RESTautomationHT.Clients.DBclient
{
    public class DBclientActions : DBclient
    {
        static string currentUser = "";

        public void connectToDb(string db_url, string db_name, string db_user, string db_password)
        {
             if(db_user.Equals("sa")) 
             {
                currentUser = "admin";
             }
             this.connect(db_url, db_name, db_user, db_password);
        }



        public void disconnectFromDb()
        {
            base.disconnect();
        }
    }
}

//package client.db;

//import client.db.DbClient;
//import java.sql.ResultSet;
//import java.sql.SQLException;
//import java.util.ArrayList;
//import java.util.HashMap;
//import java.util.List;
//import java.util.Map;

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
