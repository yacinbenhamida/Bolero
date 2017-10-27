using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolero.BL;
using System.Data.SqlClient;
namespace Bolero.DAL
{
    class CommandeDAO : DAO<Commande>
    {
        public int add(Commande e)
        {
            //TODO
            throw new NotImplementedException();
        }

        public int delete(int id)
        {
            //TODO
            throw new NotImplementedException();
        }

        public bool find(Commande e)
        {
            //TODO
            throw new NotImplementedException();
        }

        public List<Commande> getAll()
        {
           //TODO
            throw new NotImplementedException();
        }

        public Commande getById(int id)
        {
           //TODO
            throw new NotImplementedException();
        }

        public int update(Commande obj)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Commande SET NumTable=@num,DateCommande=@date,IdArticle=@ida,NomServeur=@nomserv,Id=@id where IdCommande=@idcmd", cnx);
                cmd.Parameters.AddWithValue("num",obj.NumTable );
                cmd.Parameters.AddWithValue("date", obj.DateCommande);
                cmd.Parameters.AddWithValue("ida", obj.IdArticle);
                cmd.Parameters.AddWithValue("nomserv", obj.NomServeur);
                cmd.Parameters.AddWithValue("id", obj.Id);
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
    }
}
