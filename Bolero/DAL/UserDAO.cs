using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Net;
using System.Data;
using System.Net.Mail;
using Bolero.BL;
namespace Bolero.DAL
{
    class UserDAO
    {
        static SqlConnection cnx;
        public static User getUserById(int id) {
            User u = null;
            try
            {
              cnx = Connexion.GetConnection();
              SqlCommand cmd = new SqlCommand("select * from Utilisateur where Id =@uname", cnx);
              cmd.Parameters.AddWithValue("uname", id);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read()) 
                {
                    u = new User(rd.GetInt32(0),rd.GetString(1),rd.GetString(2),rd.GetString(3),rd.GetString(4));
                }
                rd.Close();
            } catch(SqlException e) 
            {
                throw e;
            }
            finally 
            { 
                Connexion.closeConnection();
            }
            return u;
        }
        public static List<User> getAllUsers() 
        {
            List<User> lstUsers = new List<User>();
            User u = null;
            try
            {
                cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Utilisateur", cnx);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    int id = rd.GetInt32(0);
                    string nom = rd.GetString(1);
                    string mdp = rd.GetString(2);
                    string qs = rd.GetString(3);
                    string choixqs = rd.GetString(4);
                    u = new User(id, nom, mdp, qs,choixqs);
                    lstUsers.Add(u);
                }
                rd.Close();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally { Connexion.closeConnection(); }
            return lstUsers;
        }
        //changing pw when the user asks for it (secret question window)
        public static int editUserPWWrequested(int id, string newPassword) 
        {
            int done = 0;
            try
            {
                cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Utilisateur SET password=@newpw WHERE Id=@id", cnx);
                cmd.Parameters.AddWithValue("newpw", newPassword);
                cmd.Parameters.AddWithValue("id", id);
                
                int i = (int)cmd.ExecuteNonQuery();
                if (i == 1) done = 1;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally { Connexion.closeConnection(); }
            return done;
        }
        //changing the password using an automated pattern , generated when the login attempts 
        // are higher than 5
        // generating pw method

        private static char[] randomChars = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', '9', '0' ,'1' , '2' ,'3' };
        private static readonly Random rand = new Random();
        private static string getRandomPassword()
            {
            char[] password = new char[8]; //the longer the better ;)
            for (int i = 0; i < 8; ++i)
            {
                password[i] = randomChars[rand.Next(0, randomChars.Length)];
            }
            return new string(password);

            }
        //changing the pw method
        public static int editUserPWAutomatically(int id) 
        {
            int done = 0;
            try
            {
                cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("UPDATE Utilisateur SET password=@newpw WHERE Id=@id", cnx);
                cmd.Parameters.AddWithValue("newpw", getRandomPassword());
                cmd.Parameters.AddWithValue("Id", id);
                int i = (int)cmd.ExecuteNonQuery();
                if (i == 1) done = 1;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally { Connexion.closeConnection(); }
            return done;
            
        }
    }
}
