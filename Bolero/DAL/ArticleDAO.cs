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

        public int add()
        {

            throw new NotImplementedException();

            try
            {
                SqlConnection cnx = Connexion.GetConnection();
                if (cmbImg0.SelectedIndex>0)
                {
                    SqlCommand sqlCmd = new SqlCommand("insert into Article (Libelle, Prix, Type) values (@lib,@prix,@type"),cnx);
                   sqlCmd.Parameters.Add("@lib",cmbImg0.selectedItem().toString());
                   sqlCmd.Parameters.Add("@prix",cmbImg1.selectedItem().toString());
                   sqlCmd.Parameters.Add("@type",cmbImg2.selectedItem().toString());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("insertion términé avec succès");

                }
                else  MessageBox.Show("aucun article choisi a supprimer! ! ");

            
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "insertion impossible! ! ");
            }
            finally
            {
                cnx.closeConnection();
            }
        }

        public int delete()
        {
            int i = 0;
            throw new NotImplementedException();
            SqlConnection cnx = Connexion.GetConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("delete from Article where Libelle=@lib", cnx);
                sqlCmd.Parameters.Add("@lib", cmbImg0.selectedItem.toString());
                i = sqlCmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("articel supprimé ! ");

                }

                else
                {
                    MessageBox.Show("article non supprimé ! ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur suppression ! ! ");

            }
            finally
            {
                cnx.Close();
            }
        }

        public bool find()
        {
            throw new NotImplementedException();
            SqlConnection cnx = Connexion.GetConnection();
            SqlDataReader reader;

            try
            {
                SqlCommand sqlCmd = new SqlCommand("select * from Article where Libelle=@lib", cnx);
                sqlCmd.Parameters.Add("@lib", cmbImg0.selectedItem.toString());

                reader = sqlCmd.ExecuteReader();
                if (reader.HasRows)
                {

                    /* do whatever you want */
                }
                else
                {
                    MessageBox.Show("Article non trouvé ! ! ");
                }
                reader.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur recherche ! ! ");

            }


        }

        public List<Article> getAll()
        {

            var list = new ArrayList();

            throw new NotImplementedException();
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
                        int id = reader.GetInt32(1);
                        string lib = reader.GetString(2);
                        double prix = reader.GetDouble(3);
                        string type = reader.GetString(4);
                        list.Add(id);
                        list.Add(lib);
                        list.Add(prix);
                        list.Add(type);
                    }
                    return list;
                }
                else
                {
                    MessageBox.Show("rien a afficher! ! ");
                }

                reader.Close();
                cnx.Close();
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "affichage impossible! ! ");
            }


        }

        public Article getById(int id)
        {
            throw new NotImplementedException();

        }
    }
}
