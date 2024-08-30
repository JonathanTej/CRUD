using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Cadenaconexion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            MessageBox.Show("bebé, LO LOGRAMOS :´)");

            dataGridView1.DataSource = Llenar_grid();
        }

        public DataTable Llenar_grid() 
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT * FROM Customers";
            SqlCommand cmd = new SqlCommand(consulta,Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "INSERT INTO Customers (CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country)VALUES(@CustomerID,@CompanyName,@ContactName,@ContactTitle,@Address,@City,@Region,@PostalCode,@Country)";
            SqlCommand cmd1 = new SqlCommand(insertar,Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@CustomerID", textBox1.Text);
            cmd1.Parameters.AddWithValue("@CompanyName", textBox4.Text);
            cmd1.Parameters.AddWithValue("@ContactName", textBox7.Text);
            cmd1.Parameters.AddWithValue("@ContactTitle", textBox2.Text);
            cmd1.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd1.Parameters.AddWithValue("@City", textBox8.Text);
            cmd1.Parameters.AddWithValue("@Region", textBox3.Text);
            cmd1.Parameters.AddWithValue("@PostalCode", textBox6.Text);
            cmd1.Parameters.AddWithValue("@Country", textBox9.Text);

            cmd1.ExecuteNonQuery();

            MessageBox.Show("¡Los datos fueron añadidos sin problemones!"); //Mensaje para comprobar si se añadieron datos (están por orden de letra)

            dataGridView1.DataSource = Llenar_grid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            { 
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

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE Customers SET CustomerID=@CustomerID, CompanyName=@CompanyName, ContactName=@ContactName, ContactTitle=@ContactTitle, Address=@Address, City=@City, Region=@Region, PostalCode=@PostalCode, Country=@Country WHERE CustomerID=@CustomerID";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());

            cmd2.Parameters.AddWithValue("@CustomerID", textBox1.Text);
            cmd2.Parameters.AddWithValue("@CompanyName", textBox4.Text);
            cmd2.Parameters.AddWithValue("@ContactName", textBox7.Text);
            cmd2.Parameters.AddWithValue("@ContactTitle", textBox2.Text);
            cmd2.Parameters.AddWithValue("@Address", textBox5.Text);
            cmd2.Parameters.AddWithValue("@City", textBox8.Text);
            cmd2.Parameters.AddWithValue("@Region", textBox3.Text);
            cmd2.Parameters.AddWithValue("@PostalCode", textBox6.Text);
            cmd2.Parameters.AddWithValue("@Country", textBox9.Text);

            cmd2.ExecuteNonQuery();
            MessageBox.Show("¡Los datos han sido actualizados, enhorabuena :)!"); //Mensaje que verifique si se actualizó
            dataGridView1.DataSource = Llenar_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "DELETE FROM Customers WHERE CustomerID=@CustomerID";
            SqlCommand cmd3 = new SqlCommand(eliminar,Conexion.Conectar());

            cmd3.Parameters.AddWithValue("@CustomerID",textBox1.Text);

            cmd3.ExecuteNonQuery();

            MessageBox.Show("Los datos se han eliminado :O"); //Mensaje que verifique si se completó la eliminación

            dataGridView1.DataSource=Llenar_grid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox8.Clear();
            textBox3.Clear();
            textBox6.Clear();
            textBox9.Clear();

            textBox1.Focus();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
