﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Documents;
using Bolero.BL;

namespace Bolero.DAL
{
    class CrediteurDAO: DAO<Crediteur>
    {
        public Crediteur getById(int id)
        {
            Crediteur c= null;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand sqlCmd = new SqlCommand("select * from Client_Crediteurs where IdCommande=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id", id);
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    c = new Crediteur(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetDecimal(3), reader.GetString(4), reader.GetInt32(5));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }
            return c;
        }
        public int add(Crediteur c)
        {
            int res = 0;
            decimal sum;
            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                CommandeDAO cmddao = new CommandeDAO();
                Commande cmd = cmddao.getById(c.Idcmd);
                sum = cmd.prixtotal;
                SqlCommand sqlCmd = new SqlCommand("insert into Client_Crediteurs ( nomprenom, cin,totalCmdTTC , tel,idCommande) values (@nomprenom,@cin,@prix,@tel,@idcmd)", cnx);
              //  sqlCmd.Parameters.AddWithValue("idc", c.IdCrediteur);
                sqlCmd.Parameters.AddWithValue("nomprenom", c.nomprenom);
                sqlCmd.Parameters.AddWithValue("cin", c.cin);
                sqlCmd.Parameters.AddWithValue("prix", c.MontantCredit);
                sqlCmd.Parameters.AddWithValue("tel",c.tel );
                sqlCmd.Parameters.AddWithValue("idcmd", c.Idcmd);
               res= sqlCmd.ExecuteNonQuery();
                
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
                SqlCommand sqlCmd = new SqlCommand("delete from Client_Crediteurs where  IdCrediteur=@id", cnx);
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


        public int update(Crediteur crd)
        {
            int res = 0;

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Client_Crediteurs SET nom_prenomCred=@nomprenom,cin=@cin,totalCmdTTC=@montC,tel=@numt,idCommande=@idcmd where IdCrediteur=@id", cnx);
                cmd.Parameters.AddWithValue("nomprenom", crd.nomprenom);
                cmd.Parameters.AddWithValue("cin", crd.cin);
                cmd.Parameters.AddWithValue("numt",crd.tel);
                cmd.Parameters.AddWithValue("MontC", crd.MontantCredit);
                cmd.Parameters.AddWithValue("idcmd", crd.Idcmd);
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


        public List<Crediteur> getAll()
        {

            List<Crediteur> listc = new List<Crediteur>();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Client_Crediteurs", cnx);
                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        listc.Add(new Crediteur(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),reader.GetDecimal(3),reader.GetString(4),reader.GetInt32(5)));
                    }

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { Connexion.closeConnection(); }


            return listc;
        }

        public bool find(Crediteur c)
        {
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;
            bool res = false;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Client_Crediteurs where IdCrediteur=@id", cnx);
                sqlCmd.Parameters.AddWithValue("id",c.IdCrediteur);
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

    }
}
