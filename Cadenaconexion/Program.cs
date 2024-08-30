using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadenaconexion
{
    // Clase principal donde comienza la ejecución del programa.
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        // Método principal que se ejecuta cuando se inicia la aplicación.
        static void Main()
        {
            // Habilita estilos visuales para los controles de Windows Forms.
            Application.EnableVisualStyles();

            // Configura la forma en que se renderiza el texto para que sea compatible.
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia y muestra el formulario principal de la aplicación (Form1).
            Application.Run(new Form1());
        }
    }
}
