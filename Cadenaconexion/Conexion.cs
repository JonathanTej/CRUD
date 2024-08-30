using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Cadenaconexion
{
    // Esta clase maneja la conexión a la base de datos.
    internal class Conexion
    {
        // Este método establece y devuelve una conexión con la base de datos.
        public static SqlConnection Conectar()
        {

            // Se crea una nueva conexión usando una cadena de conexión específica.
            SqlConnection cn = new SqlConnection("Data Source=LAPTOP-T37BFAOL\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;");
            // Se abre la conexión a la base de datos.
            cn.Open();
            // Se retorna el objeto de conexión para ser usado en otras partes del programa.
            return cn;

        }

    }
}
