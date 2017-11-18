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
                    UpdateTable = new SqlCommand("UPDATE Tables SET Etat='True' where NumTable=@num AND Etat='False'", cnx);
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
                        insertJointure= new SqlCommand("insert into lignecmd(numcmd,numArticle) VALUES (@numcd,@numar)",cnx);
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
           int numtable = 0;
           SqlConnection cnx = Connexion.GetConnection();
           SqlDataReader reader;
           try
           {
               SqlCommand sqlCmd = new SqlCommand("select NumTable from Commande where IdCommande=@id", cnx);
               sqlCmd.Parameters.AddWithValue("id", id);
               reader = sqlCmd.ExecuteReader();
               if (reader.HasRows)
               {
                   while (reader.Read())
                   {
                       numtable = reader.GetInt32(0);
                   }
               }

               reader.Close();
           }
           catch (Exception ex)
           {
               throw ex;
           }

           try
           {
               SqlCommand sqlCmd = new SqlCommand("delete from Commande where IdCommande=@id", cnx);
               SqlCommand UpdateTable = new SqlCommand("UPDATE Tables SET Etat=@etat where NumTable=@NumTable", cnx);
               sqlCmd.Parameters.AddWithValue("id", id);
               UpdateTable.Parameters.AddWithValue("NumTable", numtable);
               UpdateTable.Parameters.AddWithValue("etat", false);
               int res1 = (int)UpdateTable.ExecuteNonQuery();
               int res2 = (int)sqlCmd.ExecuteNonQuery();
               if (res1 > 0 && res2 > 0)
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
                    SqlCommand updatOldTable = new SqlCommand("UPDATE Tables SET Etat=False where NumTable=@ntb",cnx);
                    updatOldTable.Parameters.AddWithValue("ntb",numtableold);
                    int executeQ =(int) updatOldTable.ExecuteScalar();
                    SqlCommand cmd = new SqlCommand("UPDATE Commande SET NumTable=@numtb,DateCommande=@dtc,NomServeur=@nomserv where IdCommande=@idc", cnx);
                    SqlCommand UpdateTable = new SqlCommand("UPDATE Tables SET Etat=True where NumTable=@idt",cnx);
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

        public List<Article> listArticle(int id)
        {

            List<int> lstNumA = new List<int>();
            List<int> lstQte = new List<int>();
            List<Article> lstArticle = new List<Article>();
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd2 = new SqlCommand("SELECT Article.* FROM Article,lignecmd WHERE lignecmd.numcmd=@id AND lignecmd.numArticle=Article.IdArticle", cnx);
                cmd2.Parameters.AddWithValue("id", id);

                SqlDataReader rd2 = cmd2.ExecuteReader();
                if (rd2.HasRows)
                {

                    while (rd2.Read())
                    {
                       lstArticle.Add(new Article(rd2.GetInt32(0),rd2.GetString(1),rd2.GetDecimal(2),rd2.GetString(3)));

                    }
                }
                rd2.Close();
            }
            catch (SqlException) { throw; }

            finally { Connexion.closeConnection(); }
            

            return lstArticle;
        }

        public int updateCommande(Commande obj, int id)
        {
            int res = 0;
            SqlDataReader reader;
            int numtableold = 0;
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                TableDAO daot = new TableDAO();
                if (daot.checkIfEmpty(id))
                {
                    SqlCommand getOldTable = new SqlCommand("SELECT NumTable From Commande where IdCommande=@idc", cnx);
                    getOldTable.Parameters.AddWithValue("idc", id);
                    reader = getOldTable.ExecuteReader();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            numtableold = reader.GetInt32(0);
                        }
                    }

                    reader.Close();
                    SqlCommand updatOldTable = new SqlCommand("UPDATE Tables SET Etat=@etat1 where NumTable=@ntb", cnx);
                    updatOldTable.Parameters.AddWithValue("ntb", numtableold);
                    updatOldTable.Parameters.AddWithValue("etat1", false);
                    int executeQ = (int)updatOldTable.ExecuteScalar();
                    SqlCommand cmd = new SqlCommand("UPDATE Commande SET NumTable=@numtb,DateCommande=@dtc,NomServeur=@nomserv where IdCommande=@idc", cnx);
                    SqlCommand UpdateTable = new SqlCommand("UPDATE Tables SET Etat=@etat2 where NumTable=@idt", cnx);
                    UpdateTable.Parameters.AddWithValue("idt", obj.NumTable);
                    UpdateTable.Parameters.AddWithValue("etat2", true);
                    cmd.Parameters.AddWithValue("numtb", obj.NumTable);
                    cmd.Parameters.AddWithValue("dtc", obj.DateCommande);
                    //  cmd.Parameters.AddWithValue("idartc", obj.IdArticle);
                    cmd.Parameters.AddWithValue("nomserv", obj.NomServeur);
                    cmd.Parameters.AddWithValue("idc", id);
                    int done1 = (int)UpdateTable.ExecuteNonQuery();
                    int done = (int)cmd.ExecuteNonQuery();
                    if (done > 0 && done1 > 0) res = 1;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }
            return res;

        }

        public float total(int idc) {
            float tot = 0;
                       SqlDataReader reader;
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                                SqlCommand gettot = new SqlCommand("SELECT sum(Article.prix) From Commande,Article,lignecmd where IdCommande=@idc  and IdCommande=numcmd and IdArticle=numArticle", cnx);

                                gettot.Parameters.AddWithValue("idc", idc);
                    reader = gettot.ExecuteReader();
                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            tot = reader.GetFloat(0);
                        }
                    }
                        }catch (SqlException) { throw; }

            finally { Connexion.closeConnection(); }
                            return tot;

        }
        }


            
        
        }
       