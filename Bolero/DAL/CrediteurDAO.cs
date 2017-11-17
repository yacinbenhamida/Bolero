using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Documents;
using Bolero.BL;

namespace Bolero.DAL
{
    class CrediteurDAO: DAO<Crediteur>
    {
        public int add(Crediteur c)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into crediteur (IdCrediteur, NomPrenom, CIN , Numtel, Adresse, MontantCredit) values (@idc,@nomprenom,@cin,@adresse,@ntel,@MontC)", cnx);
                sqlCmd.Parameters.AddWithValue("idc", c.idCrediteur);
                sqlCmd.Parameters.AddWithValue("nomprenom", c.nomprenom);
                sqlCmd.Parameters.AddWithValue("cin", c.cin);
                sqlCmd.Parameters.AddWithValue("ntel",c.tel );
                sqlCmd.Parameters.AddWithValue("adresse", c.adresse);
                sqlCmd.Parameters.AddWithValue("MontC", c.MontantCredit);
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


        public int delete(int id)
        {
            int res = 0;
            SqlConnection cnx = Connexion.GetConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("delete from crediteur where  IdCrediteur=@id", cnx);
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


        public int update(Crediteur crd)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE crediteur SET NomPrenom=@nomprenom,CIN=@cin,Numtel=@numt,Adresse=@adresse,MontantCredit=@montC where IdCrediteur=@id", cnx);
                cmd.Parameters.AddWithValue("id", crd.idCrediteur);
                cmd.Parameters.AddWithValue("nomprenom", crd.nomprenom);
                cmd.Parameters.AddWithValue("cin", crd.cin);
                cmd.Parameters.AddWithValue("numt",crd.tel);
                cmd.Parameters.AddWithValue("adresse", crd.adresse);
                cmd.Parameters.AddWithValue("MontC", crd.MontantCredit);
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


        public List<Crediteur> getAll()
        {

            List<Crediteur> listc = new List<Crediteur>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from crediteur", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listc.Add(new Crediteur(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3),reader.GetString(4),reader.GetFloat(5)));
                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }


            return listc;
        }

        public bool find(Crediteur c)
        {
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            bool res = false;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from crediteur where IdCrediteur=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id",c.idCrediteur);
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

    }
}
