using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bolero.DAL
{
    class Connexion
    {
        private static SqlConnection cnx = null;
        public static SqlConnection GetConnection()
        {
            try
            {
               cnx =  new SqlConnection(Properties.Settings.Default.chConn);
                cnx.Open();
                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return cnx;
        }

        public static void closeConnection()
        {
            if (cnx != null) cnx.Close(); 
                   
        }
    }
    }
}
