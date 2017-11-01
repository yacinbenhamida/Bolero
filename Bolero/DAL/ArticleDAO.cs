﻿using System;
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

        public  int add(Article a)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("insert into Article (IdArticle,Libelle, Prix, Type) values (@id,@lib,@prix,@type)", cnx);
                sqlCmd.Parameters.AddWithValue("id", a.IdArticle);
                sqlCmd.Parameters.AddWithValue("lib", a.Libelle);
                sqlCmd.Parameters.AddWithValue("prix", a.Prix);
                sqlCmd.Parameters.AddWithValue("type", a.Type);
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

        public  int delete(int id)
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

        public  bool find(Article a)
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

        public  List<Article> getAll()
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
                        list.Add(new Article(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetString(3)));
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
                        a = new Article(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetString(3));
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
                SqlCommand cmd = new SqlCommand("Select * from Article where Type=@type", cnx);
                cmd.Parameters.AddWithValue("type", type);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows) 
                {
                    while (rd.Read()) 
                    {
                        lstRes.Add(new Article(rd.GetInt32(0),rd.GetString(1),rd.GetDecimal(2),rd.GetString(3)));
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

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Article SET Libelle=@lib,Prix=@prix,Type=@type where IdArticle=@id", cnx);
                cmd.Parameters.AddWithValue("id", obj.IdArticle);
                cmd.Parameters.AddWithValue("prix", obj.Prix);
                cmd.Parameters.AddWithValue("lib", obj.Libelle);
                cmd.Parameters.AddWithValue("type", obj.Type);
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
        public int getNumberOfElements()
        {
            int res = 0;
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("SELECT MAX(IdArticle) from Article", cnx);
                int done = (int)cmd.ExecuteScalar();
                if (done > 0) res = done;
            }
            catch (SqlException) { throw; }
            finally { Connexion.closeConnection(); }
            return res;
        }
    }
            
}
