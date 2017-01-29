using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTautomationHT.Clients.DBclient
{
    public abstract class DBclient
    {
        SqlConnection cnn = null;
       

        protected void connect(String DbUrl, String DbName, String DbUser, String DbPassword) 
        {
            string connetionString = null;            connetionString = String.Format(@"Data Source={0};Initial Catalog={1};User ID={2};Password={3}", DbUrl, DbName, DbUser, DbPassword);

            if (this.cnn == null)
            {
                cnn = new SqlConnection(connetionString);
                try
                {
                    cnn.Open();
                    Console.WriteLine("Connection Opened ! ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                    Console.WriteLine(ex.StackTrace);
                }                 
            }
           
        }
        protected void disconnect() {
            try {
                    if(this.cnn != null) 
                    {
                        this.cnn.Close();
                        this.cnn = null;
                        Console.WriteLine("Connection Closed ! ");
                    }
                } 
            catch (Exception ex) 
                {
                   Console.WriteLine("Can not close connection ! ");
                   Console.WriteLine(ex.StackTrace);
                }
        }

        protected DataTable executeQuery(String sql)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand(sql);
            //cmd.ExecuteNonQuery();
            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                adp.Fill(ds);
            }
           // adp(sql);
           // adp.SelectCommand = new SqlCommand(sql, cnn);
            
            dt = ds.Tables["myData"];


            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    Console.WriteLine();
            //}
            //reader.Close();



            //ResultSet result = null;
            //if (this.connection != null)
            //{
            //    try
            //    {
            //        Statement e = this.connection.createStatement();
            //        result = e.executeQuery(sql);
            //    }
            //    catch (Exception var4)
            //    {
            //        throw new Exception(var4.getMessage());
            //    }
            //}

            return dt;
        }

        protected  void execute(string sql) {
            if (this.cnn != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

        }


    }
}

//package client.db;

//import java.sql.Connection;
//import java.sql.DriverManager;
//import java.sql.ResultSet;
//import java.sql.Statement;

//public abstract class DbClient {
//    Connection connection = null;

//    public DbClient() {
//    }

//    protected final void connect(String DbUrl, String DbUser, String DbPassword) throws Exception {
//        try {
//            Class.forName("org.h2.Driver");
//            if(this.connection == null) {
//                this.connection = DriverManager.getConnection(DbUrl, DbUser, DbPassword);
//            }

//        } catch (Exception var5) {
//            throw new Exception(var5.getMessage());
//        }
//    }

//    protected final void disconnect() {
//        try {
//            if(this.connection != null) {
//                this.connection.close();
//                this.connection = null;
//            }
//        } catch (Exception var2) {
//            var2.printStackTrace();
//        }

//    }

//    protected final ResultSet executeQuery(String sql) throws Exception {
//        ResultSet result = null;
//        if(this.connection != null) {
//            try {
//                Statement e = this.connection.createStatement();
//                result = e.executeQuery(sql);
//            } catch (Exception var4) {
//                throw new Exception(var4.getMessage());
//            }
//        }

//        return result;
//    }

//    protected final void execute(String sql) {
//        if(this.connection != null) {
//            try {
//                Statement e = this.connection.createStatement();
//                e.execute(sql);
//            } catch (Exception var3) {
//                var3.printStackTrace();
//            }
//        }

//    }
//}