using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataLib
{
    public class User
    {
        private SqlConnection sqlCon;
        private int id;

        public User(int userId, SqlConnection con)
        {
            sqlCon = con;
            id = userId;
        }
    }
}
