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
        private SqlConnection conn;
        private String userid;
        private String albumid;

        public Album(SqlConnection conn, String userid, String albumid)
        {
            this.conn = conn;
            this.userid = userid;
            this.albumid = albumid;
        }

        public void addImage(String imageid, byte[] image)
        {
            try
            {
                // connexion au serveur
                conn.Open();

                // construit la requête
                SqlCommand ajoutImage = new SqlCommand(
                "INSERT INTO PICTURE (userid, albumid, pictureid, size, blob) " +
                "VALUES(@userid, @albumid, @pictureid, @size, @blob)", conn);
                ajoutImage.Parameters.Add("@userid", SqlDbType.VarChar, userid.Length).Value
                = userid;
                ajoutImage.Parameters.Add("@albumid", SqlDbType.VarChar, albumid.Length).Value
                = albumid;
                ajoutImage.Parameters.Add("@pictureid", SqlDbType.VarChar, imageid.Length).Value
                = imageid;
                ajoutImage.Parameters.Add("@size", SqlDbType.Int).Value = image.Length;
                ajoutImage.Parameters.Add("@blob", SqlDbType.Image, image.Length).Value = image;
                

                // execution de la requête
                ajoutImage.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur a addImage avec userid, albumid, imageid : " + userid + "," + albumid + "," + imageid);
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                // dans tous les cas on ferme la connexion
                conn.Close();
            }
        }
        public byte[] getImage(String imageid)
        {
            byte[] blob = null;
            try
            {
                // connexion au serveur
                conn.Open();

                // connexion au serveur
                SqlCommand selectImage = new SqlCommand(
                    "SELECT userid, albumid, pictureid " +
                    "FROM PICTURE " +
                    "WHERE userid = @userid " +
                    "AND albumid = @albumid " +
                    "AND pictureid = @pictureid", conn);
                selectImage.Parameters.Add("@userid", SqlDbType.VarChar, userid.Length).Value = userid;
                selectImage.Parameters.Add("@albumid", SqlDbType.VarChar, albumid.Length).Value = albumid;
                selectImage.Parameters.Add("@pictureid", SqlDbType.VarChar, imageid.Length).Value = imageid;

                // exécution de la requête et création du reader
                SqlDataReader myReader =
                selectImage.ExecuteReader(CommandBehavior.SequentialAccess);
                if (myReader.Read())
                {
                    // lit la taille du blob
                    int size = myReader.GetInt32(1);
                    blob = new byte[size];
                    // récupére le blob de la BDD et le copie dans la variable blob
                    myReader.GetBytes(2, 0, blob, 0, size);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur a getImage avec userid, albumid, imageid : " + userid + "," + albumid + "," + imageid);
                Console.WriteLine(e.Message);
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return blob;
        }
    }
}
