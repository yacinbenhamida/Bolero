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
using Bolero.DAL;
using System.Security.Cryptography;
using System.IO;
//Security Layer
namespace Bolero.SL
{
    class LoginSecurity
    {
        // this method sends an automated e-mail to the administrator after noticing an unusual login activity
        public static int notifyAdminByEmail(int idUser,string adminMail,string adminName) 
        {
            int done = 0;
           // string botmail = "boleroautomatedmail@gmail.com";
           // string botmailpw = "Bolerosecurityaccount123456BOT";
            string botmail = "yacin550@gmail.com";
             string botmailpw = "15111994";
            var fromAddress = new MailAddress(botmail, "Yassine Ben Hamida");
            var toAddress = new MailAddress(adminMail, adminName);
            string fromPassword = botmailpw;
            string sujet = "Changement du mot de passe du compte d'un compte  ";
            int changing =  UserDAO.editUserPWAutomatically(idUser);
            string newpw =null;
            if (changing == 1) newpw = UserDAO.getUserById(idUser).Password; 
            string body = "Nous avons remarqué des problemes de connectivité, voici  le nouveau mot de passe " + newpw;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = sujet,
                Body = body
            })
            {
                smtp.Send(message);
            }
            return done;
        }
        public static bool checkPassword(string input,int iduser) 
        {
            SqlConnection cnx;
            bool result = false;
            try
            {
                cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) from USER where password=@pw AND IdUser=@id", cnx);
                cmd.Parameters.AddWithValue("pw",input);
                cmd.Parameters.AddWithValue("id",iduser);
                int verif = (int)cmd.ExecuteScalar();
                if (verif == 1 ) result = true;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally { Connexion.closeConnection(); }
            return result;
        }

        const string passphrase = "password";
        public static string DecryptString(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToDecrypt = Convert.FromBase64String(Message);
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return UTF8.GetString(Results);
        }


        public static int checkSecurityQuestionConformity(int idOfUser,string choosenQuestion,string choosenAnswer) 
        {
            int good = 0;
            SqlConnection cnx;
            try
            {
                string fetchedqs = null;
                string fetchedAnswer = null;
                cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("SELECT questionsecrete,choixqs from Utilisateur where  Id=@id", cnx);
                cmd.Parameters.AddWithValue("id", idOfUser);
                IDataReader rd = cmd.ExecuteReader();
                while (rd.Read()) 
                {
                     fetchedqs = rd.GetString(1);
                     fetchedAnswer = rd.GetString(0);
                }
                rd.Close();
                if (fetchedqs.Equals(choosenQuestion) && fetchedAnswer.Equals(choosenAnswer))
                {
                    good = 1;
                }
                
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally { Connexion.closeConnection(); }
            return good;
        }
        public static int checkPasswordRenewal(string newPW, int idOfuser) 
        {
            int clean = 0;
            SqlConnection cnx;
            try
            {
                string fetchedPW = null;
                cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("SELECT Password from Utilisateur where  Id=@id", cnx);
                cmd.Parameters.AddWithValue("id", idOfuser);
                IDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    fetchedPW = rd.GetString(0);
                }
                rd.Close();
                if (!(fetchedPW.Equals(newPW)))
                {
                    clean = 1;
                }

            }
            catch (SqlException e)
            {
                throw e;
            }
            finally { Connexion.closeConnection(); }
            return clean;
        }
    }
}
