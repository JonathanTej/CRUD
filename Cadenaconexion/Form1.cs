using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Cadenaconexion
{
    // Clase principal para el formulario
    public partial class Form1 : Form
    {
        // Constructor del formulario
        public Form1()
        {
            InitializeComponent(); // Inicializa los componentes del formulario
        }

        // Evento que se ejecuta cuando el formulario se carga
        private void Form1_Load(object sender, EventArgs e)
        {
            // Conecta a la base de datos
            Conexion.Conectar();
            // Muestra un mensaje para que el usuario sepa que la aplicación está lista
            MessageBox.Show("Pulse para iniciar");

            // Rellena el DataGridView con los datos de la base de datos
            dataGridView1.DataSource = Llenar_grid();
        }

        // Método para llenar el DataGridView con los datos de la base de datos
        public DataTable Llenar_grid()
        {
            Conexion.Conectar(); // Conecta a la base de datos
            DataTable dt = new DataTable(); // Crea una tabla para almacenar los datos
            string consulta = "SELECT * FROM Customers"; // Consulta SQL para obtener todos los clientes
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar()); // Prepara el comando SQL

            SqlDataAdapter da = new SqlDataAdapter(cmd); // Adapta los datos del comando SQL a la tabla

            da.Fill(dt); // Llena la tabla con los datos
            return dt; // Devuelve la tabla llena de datos
        }

        // Evento que se ejecuta cuando se hace clic en el botón para añadir datos
        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar(); // Conecta a la base de datos
            // Consulta SQL para insertar un nuevo cliente
            string insertar = "INSERT INTO Customers (CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country) VALUES(@CustomerID,@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar()); // Prepara el comando SQL

            // Añade los valores de los campos de texto al comando SQL
            cmd1.Parameters.AddWithValue("@CustomerID", textBox1.Text);
            cmd1.Parameters.AddWithValue("@CompanyName", textBox4.Text);
            cmd1.Parameters.AddWithValue("@ContactName", textBox7.Text);
            cmd1.Parameters.AddWithValue("@ContactTitle", textBox2.Text);
            cmd1.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd1.Parameters.AddWithValue("@City", textBox8.Text);
            cmd1.Parameters.AddWithValue("@Region", textBox3.Text);
            cmd1.Parameters.AddWithValue("@PostalCode", textBox6.Text);
            cmd1.Parameters.AddWithValue("@Country", textBox9.Text);

            cmd1.ExecuteNonQuery(); // Ejecuta el comando para insertar los datos en la base de datos

            // Muestra un mensaje para confirmar que los datos se han añadido
            MessageBox.Show("Los datos han sido añadidos");

            // Actualiza el DataGridView con los nuevos datos
            dataGridView1.DataSource = Llenar_grid();
        }

        // Evento que se ejecuta cuando se hace clic en una celda del DataGridView
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Rellena los campos de texto con los valores de la fila seleccionada en el DataGridView
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
            catch { }
        }

        // Evento que se ejecuta cuando se hace clic en el botón para actualizar datos
        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar(); // Conecta a la base de datos
            // Consulta SQL para actualizar un cliente existente
            string actualizar = "UPDATE Customers SET CustomerID=@CustomerID, CompanyName=@CompanyName, ContactName=@ContactName, ContactTitle=@ContactTitle, Address=@Address, City=@City, Region=@Region, PostalCode=@PostalCode, Country=@Country WHERE CustomerID=@CustomerID";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar()); // Prepara el comando SQL

            // Añade los valores de los campos de texto al comando SQL
            cmd2.Parameters.AddWithValue("@CustomerID", textBox1.Text);
            cmd2.Parameters.AddWithValue("@CompanyName", textBox4.Text);
            cmd2.Parameters.AddWithValue("@ContactName", textBox7.Text);
            cmd2.Parameters.AddWithValue("@ContactTitle", textBox2.Text);
            cmd2.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd2.Parameters.AddWithValue("@City", textBox8.Text);
            cmd2.Parameters.AddWithValue("@Region", textBox3.Text);
            cmd2.Parameters.AddWithValue("@PostalCode", textBox6.Text);
            cmd2.Parameters.AddWithValue("@Country", textBox9.Text);

            cmd2.ExecuteNonQuery(); // Ejecuta el comando para actualizar los datos en la base de datos

            // Muestra un mensaje para confirmar que los datos se han actualizado
            MessageBox.Show("Los datos se han actualizado correctamente");

            // Actualiza el DataGridView con los datos actualizados
            dataGridView1.DataSource = Llenar_grid();
        }

        // Evento que se ejecuta cuando se hace clic en el botón para eliminar datos
        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar(); // Conecta a la base de datos
            // Consulta SQL para eliminar un cliente
            string eliminar = "DELETE FROM Customers WHERE CustomerID=@CustomerID";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar()); // Prepara el comando SQL

            // Añade el valor del campo de texto al comando SQL
            cmd3.Parameters.AddWithValue("@CustomerID", textBox1.Text);

            cmd3.ExecuteNonQuery(); // Ejecuta el comando para eliminar los datos de la base de datos

            // Muestra un mensaje para confirmar que los datos se han eliminado
            MessageBox.Show("Los datos se han eliminado");

            // Actualiza el DataGridView con los datos restantes
            dataGridView1.DataSource = Llenar_grid();
        }

        // Evento que se ejecuta cuando se hace clic en el botón para limpiar los campos de texto
        private void button4_Click(object sender, EventArgs e)
        {
            // Limpia todos los campos de texto
            textBox1.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox8.Clear();
            textBox3.Clear();
            textBox6.Clear();
            textBox9.Clear();

            textBox1.Focus(); // Pone el foco en el primer campo de texto
        }

        // Evento que se ejecuta cuando cambia el texto en el campo de texto 10
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            // Este método está vacío, pero puede ser usado para manejar cambios en textBox10
        }
    }
}
