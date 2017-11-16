using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AGENT_NEW
{
    public class Database
    {
        DataSet ds;
        SqlDataAdapter da;

        public SqlConnection conn;
        public Database()
        {
            string sqlserver = "mt-return.ddns.me,3030";

            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = "Server=" + sqlserver + ";Database=Humbuger;User ID=tt;Password=tt135135;Max Pool Size=250; Connection Timeout=300";
                conn.Open();
            }
            catch
            {
                throw;
            }
        }
        private void openConnect()
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }
        private void closeConnect()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        private DataSet execQuery(string sql)
        {
            DataSet ds = null;
            try
            {
                openConnect();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.CommandTimeout = 1000;
                ds = new DataSet();
                da.Fill(ds);
                closeConnect();
            }
            catch (Exception)
            {
                throw;
            }
            finally { conn.Close(); }
            return ds;
        }
        private int execNonQuery(string sql)
        {
            int ret = 0;
            try
            {
                openConnect();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = 500;
                ret = cmd.ExecuteNonQuery();
                closeConnect();
            }
            catch
            {
                //throw;
            }
            return ret;
        }
        public long getServerDate()
        {
            DataTable dt = execQuery("select datediff(s,'1970-1-1', getdate())").Tables[0];
            return long.Parse(dt.Rows[0][0].ToString());
        }
        public string getServerStringDate()
        {
            DataTable dt = execQuery("select GETDATE() AS [DateTime]").Tables[0];
            return dt.Rows[0][0].ToString();
        }
        
        public string Login(string username, string password)
        {
            try
            {
                DataTable dt = execQuery("select top 1 username from [User] where username = '" + username.Replace("'", "''") + "' and password = '" + password.Replace("'", "''") + "' and status='1'").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0][0].ToString();
                }
                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        public DataTable GetAgentPartner(string PartnerName, string type)
        {
            return execQuery("select * from AgentList where PartnerName ='" + PartnerName + "' and type='" + type + "' and status='" + 1 + "'").Tables[0];
        }
        public DataTable GetAgent(string type)
        {
            return execQuery("select * from AgentList where type='" + type + "' and status='" + 1 + "'").Tables[0];
        }
        
        public void UpdateAccBet()
        {
            try
            {
                da.Update(ds, "AccBet");
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public int InsertAgent(string str_insert, int reset = 0)
        {
            string type = str_insert.Split('/')[0];
            string username = str_insert.Split('/')[1];
            string usd = str_insert.Split('/')[2];
            string com = str_insert.Split('/')[3];
            string status = str_insert.Split('/')[4];
            string PartnerName = str_insert.Split('/')[5];
            string sql = string.Format("'{0}', '{1}', {2}, '{3}', '{4}', '{5}'", type,username, usd, com, status, PartnerName);
            if (reset == 1)
            {
                execNonQuery("DELETE FROM AgentList");
                execNonQuery("DBCC CHECKIDENT (AgentList, RESEED, 0)");
            }
            return execNonQuery(@"INSERT INTO [AgentList] ([type],[username],[usd],[com],[status],[PartnerName]) 
                                VALUES (" + sql + ")");
        }
        public bool DeleteTicket()
        {
            execNonQuery("DELETE FROM DataBetList");
            return true;
        }
    }
}
