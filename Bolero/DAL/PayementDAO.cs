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
    class PayementDAO : DAO<Payement>
    {
        public int delete(int id)
        {
            int res = 0;
            SqlConnection cnx = Connexion.GetConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("delete from Payement where  IdPayement=@id", cnx);
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
        public Payement getById(int id)
        {
            Payement p = null;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("select * from Payement where idCmd=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", id);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    p = new Payement(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }
            return p;
        }
        public int addesp(Payement p)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into Payement (idCmd) values (@cmd)", cnx);
              
                sqlCmd.Parameters.AddWithValue("cmd", p.idcmd);
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
        public int add(Payement p)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into Payement (idTicketResto,idCheque,idCmd) values (@tk,@chq,@cmd)", cnx);
                sqlCmd.Parameters.AddWithValue("tk", p.idticket);
                sqlCmd.Parameters.AddWithValue("chq", p.idcheque);
                sqlCmd.Parameters.AddWithValue("cmd", p.idcmd);
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
        public int addPayTicket(Payement p)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into Payement (idTicketResto,idCmd) values (@tk,@cmd)", cnx);
                sqlCmd.Parameters.AddWithValue("tk", p.idticket);

                sqlCmd.Parameters.AddWithValue("cmd", p.idcmd);
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
        public int addPaycheque(Payement p)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into Payement (idCheque,idCmd) values (@tk,@cmd)", cnx);
                sqlCmd.Parameters.AddWithValue("tk", p.idcheque);
                sqlCmd.Parameters.AddWithValue("cmd", p.idcmd);
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
        public int update(Payement obj)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("Select * from Payement where IdPayement=@id", cnx);
                cmd.Parameters.AddWithValue("id", obj.id);
                SqlDataReader rd = cmd.ExecuteReader();

            }
            catch (SqlException ex) { throw ex; }
            finally { Connexion.closeConnection(); }
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Payement SET idTicket=@tk,idCheque=@chq,idCmd=@cmd", cnx);
                cmd.Parameters.AddWithValue("tk", obj.idticket);
                cmd.Parameters.AddWithValue("chq", obj.idcheque);
                cmd.Parameters.AddWithValue("cmd", obj.idcmd);
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
        public bool find(Payement s)
        {
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            bool res = false;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Payement where IdPayement=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", s.id);
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
        public List<Payement> getAll()
        {

            List<Payement> list = new List<Payement>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Payement", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Payement(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3)));
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


    }
}
