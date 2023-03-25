using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Conexion
    {
        private static string NombreAplicacion = "Prueba";
        private static string Servidor = @"SRG\SQL2019";
        private static string Usuario = "srg";
        private static string Password = "#Mejia#";
        private static string BaseDatosDinamicWeb = "DinamicWeb";
        private static string BaseDatosNorthwind = "Northwind";

        public static string ConexionStringDinamicWeb(bool SqlAutentication = true)
        {
            SqlConnectionStringBuilder Constructor = new SqlConnectionStringBuilder()
            {
                ApplicationName = NombreAplicacion,
                IntegratedSecurity = SqlAutentication,
                DataSource = Servidor,
                InitialCatalog = BaseDatosDinamicWeb
            };

            if (SqlAutentication)
            {
                Constructor.UserID = Usuario;
                Constructor.Password = Password;
            }

            return Constructor.ConnectionString;
        }

         public static string ConexionStringNorthwind (bool SqlAutentication = true)
        {
            SqlConnectionStringBuilder Constructor = new SqlConnectionStringBuilder()
            {
                ApplicationName = NombreAplicacion,
                IntegratedSecurity = SqlAutentication,
                DataSource = Servidor,
                InitialCatalog = BaseDatosNorthwind
            };

            if (SqlAutentication)
            {
                Constructor.UserID = Usuario;
                Constructor.Password = Password;
            }

            return Constructor.ConnectionString;
        }
    }
}
