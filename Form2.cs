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

namespace WindowsFormsApp5
{
    public partial class Form2 : Form
    {

        string konekcijskiString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Filip\source\repos\WindowsFormsApp5\WindowsFormsApp5\SQL\Data.mdf;Integrated Security=True;Connect Timeout=30";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(konekcijskiString);
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) From db_securityadmin where Username='" + textBox1.Text + "' and Lozinka = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();

                Form1 ss = new Form1(textBox1.Text);

                ss.Show();
            }
            else
            {
                MessageBox.Show("Korisnicko ime ili lozinka nisu točni.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
           Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
