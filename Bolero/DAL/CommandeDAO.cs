﻿using System;
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
        public int updateEtat(int id)
        {
            int res = 0;
            int numtable = 0;
            SqlConnection cnx = Connexion.GetConnection();

            try
            {

                SqlCommand Updateetat = new SqlCommand("UPDATE Commande SET etatCmd=@etat where IdCommande=@id", cnx);
                Updateetat.Parameters.AddWithValue("id", id);
                Updateetat.Parameters.AddWithValue("NumTable", numtable);
                Updateetat.Parameters.AddWithValue("etat", true);
                int res1 = (int)Updateetat.ExecuteNonQuery();
                if (res1 > 0)
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
        public int updateprix(int id,decimal prixnv)
        {
            int res = 0;
            
            SqlConnection cnx = Connexion.GetConnection();

            try
            {

                SqlCommand Updateetat = new SqlCommand("UPDATE Commande SET prixTotal=@prix where IdCommande=@id", cnx);
                Updateetat.Parameters.AddWithValue("id", id);
                Updateetat.Parameters.AddWithValue("prix",prixnv);
                int res1 = (int)Updateetat.ExecuteNonQuery();
                if (res1 > 0)
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
        public int addMultipleArticlesInOneC(List<Article> lst, Commande e)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand UpdateTable = null;
                SqlCommand sqlCmd = null;
                SqlCommand insertJointure = null;
                SqlCommand findLastInsertedID = null;
                int b = 0;
                int j = 0;
                int d = 0;

                sqlCmd = new SqlCommand("insert into Commande (NumTable,idServeur,idUser,datecommande,etatCmd) values (@numt,@idserveur,@iduser,@date,'False')", cnx);
                UpdateTable = new SqlCommand("UPDATE Tables SET Etat='True' where NumTable=@numt AND Etat='False'", cnx);
                //sqlCmd.Parameters.AddWithValue("idCom", e.IdCommande);
                //sqlCmd.Parameters.AddWithValue("prix",e.prixtotal);
                sqlCmd.Parameters.AddWithValue("numt", e.NumTable);
                sqlCmd.Parameters.AddWithValue("date", e.datecommande);
                sqlCmd.Parameters.AddWithValue("idserveur", e.idserveur);
                sqlCmd.Parameters.AddWithValue("iduser", e.Id);
                UpdateTable.Parameters.AddWithValue("numt", e.NumTable);
                b = (int)UpdateTable.ExecuteNonQuery();
                j = (int)sqlCmd.ExecuteNonQuery();
                int idCommande = 0;

                for (int i = 0; i < lst.Count; i++)
                {
                    findLastInsertedID = new SqlCommand("SELECT IdCommande from Commande", cnx);
                    SqlDataReader rd = findLastInsertedID.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            idCommande = rd.GetInt32(0);
                        }
                    }
                    rd.Close();
                    insertJointure = new SqlCommand("insert into lignecmd(numcmd,numArticle) VALUES (@numcd,@numar)", cnx);
                    insertJointure.Parameters.AddWithValue("numcd", idCommande);
                    insertJointure.Parameters.AddWithValue("numar", lst[i].IdArticle);


                    d = (int)insertJointure.ExecuteNonQuery();
                }
                if (b > 0 && j > 0 && d > 0 && idCommande > 0)
                {
                    res = 1;
                }
                SumCommande(idCommande);

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
            //SqlCommand insertJointure = null;
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into Commande (prixTotal,NumTable,IdServeur,IdUSer,idFacture,datecommande) values (0,@numt,@idserveur,@iduser,@date)", cnx);
                SqlCommand UpdateTable = new SqlCommand("UPDATE Tables SET Etat='True' where NumTable=@num and Etat='False'", cnx);
                sqlCmd.Parameters.AddWithValue("numt", e.NumTable);
                sqlCmd.Parameters.AddWithValue("date", e.datecommande);
                sqlCmd.Parameters.AddWithValue("idserveur", e.idserveur);
                sqlCmd.Parameters.AddWithValue("iduser", e.Id);
                UpdateTable.Parameters.AddWithValue("num", e.NumTable);
                int i = (int)UpdateTable.ExecuteNonQuery();
                int j = (int)sqlCmd.ExecuteNonQuery();
                if (i > 0 && j > 0)
                {
                    res = 1;
                }

                SumCommande(e.IdCommande);

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
        public void SumCommande(int cmd)
        {
            int d = 0;

            SqlCommand insertJointure = null;
            SqlConnection cnx = Connexion.GetConnection();

            try
            {

                SqlCommand sqlCmd = new SqlCommand("Select SUM(Prix) from Article,lignecmd,Commande where (Article.IdArticle=lignecmd.numArticle)and(Commande.IdCommande=lignecmd.numcmd)and(numcmd=@id)", cnx);
                sqlCmd.Parameters.AddWithValue("@id", cmd);
                Decimal res = (decimal)sqlCmd.ExecuteScalar();
                insertJointure = new SqlCommand("update  Commande set prixTotal=@prix where IdCommande=@cmd", cnx);
                insertJointure.Parameters.AddWithValue("prix", res);
                insertJointure.Parameters.AddWithValue("cmd", cmd);
                d = (int)insertJointure.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connexion.closeConnection();

            }

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
                SqlCommand sqlCmd = new SqlCommand("select * from Commande where etatCmd='False'", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Commande(reader.GetInt32(0), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetDateTime(6)));
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
                    a = new Commande(reader.GetInt32(0), reader.GetDecimal(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetDateTime(6));
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
        public int updatefct(Commande obj,int fct)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                TableDAO daot = new TableDAO();
                if (daot.checkIfEmpty(obj.NumTable))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Commande SET idFacture=@fct where IdCommande=@idc", cnx);
                  cmd.Parameters.AddWithValue("fct", fct);
                    cmd.Parameters.AddWithValue("idc", obj.IdCommande);
                   
                    
                    int done = (int)cmd.ExecuteNonQuery();
                    if (done > 0)
                        res = 1;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }
            return res;

        }

        public int update(Commande obj)
        {
            int res = 0;
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                TableDAO daot = new TableDAO();
                if (daot.checkIfEmpty(obj.NumTable))
                {
                    SqlCommand getOldTable = new SqlCommand("SELECT NumTable From Commande where idCommande=@idc", cnx);
                    getOldTable.Parameters.AddWithValue("idc", obj.IdCommande);
                    int numtableold = (int)getOldTable.ExecuteScalar();
                    SqlCommand updatOldTable = new SqlCommand("UPDATE Tables SET Etat=False where NumTable=@ntb", cnx);
                    updatOldTable.Parameters.AddWithValue("ntb", numtableold);
                    int executeQ = (int)updatOldTable.ExecuteScalar();
                    SqlCommand cmd = new SqlCommand("UPDATE Commande SET NumTable=@numtb,datecommande=@dtc,IdServeur=@nomserv where IdCommande=@idc", cnx);
                    SqlCommand UpdateTable = new SqlCommand("UPDATE Tables SET Etat=True where NumTable=@idt", cnx);
                    UpdateTable.Parameters.AddWithValue("idt", obj.NumTable);
                    cmd.Parameters.AddWithValue("numtb", obj.IdCommande);
                    cmd.Parameters.AddWithValue("dtc", obj.datecommande);
                    //  cmd.Parameters.AddWithValue("idartc", obj.IdArticle);
                    cmd.Parameters.AddWithValue("nomserv", obj.idserveur);
                    cmd.Parameters.AddWithValue("idc", obj.IdCommande);
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
                        lstArticle.Add(new Article(rd2.GetInt32(0), rd2.GetString(1), rd2.GetDecimal(2), rd2.GetInt32(3)));

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
                    SqlCommand cmd = new SqlCommand("UPDATE Commande SET NumTable=@numtb,datecommande=@dtc,IdServeur=@nomserv where IdCommande=@idc", cnx);
                    SqlCommand UpdateTable = new SqlCommand("UPDATE Tables SET Etat=@etat2 where NumTable=@idt", cnx);
                    UpdateTable.Parameters.AddWithValue("idt", obj.NumTable);
                    UpdateTable.Parameters.AddWithValue("etat2", true);
                    cmd.Parameters.AddWithValue("numtb", obj.IdCommande);
                    cmd.Parameters.AddWithValue("dtc", obj.datecommande);
                    //  cmd.Parameters.AddWithValue("idartc", obj.IdArticle);
                    cmd.Parameters.AddWithValue("nomserv", obj.idserveur);
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
        public List<Commande> getAllMois()
        {
            //TODO
            List<Commande> list = new List<Commande>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            DateTime now = DateTime.Now;
            decimal tot = 0;
            int month = now.Month;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Commande where MONTH(datecommande)=" + month + " and etatCmd = 'True'", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(5))
                        {
                            list.Add(new Commande(reader.GetInt32(0), reader.GetDecimal(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetDateTime(6)));
                        }
                        else
                        {
                            list.Add(new Commande(reader.GetInt32(0), reader.GetDecimal(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetDateTime(6)));
                        }
                    }

                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }
            try
            {
                SqlConnection cnx1 = Connexion.GetConnection();

                SqlCommand sqlCmd1 = new SqlCommand("select  prixTotal from Commande where MONTH(datecommande)=" + month + "", cnx1);

                SqlDataReader red = sqlCmd1.ExecuteReader();
                while(red.Read())
                {tot+= red.GetDecimal(0);
                }
            }
            catch (SqlException ex1) { throw ex1; }

            return list;

        }



        public List<Commande> getAllJour()
        {
            //TODO
            List<Commande> list = new List<Commande>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            DateTime now = DateTime.Now;
            decimal tot = 0;
            int month = now.Month;
            int day = now.Day;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Commande where DAY(datecommande)="+day+" AND MONTH(datecommande)=" + month + " and etatCmd = 'True'", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(5))
                        {
                            list.Add(new Commande(reader.GetInt32(0), reader.GetDecimal(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetDateTime(6)));
                        }
                        else
                        {
                            list.Add(new Commande(reader.GetInt32(0), reader.GetDecimal(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetDateTime(6)));
                        }
                    }

                }

                reader.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }
            try
            {
                SqlConnection cnx1 = Connexion.GetConnection();

                SqlCommand sqlCmd1 = new SqlCommand("select prixTotal from Commande where MONTH(datecommande)=" + month + "", cnx1);
                SqlDataReader red = sqlCmd1.ExecuteReader();
                    while(red.Read())
                    {
                tot += red.GetDecimal(0);}
            }
            catch (SqlException ex1) { throw ex1; }

            return list;

        }



















                public Decimal getAllMoistot()
        {
            //TODO
            List<Commande> list = new List<Commande>();
            SqlConnection cnx = Connexion.GetConnection();
            DateTime now = DateTime.Now;
            decimal tot = 0;
            int month = now.Month;


                               try
            {
                SqlCommand sqlCmd1 = new SqlCommand("select prixTotal from Commande where MONTH(datecommande)=" + month + "", cnx);
                SqlDataReader red = sqlCmd1.ExecuteReader();
                while (red.Read())
                {
                    tot += red.GetDecimal(0) ;
                }
            }
            catch (SqlException ex1) { throw ex1; }

                               return (Decimal)tot;


        }


                public Decimal getAlljourtot()
                {
                    //TODO
                    List<Commande> list = new List<Commande>();
                    SqlConnection cnx = Connexion.GetConnection();
                    DateTime now = DateTime.Now;
                    Decimal totjour = 0;
                    int month = now.Month;
                    int day = now.Day;


                    try
                    {
                        SqlCommand sqlCmd1 = new SqlCommand("select prixTotal from Commande where DAY(datecommande)=" + day + " AND MONTH(datecommande)=" + month + "", cnx);
                        SqlDataReader red = sqlCmd1.ExecuteReader();
                        while (red.Read())
                        {
                            totjour += red.GetDecimal(0) ;
                        }
                    }
                    catch (SqlException ex1) { throw ex1; }

                    return (Decimal)totjour;


                }
















        }





    }
