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
    class TicketDAO:DAO<Ticket>
    {

        public int add(Ticket t)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into Ticket (IdTicketResto,somme,date,nomSociete) values (@idt,@som,@dat,@ns)", cnx);
                sqlCmd.Parameters.AddWithValue("idt",t.IdTicketResto );
                sqlCmd.Parameters.AddWithValue("som",t.somme );
                sqlCmd.Parameters.AddWithValue("dat", t.date);
                sqlCmd.Parameters.AddWithValue("ns",t.nomSociete );
                
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
                SqlCommand sqlCmd = new SqlCommand("delete from Ticket where  IdTicketResto=@id", cnx);
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



        public int update(Ticket t)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Ticket SET somme=@som,date=@dat,nomSociete=@ns where IdTicketResto=@idt", cnx);
                cmd.Parameters.AddWithValue("idt",t.IdTicketResto );
                cmd.Parameters.AddWithValue("som",t.somme );
                cmd.Parameters.AddWithValue("dat", t.date);
                cmd.Parameters.AddWithValue("ns", t.nomSociete);
               
            }
            catch (SqlException)
            {

                throw;
            }
            finally { Connexion.closeConnection(); }
            return res;
        }



        public List<Ticket> getAll()
        {

            List<Ticket> listeT = new List<Ticket>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Ticket", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listeT.Add(new Ticket(reader.GetInt32(0), reader.GetFloat(1), reader.GetDateTime(2),reader.GetString(3));
                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }


            return listeT;
        }
    }
}
