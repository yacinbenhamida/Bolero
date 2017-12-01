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
    class FactureDao : DAO<Facture>
    {
        public int getlastfct()
        {
            int c= 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("select MAX(IdFact) from Facture", cnx);


                c = (int)sqlCmd.ExecuteScalar();
                
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }
            return c;
        }
        public Facture getById(int id)
        {
            Facture c = null; 

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("select * from Facture where IdFact=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", id);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    c = new Facture(reader.GetInt32(0), reader.GetDecimal(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4));
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
        public int add(Facture f)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                CommandeDAO cmddao = new CommandeDAO();

                SqlCommand sqlCmd = new SqlCommand("insert into Facture ( totalTTC,totalHT,totalTVA) values (@ttc,@ht,@tva)", cnx);
                
                sqlCmd.Parameters.AddWithValue("ttc", f.totalTTC);
                sqlCmd.Parameters.AddWithValue("ht", f.totalHT);
                sqlCmd.Parameters.AddWithValue("tva", f.totalTVA);

                res = sqlCmd.ExecuteNonQuery();

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
                SqlCommand sqlCmd = new SqlCommand("delete from Facture where  IdFact=@id", cnx);
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


        public int update(Facture fact)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Facture SET totalTTC=@ttc,totalHT=@ht,totalTVA=@tva,IdPayement=@idpay where IDFact=@id", cnx);
                cmd.Parameters.AddWithValue("ttx", fact.totalTTC);
                cmd.Parameters.AddWithValue("ht", fact.totalHT);
                cmd.Parameters.AddWithValue("tva", fact.totalTVA);
                cmd.Parameters.AddWithValue("idpay", fact.Idpayement);
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


        public List<Facture> getAll()
        {

            List<Facture> listc = new List<Facture>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Facture", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listc.Add(new Facture(reader.GetInt32(0), reader.GetDecimal(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4)));
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

        public bool find(Facture f)
        {
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            bool res = false;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Client_Crediteurs where IdCrediteur=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", f.IdFact);
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
