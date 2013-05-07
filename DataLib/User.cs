using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataLib
{
    class User
    {
        private SqlConnection conn;
        private String userid;

        public User(SqlConnection conn, String userid)
        {
            this.conn = conn;
            this.userid = userid;
        }

        public Album addAlbum (String albumid)
        {
            try
            {
                // connexion au serveur
                conn.Open();

                // construit la requête
                SqlCommand ajoutAlbum = new SqlCommand(
                "INSERT INTO ALBUM (userid, albumid) " +
                "VALUES(@userid, @albumid)", conn);
                ajoutAlbum.Parameters.Add("@userid", SqlDbType.VarChar, userid.Length).Value
                = userid;
                ajoutAlbum.Parameters.Add("@albumid", SqlDbType.VarChar, albumid.Length).Value
                = albumid;
                
                // execution de la requête
                ajoutUser.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur a addAlbum avec userid, albumid : " + userid + "," + albumid);
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                // dans tous les cas on ferme la connexion
                conn.Close();
            }
            return new Album(conn, userid, albumid);
        }

        public Album getAlbum(String albumid)
        {
            Album a = null;
            try
            {
                // connexion au serveur
                conn.Open();

                // connexion au serveur
                SqlCommand selectAlbum = new SqlCommand(
                    "SELECT userid, albumid " +
                    "FROM ALBUM " +
                    "WHERE userid = @userid " +
                    "AND albumid = @albumid", conn);
                selectAlbum.Parameters.Add("@userid", SqlDbType.VarChar, userid.Length).Value = userid;
                selectAlbum.Parameters.Add("@albumid", SqlDbType.VarChar, albumid.Length).Value = albumid;

                // exécution de la requête et création du reader
                SqlDataReader myReader =
                selectAlbum.ExecuteReader(CommandBehavior.SequentialAccess);
                if (myReader.Read())
                {
                    a = new Album(conn, userid, albumid);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur a getalbum avec userid, albumid : " + userid + "," + albumid);
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return a;
        }

        public Album getAllAlbums()
        {
            Album a = null;
            try
            {
                // connexion au serveur
                conn.Open();

                // connexion au serveur
                SqlCommand selectAlbum = new SqlCommand(
                    "SELECT userid, albumid " +
                    "FROM ALBUM " +
                    "WHERE userid = @userid ", conn);
                selectAlbum.Parameters.Add("@userid", SqlDbType.VarChar, userid.Length).Value = userid;

                // exécution de la requête et création du reader
                SqlDataReader myReader =
                selectAlbum.ExecuteReader(CommandBehavior.SequentialAccess);
                while (myReader.Read())
                {
                    a = new Album(conn, userid, myReader.GetString(1));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur a getAllAlbums avec userid : " + userid);
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return a;
        }

    }
}
