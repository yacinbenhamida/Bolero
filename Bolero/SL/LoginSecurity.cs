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
//Security Layer
namespace Bolero.SL
{
    class LoginSecurity
    {
        //  #1 this method sends an automated e-mail to the administrator after noticing an unusual login activity
        public int notifyAdminByEmail(int idUser,string adminMail,string adminName) 
        {
            int done = 0;
            string botmail = "boleroautomatedmail@gmail.com";
            string botmailpw = "Bolerosecurityaccount123456BOT";
            var fromAddress = new MailAddress(botmail, "Votre caisse bolero ");
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
        public bool checkPassword(string input,int iduser) 
        {
            SqlConnection cnx;
            bool result = false;
            try
            {
                cnx = Connexion.GetConnection();
                SqlCommand cmd = new SqlCommand("SELECT Count(*) from Utilisateur where password=@pw AND Id=@id", cnx);
                cmd.Parameters.AddWithValue("pw",input);
                cmd.Parameters.AddWithValue("Id",iduser);
                int verif = (int)cmd.ExecuteScalar();
                if (verif > 0) result = true;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally { Connexion.closeConnection(); }
            return result;
        }
    }
}
