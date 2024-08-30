using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Cadenaconexion
{
    internal class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER=DESKTOP-7IK1942\\SQLEXPRESS;DATABASE=Northwind;integrated security=true;");
            cn .Open();
            return cn;
        }

    }
}
