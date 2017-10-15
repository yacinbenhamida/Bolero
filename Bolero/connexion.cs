using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Bolero
{
    class connexion
    {
         private static SqlConnection cnx = new SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\\Bolero\\Bolero\\BoleroDB.mdf;Integrated Security=True");
        public static SqlConnection GetConnection()
        {
            try
            {
                cnx.Open();
                
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return cnx;
        }

        internal static void CloseConnection()
        {
            cnx.Close();        }
    }
    
}
