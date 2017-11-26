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
    class ChequeDAO:DAO<Cheque>
    {
        public int add(Cheque c)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into Cheque  (IdCheque,somme,dateCheque,nom_prenomCli,CINcli,RIBcompte,numCheque) values (@idCheque,@som,@datec,@np,@cin,@rib,@numc)", cnx);
                sqlCmd.Parameters.AddWithValue("idCheque",c.IdCheque );
                sqlCmd.Parameters.AddWithValue("som",c.somme );
                sqlCmd.Parameters.AddWithValue("datec",c.dateCheque);
                sqlCmd.Parameters.AddWithValue("np",c.nom_prenomCli);
                sqlCmd.Parameters.AddWithValue("cin",c.CINcli );
                sqlCmd.Parameters.AddWithValue("rib",c.RIBcompte );
                sqlCmd.Parameters.AddWithValue("numc",c.numCheque);
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
                SqlCommand sqlCmd = new SqlCommand("delete from Cheque where  IdCheque=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", id);

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



        public int update(Cheque c)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Cheque SET somme=@som,dateCheque=@datec,nom_prenomCli=@np,CINcli=@cin,RIBcompte=@rib,numCheque=@numc where IdCheque=@idc", cnx);
                cmd.Parameters.AddWithValue("idc", c.IdCheque);
                cmd.Parameters.AddWithValue("som", c.somme);
                cmd.Parameters.AddWithValue("datec", c.dateCheque);
                cmd.Parameters.AddWithValue("np", c.nom_prenomCli);
                cmd.Parameters.AddWithValue("cin", c.CINcli);
                cmd.Parameters.AddWithValue("rib", c.RIBcompte);
                cmd.Parameters.AddWithValue("numc", c.numCheque);
            }
            catch (SqlException)
            {

                throw;
            }
            finally { Connexion.closeConnection(); }
            return res;
        }



        public List<Cheque> getAll()
        {

            List<Cheque> listeCh = new List<Cheque>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Cheque", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listeCh.Add(new Cheque(reader.GetInt32(0), reader.GetFloat(1), reader.GetDateTime(2), reader.GetString(3), reader.GetString(4), reader.GetString(5),reader.GetString(6)));
                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }


            return listeCh;
        }
    }
}
