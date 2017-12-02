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
    class ArticleDAO : DAO<Article>
    {

        public Article PlatDJ()
        { 
            
            Article res = new Article();
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("SELECT * from Article where platJour =@pj ", cnx);
                cmd.Parameters.AddWithValue("pj", true);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {

                        res = new Article(rd.GetInt32(0), rd.GetString(1), rd.GetDecimal(2), rd.GetInt32(3));
                    }
                }
                
            }
            catch (SqlException) { throw; }
            finally { Connexion.closeConnection(); }
            return res;
        }
        public int add(Article a)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into Article (IdArticle, Libelle, Prix, IdCategorie, platJour) values (@id,@lib,@prix,@cat,@plat)", cnx);
                sqlCmd.Parameters.AddWithValue("id", a.IdArticle);
                sqlCmd.Parameters.AddWithValue("lib", a.Libelle);
                sqlCmd.Parameters.AddWithValue("prix", a.Prix);
                sqlCmd.Parameters.AddWithValue("cat", a.IdCategorie);
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

        public int addArticleOnCommande(List<Article> lst, int id)
        {
            int res = 0;
            SqlCommand insertJointure = null;
            int d = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                for (int i = 0; i < lst.Count; i++)
                {
                    insertJointure = new SqlCommand("insert into lignecmd(numcmd,numArticle) VALUES (@numcd,@numar)", cnx);
                    insertJointure.Parameters.AddWithValue("numcd", id);
                    insertJointure.Parameters.AddWithValue("numar", lst[i].IdArticle);
                    d = (int)insertJointure.ExecuteNonQuery();
                }
                if (d > 0)
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
                SqlCommand sqlCmd = new SqlCommand("delete from Article where  IdArticle=@id", cnx);
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

        public bool find(Article a)
        {
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            bool res = false;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Article where IdArticle=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", a.IdArticle);
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

        public List<Article> getAll()
        {

            List<Article> list = new List<Article>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Article", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(new Article(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3)));
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

        public Article getById(int id)
        {
            Article a = null;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("select * from Article where IdArticle=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", id);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    a = new Article(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetInt32(3));
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
        //this method fetches an articles according to it's type (entrée,salade,suite)
        //useful when displaying buttons for each tab
        public List<Article> getArticlesByType(string type)
        {
            List<Article> lstRes = new List<Article>();
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("Select Article.* from Article,Categorie where Article.IdCategorie=Categorie.IdCat and Categorie.libellecat=@type", cnx);
                cmd.Parameters.AddWithValue("type", type);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lstRes.Add(new Article(rd.GetInt32(0), rd.GetString(1), rd.GetDecimal(2), rd.GetInt32(3)));
                    }
                }
            }
            catch (SqlException ex) { throw ex; }
            finally { Connexion.closeConnection(); }
            return lstRes;
        }
        public int update(Article obj)
        {
            int res = 0;
            int idCat = 0;
            String libCat = "";
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("Select * from Article where IdArticle=@id", cnx);
                cmd.Parameters.AddWithValue("id", obj.IdArticle);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        idCat = rd.GetInt32(0);
                        libCat = rd.GetString(1);
                    }
                }
            }
            catch (SqlException ex) { throw ex; }
            finally { Connexion.closeConnection(); }
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Article SET Libelle=@lib,Prix=@prix where IdArticle=@id", cnx);
                cmd.Parameters.AddWithValue("id", obj.IdArticle);
                cmd.Parameters.AddWithValue("prix", obj.Prix);
                cmd.Parameters.AddWithValue("lib", obj.Libelle);
                SqlCommand cmd1 = new SqlCommand("UPDATE Categorie SET libelleCat=@libCat where IdCat=@idCat", cnx);
                cmd1.Parameters.AddWithValue("libCat", libCat);
                cmd1.Parameters.AddWithValue("idCat", idCat);
                int done = (int)cmd.ExecuteNonQuery();
                int done1 = (int)cmd1.ExecuteNonQuery();
                if (done > 0 && done1 > 0) res = 1;
            }
            catch (SqlException)
            {

                throw;
            }
            finally { Connexion.closeConnection(); }
            return res;
        }
        public int getNumberOfElements()
        {
            int res = 0;
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("select MAX(IdArticle) from Article", cnx);
                int done = (int)cmd.ExecuteScalar();
                if (done > 0)
                    res = done;
            }
            catch (SqlException) { throw; }
            finally { Connexion.closeConnection(); }
            return res;
        }

        public int deleteArticle(int idArt, int id)
        {
            int res = 0;
            SqlConnection cnx = Connexion.GetConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("DELETE FROM [lignecmd] WHERE numArticle = @idArt AND numcmd = @id", cnx);
                sqlCmd.Parameters.AddWithValue("idArt", idArt);
                sqlCmd.Parameters.AddWithValue("id", id);
                res = (int)sqlCmd.ExecuteNonQuery();
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

        public List<Article> getArticlesByEtat(bool etat)
        {
            List<Article> lstRes = new List<Article>();
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("Select Article.* from Article where platJour=@etat", cnx);
                cmd.Parameters.AddWithValue("etat", etat);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        lstRes.Add(new Article(rd.GetInt32(0), rd.GetString(1), rd.GetDecimal(2), rd.GetInt32(3)));
                    }
                }
            }
            catch (SqlException ex) { throw ex; }
            finally { Connexion.closeConnection(); }
            return lstRes;
        }

        public int PlatJourEtatTrue(Article obj)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Article SET platJour=@etat where IdArticle=@id", cnx);
                cmd.Parameters.AddWithValue("id", obj.IdArticle);
                cmd.Parameters.AddWithValue("etat", true);

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

        public int PlatJourEtatFalse(Article obj)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Article SET platJour=@etat where IdArticle=@id", cnx);
                cmd.Parameters.AddWithValue("id", obj.IdArticle);
                cmd.Parameters.AddWithValue("etat", false);

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

        public Dictionary<String, decimal> historiqueArticle()
        {
            Dictionary<String, decimal> dictHist = new Dictionary<String, decimal>();

            List<int> nbArticle = new List<int>();
            List<String> lblArticle = new List<String>();
            List<decimal> PrixArticle = new List<decimal>();

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd1 = new SqlCommand("SELECT IdArticle FROM Article ", cnx);
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    nbArticle.Add(reader.GetInt32(0));
                }
                reader.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            finally { Connexion.closeConnection(); }

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd2 = new SqlCommand("SELECT Libelle FROM Article", cnx);
                SqlDataReader reader = cmd2.ExecuteReader();
                while (reader.Read())
                {
                    lblArticle.Add(reader.GetString(0));
                }
                reader.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            finally { Connexion.closeConnection(); }

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd3 = new SqlCommand("SELECT Prix FROM Article", cnx);
                SqlDataReader reader = cmd3.ExecuteReader();
                while (reader.Read())
                {
                    PrixArticle.Add(reader.GetDecimal(0));
                }
                reader.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            finally { Connexion.closeConnection(); }

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                for (int i = 0; i < nbArticle.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(numArticle) AS nb_Articles FROM lignecmd WHERE numArticle=@art GROUP BY numArticle HAVING COUNT(numArticle)>=1", cnx);
                    cmd.Parameters.AddWithValue("art", nbArticle[i]);
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    while (reader1.Read())
                    {
                        decimal totPrix = reader1.GetInt32(0) * PrixArticle[i];
                        Properties.Settings.Default.nombreArticle += reader1.GetInt32(0);
                        Properties.Settings.Default.totalPrix += totPrix;
                        Properties.Settings.Default.Save();
                        String article = reader1.GetInt32(0) + " x " + lblArticle[i];

                        dictHist.Add(article, totPrix);
                    }
                    reader1.Close();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            finally { Connexion.closeConnection(); }


            return dictHist;
        }
    }
}
