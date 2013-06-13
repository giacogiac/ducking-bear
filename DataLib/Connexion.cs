using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataLib
{
    public class Connexion
    {
        public const String SERVER = "X064";
        public const String DATABASE = "ducking_bear_db";

        private SqlConnection conn;

        public Connexion()
        {
            conn = new SqlConnection("Server=" + SERVER + ";Database=" + DATABASE + ";Integrated Security=true;");
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur a la création de la Connexion:" + e.Message);
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public User addUser(String userid, String userpw, String role)
        {
            try
            {
                // connexion au serveur
                conn.Open();

                // construit la requête
                SqlCommand ajoutUser = new SqlCommand(
                "INSERT INTO [USER] (userid, usrpw, role) " +
                "VALUES(@userid, @userpw, @role)", conn);
                ajoutUser.Parameters.Add("@userid", SqlDbType.VarChar, userid.Length).Value
                = userid;
                ajoutUser.Parameters.Add("@userpw", SqlDbType.VarChar, userpw.Length).Value
                = userpw;
                ajoutUser.Parameters.Add("@role", SqlDbType.VarChar, role.Length).Value
                = role;
                
                // execution de la requête
                ajoutUser.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur a addUser avec userid :" + userid);
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                // dans tous les cas on ferme la connexion
                conn.Close();
            }
            return new User(conn, userid);
        }

        public void removeUser(String userid)
        {
            try
            {
                User u = getUser(userid);
                foreach (Album a in u.getAllAlbums())
                {
                    u.removeAlbum(a.getAlbumId());
                }
                // connexion au serveur
                conn.Open();

                // construit la requête
                SqlCommand delUser = new SqlCommand(
                "DELETE FROM [USER] WHERE userid=@userid", conn);
                delUser.Parameters.Add("@userid", SqlDbType.VarChar, userid.Length).Value
                = userid;

                // execution de la requête
                delUser.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur a addUser avec userid :" + userid);
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                // dans tous les cas on ferme la connexion
                conn.Close();
            }
        }

        public User getUser(String userid)
        {
            User u = null;
            try
            {
                // connexion au serveur
                conn.Open();

                // connexion au serveur
                SqlCommand selectUser = new SqlCommand(
                    "SELECT * " +
                    "FROM [USER] " +
                    "WHERE userid = @userid", conn);
                selectUser.Parameters.Add("@userid", SqlDbType.VarChar, userid.Length).Value = userid;

                // exécution de la requête et création du reader
                SqlDataReader myReader =
                selectUser.ExecuteReader(CommandBehavior.SequentialAccess);
                if (myReader.Read())
                {
                    u = new User(conn, userid);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur a getUser avec userid :"+ userid);
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return u;
        }

        public List<User> getAllUsers()
        {
            List<User> lstu = new List<User>();
            try
            {
                // connexion au serveur
                conn.Open();

                // connexion au serveur
                SqlCommand selectUser = new SqlCommand(
                    "SELECT userid " +
                    "FROM [USER]" , conn);

                // exécution de la requête et création du reader
                SqlDataReader myReader =
                selectUser.ExecuteReader(CommandBehavior.SequentialAccess);
                while (myReader.Read())
                {
                    lstu.Add(new User(conn, myReader.GetString(0)));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur a getAllUser :" + e.Message);
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return lstu;
        }

    }
}
