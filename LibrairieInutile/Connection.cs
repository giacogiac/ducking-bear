using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataLib
{
    public class Connection
    {
        private SqlConnection sqlCon;

        public Connection(String server, String database)
        {
            String connectionStr = "Server=" + server
                + ";Database=" + database + ";Integrated Security=true;";
            sqlCon = new SqlConnection(connectionStr);
            Console.WriteLine("connected to database");
        }

        public User getUser(String userId)
        {
            return new User(0);
        }
       
        public SqlConnection getSqlCon()
        {
           return sqlCon; 
        }
        public List<User> getAllUsers()
        {
            return new List<User>();
        }
    }
}
