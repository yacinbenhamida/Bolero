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
    class ServeurDAO : DAO<Serveur>
    {
        public int delete(int id)
        {
            int res = 0;
            SqlConnection cnx = Connexion.GetConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("delete from Serveur where  IdServeur=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", id);
                res = sqlCmd.ExecuteNonQuery();
                if (res > 0)
                {

                    res = 1;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connexion.closeConnection();

            }
            return res;
        }
        public Serveur getById(int id)
        {
            Serveur s = null;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("select * from Serveur where IdServeur=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", id);
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
        public int add(Serveur s)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into Serveur (nom_serveur) values (@nom)", cnx);
                sqlCmd.Parameters.AddWithValue("nom", s.Nom_Serveur);
                sqlCmd.ExecuteNonQuery();
                res = 1;
            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                Connexion.closeConnection();
            }
            return res;
        }
        public int update(Serveur obj)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("Select * from Serveur where IdServeur=@id", cnx);
                cmd.Parameters.AddWithValue("id", obj.IdServeur);
                SqlDataReader rd = cmd.ExecuteReader();

            }
            catch (SqlException ex) { throw ex; }
            finally { Connexion.closeConnection(); }
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Serveur SET nom_serveur=@nom", cnx);
                cmd.Parameters.AddWithValue("nom", obj.Nom_Serveur);
                int done = (int)cmd.ExecuteNonQuery();
                if (done > 0)
                    res = 1;
            }
            catch (SqlException)
            {

                throw;
            }
            finally { Connexion.closeConnection(); }
            return res;
        }
        public bool find(Serveur s)
        {
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            bool res = false;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Serveur where IdServeur=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", s.IdServeur);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {

                    res = true;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return res;
        }
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
                sqlCmd.Parameters.AddWithValue("nom",nom);
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
