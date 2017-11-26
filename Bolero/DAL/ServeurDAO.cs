using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolero.BL;
using System.Data.SqlClient;
using System.Windows.Documents;

namespace Bolero.DAL
{
    class ServeurDAO : DAO <Serveur>
    {
        public List<Serveur> getAll()
        {

            List<Serveur> list = new List<Serveur>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Serveur", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Serveur(reader.GetInt32(0), reader.GetString(1)));
                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }


            return list;
        }

        public Serveur getByName(String nom)
        {
            Serveur s = null;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("select * from Serveur where nom_serveur=@nom", cnx);
                sqlCmd.Parameters.AddWithValue("nom", nom);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    s = new Serveur(reader.GetInt32(0), reader.GetString(1));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }
            return s;
        }
    }
}
