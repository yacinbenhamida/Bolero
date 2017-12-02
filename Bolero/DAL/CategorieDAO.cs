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
    class CategorieDAO : DAO<Categorie>
    {
        public Categorie getById(int id)
        {
            Categorie c = null;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("select * from Categorie where IdCat=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", id);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    c = new Categorie(reader.GetInt32(0), reader.GetString(1));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }
            return c;
        }
        public int delete(int id)
        {
            int res = 0;
            SqlConnection cnx = Connexion.GetConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("delete from Categorie where  IdCat=@id", cnx);
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
        
        public int add(Categorie c)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into Serveur (libelleCat) values (@lib)", cnx);
                sqlCmd.Parameters.AddWithValue("lib", c.libCatg);
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
        public int update(Categorie obj)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("Select * from Categorie where IdCat=@id", cnx);
                cmd.Parameters.AddWithValue("id", obj.idcatg);
                SqlDataReader rd = cmd.ExecuteReader();

            }
            catch (SqlException ex) { throw ex; }
            finally { Connexion.closeConnection(); }
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Serveur SET libelleCat=@lib", cnx);
                cmd.Parameters.AddWithValue("lib", obj.libCatg);
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
        public bool find(Categorie c)
        {
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            bool res = false;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Categorie where IdCat=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", c.idcatg);
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
        public List<Categorie> getAll()
        {

            List<Categorie> list = new List<Categorie>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Categorie", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Categorie(reader.GetInt32(0), reader.GetString(1)));
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

        public int getIdByLib(String lib)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("select IdCat from Categorie where libelleCat=@lib", cnx);
                sqlCmd.Parameters.AddWithValue("lib", lib);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        res = reader.GetInt32(0);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }
            return res;
        }
    }
}
