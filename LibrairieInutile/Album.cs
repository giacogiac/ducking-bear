using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DataLib
{
    class Album
    {
        int id;
        User owner;

        public Album(int albumId, User owner)
        {
            id = albumId;
            this.owner = owner;
        }

        public void addImage(String imageID, byte[] image)
        {
            try
            {
                // connexion au serveur
                sqlCon.Open();
                // construit la requête
                SqlCommand ajoutImage = new SqlCommand(
                "INSERT INTO Image (id, blob, size, album) " +
                "VALUES(@id, @blob, @size, @album)", sqlCon);
                ajoutImage.Parameters.Add("@id", SqlDbType.VarChar, imageID.Length).Value
                = imageID;
                ajoutImage.Parameters.Add("@blob", SqlDbType.Image, image.Length).Value
                = image;
                ajoutImage.Parameters.Add("@size", SqlDbType.Int).Value = image.Length;
                ajoutImage.Parameters.Add("@album", SqlDbType.Int).Value = 0;
                // execution de la requête
                ajoutImage.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur :" + e.Message);
            }
            finally
            {
                // dans tous les cas on ferme la connexion
                sqlCon.Close();
            }
        }

        public byte[] getImage(String imageID)
        {
            byte[] blob = null;
            try
            {
                // connexion au serveur
                sqlCon.Open();
                // construit la requête
                SqlCommand getImage = new SqlCommand(
                "SELECT id,size, blob " +
                "FROM Image " +
                "WHERE id = @id", sqlCon);
                getImage.Parameters.Add("@id", SqlDbType.VarChar, imageID.Length).Value =
                imageID;
                // exécution de la requête et création du reader
                SqlDataReader myReader =
                getImage.ExecuteReader(CommandBehavior.SequentialAccess);
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
                Console.WriteLine("Erreur :" + e.Message);
            }
            finally
            {
                // dans tous les cas on ferme la connexion
                sqlCon.Close();
            }
            return blob;
        }
    }
}
