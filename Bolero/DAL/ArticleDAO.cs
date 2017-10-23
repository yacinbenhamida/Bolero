using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolero.BL;
using System.Data.SqlClient;
using System.Data;
using Bolero.Properties;
using Bolero;
using System.Collections;
using System.Windows;

namespace Bolero.DAL
{
    class ArticleDAO : DAO<Article>
    {

        public int add(Article a)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into Article (Libelle, Prix, Type) values (@lib,@prix,@type)", cnx);
                sqlCmd.Parameters.Add("@lib", a.Libelle);
                sqlCmd.Parameters.Add("@prix", a.Prix);
                sqlCmd.Parameters.Add("@type", a.Type);
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
                SqlCommand sqlCmd = new SqlCommand("delete from Article where  Id=@id", cnx);
                sqlCmd.Parameters.Add("@id", id);
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
                cnx.Close();

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
                sqlCmd.Parameters.Add("@id", a.IdArticle);

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
                        list.Add(new Article(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3)));
                    }
                    return list;
                }

                reader.Close();
                cnx.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public Article getById(int id)
        {   Article a=null;
            Article a2=new Article(id,"",1,"");
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;

            try
            {  if(find(a2))
            {
            SqlCommand sqlCmd = new SqlCommand("select * from Article where IdArticle=@id", cnx);
                 sqlCmd.Parameters.Add("@id",a2.IdArticle);

                reader = sqlCmd.ExecuteReader();
                a=new Article(reader.GetInt32(0),reader.GetString(1),reader.GetInt32(2),reader.GetString(3));

                reader.Close();
                cnx.Close();
            }
                
                
             }catch (Exception ex)
            {
                throw ex;
            }
            return a; 
    }
    }
}
