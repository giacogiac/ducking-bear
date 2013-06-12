using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataLib
{
    public class User
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
                ajoutAlbum.ExecuteNonQuery();
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

        public void removeAlbum(String albumid)
        {
            try
            {
                Album a = getAlbum(albumid);
                foreach (String i in a.getAllImages())
                {
                    a.removeImage(i);
                }
                // connexion au serveur
                conn.Open();

                // construit la requête
                SqlCommand delAlbum = new SqlCommand(
                "DELETE FROM ALBUM WHERE userid=@userid AND albumid=@albumid", conn);
                delAlbum.Parameters.Add("@userid", SqlDbType.VarChar, userid.Length).Value
                = userid;
                delAlbum.Parameters.Add("@albumid", SqlDbType.VarChar, albumid.Length).Value
                = albumid;

                // execution de la requête
                delAlbum.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur a removeAlbum avec userid, albumid : " + userid + "," + albumid);
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                // dans tous les cas on ferme la connexion
                conn.Close();
            }
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

        public List<Album> getAllAlbums()
        {
            List<Album> lista = new List<Album>();
            try
            {
                // connexion au serveur
                conn.Open();

                // connexion au serveur
                SqlCommand selectAlbum = new SqlCommand(
                    "SELECT albumid " +
                    "FROM ALBUM " +
                    "WHERE userid = @userid ", conn);
                selectAlbum.Parameters.Add("@userid", SqlDbType.VarChar, userid.Length).Value = userid;

                // exécution de la requête et création du reader
                SqlDataReader myReader =
                selectAlbum.ExecuteReader(CommandBehavior.SequentialAccess);
                while (myReader.Read())
                {
                    lista.Add(new Album(conn, userid, myReader.GetString(0)));
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
            return lista;
        }

        public Boolean auth(String passw)
        {
            Boolean a = false;
            try
            {
                // connexion au serveur
                conn.Open();

                // connexion au serveur
                SqlCommand selectPw = new SqlCommand(
                    "SELECT usrpw " +
                    "FROM [USER] " +
                    "WHERE userid = @userid", conn);
                selectPw.Parameters.Add("@userid", SqlDbType.VarChar, userid.Length).Value = userid;

                // exécution de la requête et création du reader
                SqlDataReader myReader =
                selectPw.ExecuteReader(CommandBehavior.SequentialAccess);
                if (myReader.Read())
                {
                    a = passw.Equals(myReader.GetString(0));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur a auth avec userid : " + userid);
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return a;
        }

        public String getUserId()
        {
            return userid;
        }

    }
}
