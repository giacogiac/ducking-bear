using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataLib
{
    public class Album
    {
        int id;
        int user;
        
        public Album(int albumId, int userId)
        {
            this.id = albumId;
            this.user = userId;
        }
    }
}
