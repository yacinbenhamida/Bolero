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
    class ArchiveDAO:DAO<Archive>
    {

        public int add(Archive a)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into ArchiveCommande (IdCommande,NumTable,DateCommande,NomServeur,caissier,sumprix) values (@idCom,@numt,@Dc,@noms,@cas,@sp)", cnx);
                 sqlCmd.Parameters.AddWithValue("idCom",a.idCommande );
             sqlCmd.Parameters.AddWithValue("numt",a.numTable );
             sqlCmd.Parameters.AddWithValue("Dc",a.Datecommande );
             sqlCmd.Parameters.AddWithValue("noms",a.nomServeur );
             sqlCmd.Parameters.AddWithValue("cas",a.caissier);
             sqlCmd.Parameters.AddWithValue("sp",a.sumprix);
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
                SqlCommand sqlCmd = new SqlCommand("delete from ArchiveCommande where  IdCommande=@id", cnx);
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


        public int update(Archive arc)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE ArchiveCommande SET NumTable=@numt,DateCommande=@Dc,NomServeur=@noms,caissier=@cas,sumprix=@sp where IdCommande=@idc", cnx);
                cmd.Parameters.AddWithValue("idc",arc.idCommande );
                cmd.Parameters.AddWithValue("numt",arc.numTable );
                cmd.Parameters.AddWithValue("Dc",arc.Datecommande );
                cmd.Parameters.AddWithValue("noms",arc.nomServeur );
                cmd.Parameters.AddWithValue("cas",arc.caissier );
                cmd.Parameters.AddWithValue("sp",arc.sumprix );

            }
            catch (SqlException)
            {

                throw;
            }
            finally { Connexion.closeConnection(); }
            return res;
        }




        public List<Archive> getAll()
        {

            List<Archive> listarc = new List<Archive>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from ArchiveCommande", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listarc.Add(new Archive(reader.GetInt32(0),reader.GetInt32(1),reader.GetDateTime(2),reader.GetString(3),reader.GetString(4),reader.GetFloat(5)));
                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }


            return listarc;
        }
    }
}
