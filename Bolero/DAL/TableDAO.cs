using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolero.BL;
using System.Data.SqlClient;
namespace Bolero.DAL
{
    class TableDAO 

    {


        public int update(int id, bool etat)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Tables SET Etat=@etat where NumTable=@id", cnx);
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("etat", etat);

                int done = (int)cmd.ExecuteNonQuery();
                if (done > 0) res = 1;
            }
            catch (SqlException)
            {

                throw;
            }
            finally { Connexion.closeConnection(); }
            return res;
        }
        public List<Table> getAllTableDispo() 
        {
            List<Table> list = new List<Table>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Tables where Etat=false", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Table(reader.GetInt32(0), reader.GetBoolean(1)));
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
        public bool checkIfEmpty(int id)
        {
            Boolean etat = false;
            bool clean = false;
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("select Etat from Tables where NumTable=@numt", cnx);
                sqlCmd.Parameters.AddWithValue("numt", id);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read()) 
                    {
                        etat = reader.GetBoolean(0);
                    }
                }

                reader.Close();
                if (etat == false) 
                {
                    clean = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return clean;
        }



        public List<Table> getAll()
        {

            List<Table> listT = new List<Table>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Table", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listT.Add(new Table(reader.GetInt32(0), reader.GetBoolean(1)));
                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }


            return listT;
        }

        public bool checkAllEtat(int idTable)
        {
            Boolean etat = false;

            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("SELECT Etat FROM Tables WHERE NumTable=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", idTable);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        etat = reader.GetBoolean(0);
                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }


            return etat;
        }

    }
}
