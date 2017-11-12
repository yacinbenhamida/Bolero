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
        public int addMultipleArticlesInOneC(List<Article> lst,Commande e) 
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand UpdateTable = null;
                SqlCommand sqlCmd = null;
                SqlCommand insertJointure = null;
                 int b = 0;
                 int j = 0;
                 int d = 0;
                  sqlCmd = new SqlCommand("insert into Commande (IdCommande,NumTable,DateCommande,NomServeur,Id) values (@idCom,@numt,@Dc,@noms,@id)", cnx);
                    UpdateTable = new SqlCommand("UPDATE Tables SET Etat='true' where NumTable=@num", cnx);
                    sqlCmd.Parameters.AddWithValue("idCom", e.IdCommande);
                    sqlCmd.Parameters.AddWithValue("numt", e.NumTable);
                    sqlCmd.Parameters.AddWithValue("Dc", e.DateCommande);
                    sqlCmd.Parameters.AddWithValue("noms", e.NomServeur);
                    sqlCmd.Parameters.AddWithValue("id", e.Id);                   
                    UpdateTable.Parameters.AddWithValue("num", e.NumTable);
                    b = (int)UpdateTable.ExecuteNonQuery();
                    j = (int)sqlCmd.ExecuteNonQuery();
                    for (int i = 0; i < lst.Count; i++)
                    {   
                        insertJointure= new SqlCommand("insert into lignecmd(numcmd,numarticle) VALUES (@numcd,@numar)",cnx);
                        insertJointure.Parameters.AddWithValue("numcd", e.IdCommande);
                        insertJointure.Parameters.AddWithValue("numar", lst[i].IdArticle);
                    d = (int)insertJointure.ExecuteNonQuery();
                    }
                if (b > 0 && j > 0 && d>0)
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
        // table occupee = true
        // table vide = false
       public int add(Commande e)
        {
                       int res = 0;

            try{
             SqlConnection cnx = Connexion.GetConnection();
             SqlCommand sqlCmd = new SqlCommand("insert into Commande (IdCommande,NumTable,DateCommande,NomServeur,Id) values (@idCom,@numt,@Dc,@noms,@id)", cnx);
             
              SqlCommand UpdateTable = new SqlCommand("UPDATE Tables SET Etat='true' where NumTable=@num",cnx);
             sqlCmd.Parameters.AddWithValue("idCom",e.IdCommande );
             sqlCmd.Parameters.AddWithValue("numt", e.NumTable);
             sqlCmd.Parameters.AddWithValue("Dc", e.DateCommande);
             //sqlCmd.Parameters.AddWithValue("idArt",e.IdArticle );
             sqlCmd.Parameters.AddWithValue("noms", e.NomServeur);
             sqlCmd.Parameters.AddWithValue("id",e.Id);
             UpdateTable.Parameters.AddWithValue("num", e.NumTable);
             int i = (int)UpdateTable.ExecuteNonQuery();
             int j = (int)sqlCmd.ExecuteNonQuery();
                if(i>0 && j>0)
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

        public int delete(int id)
        {
            int res = 0;
            SqlConnection cnx = Connexion.GetConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("delete from Commande where  IdCommande=@id", cnx);
                SqlCommand UpdateTable = new SqlCommand("UPDATE Table SET Etat=false where NumTable=@id",cnx);
                sqlCmd.Parameters.AddWithValue("id", id);
                UpdateTable.Parameters.AddWithValue("NumTable",id);
                int res1 =(int) UpdateTable.ExecuteNonQuery();
                int res2 =(int) sqlCmd.ExecuteNonQuery();
                if (res1 > 0 && res2>0)
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

        public bool find(Commande e)
        {
            //TODO
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            bool res = false;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Commande where IdCommande=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", e.IdCommande);
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

        public List<Commande> getAll()
        {
           //TODO
            List<Commande> list = new List<Commande>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Commande", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Commande(reader.GetInt32(1),reader.GetDateTime(2),reader.GetString(3),reader.GetInt32(4)));
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

        public Commande getById(int id)
        {
           //TODO
            Commande a = null;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("select * from Commande where IdCommande=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", id);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    a =new Commande(reader.GetInt32(1), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(4));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }
            return a;
        }

        public int update(Commande obj)
        {          
           int res = 0;
            try
            { 
                SqlConnection cnx = Connexion.GetConnection();         
                TableDAO daot = new TableDAO();
                if(daot.checkIfEmpty(obj.NumTable))
                {
                    SqlCommand getOldTable = new SqlCommand("SELECT NumTable From Commande where idCommande=@idc",cnx);
                    getOldTable.Parameters.AddWithValue("idc",obj.IdCommande);
                    int numtableold =(int) getOldTable.ExecuteScalar();
                    SqlCommand updatOldTable = new SqlCommand("UPDATE Table SET Etat=false where NumTable=@ntb",cnx);
                    updatOldTable.Parameters.AddWithValue("ntb",numtableold);
                    int executeQ =(int) updatOldTable.ExecuteScalar();
                    SqlCommand cmd = new SqlCommand("UPDATE Commande SET NumTable=@numtb,DateCommande=@dtc,NomServeur=@nomserv where IdCommande=@idc", cnx);
                    SqlCommand UpdateTable = new SqlCommand("UPDATE Table SET Etat=true where NumTable=@idt",cnx);
                    UpdateTable.Parameters.AddWithValue("idt",obj.NumTable);
                    cmd.Parameters.AddWithValue("numtb", obj.IdCommande);
                    cmd.Parameters.AddWithValue("dtc", obj.DateCommande);
                  //  cmd.Parameters.AddWithValue("idartc", obj.IdArticle);
                    cmd.Parameters.AddWithValue("nomserv", obj.NomServeur);
                    cmd.Parameters.AddWithValue("idc",obj.IdCommande);
                    int done1 =(int) UpdateTable.ExecuteNonQuery();
                    int done = (int)cmd.ExecuteNonQuery();
                    if (done > 0 && done1>0)  res = 1;
                }
                
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

