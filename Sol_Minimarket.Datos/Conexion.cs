using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sol_Minimarket.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;
        private static Conexion Con = null;

        private Conexion()
        {
            Base = "BD_MINIMARKET";
            Servidor = "siuture\\SQLEXPRESS";
            Usuario = "sistemas";
            Clave = "12345678";
            Seguridad = false;
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + Servidor + "; Database=" + Base + ";";
                if (Seguridad)
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "Integrated Security= SSPI";
                }
                else
                {
                    Cadena.ConnectionString = Cadena.ConnectionString + "User ID="+Usuario+"; Password ="+ Clave;
                }
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con= new Conexion();
            }
            return Con;
        }
    }
}
