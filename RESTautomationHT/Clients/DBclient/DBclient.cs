using System;
using System.Data;
using System.Data.SqlClient;

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
            DataTable tbl = new DataTable();
             try
            {
                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataAdapter adpter = new SqlDataAdapter(cmd);
                DataSet dsTasks = new DataSet("dataSET");
                adpter.Fill(dsTasks,"LISTS");                
                tbl = dsTasks.Tables["LISTS"];
            }
            catch (Exception)
            {
                throw;
            }
            return tbl;
        }

        protected  void ExecuteNonQuery(string sql) {
            if (this.cnn != null)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
