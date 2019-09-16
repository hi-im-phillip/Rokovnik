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
    public partial class Form3 : Form
    {
        string konekcijskiString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Filip\source\repos\WindowsFormsApp5\WindowsFormsApp5\SQL\Data.mdf;Integrated Security=True;Connect Timeout=30";
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (this.textBox1.Text == string.Empty || this.textBox2.Text == string.Empty || this.textBox3.Text == string.Empty || this.textBox4.Text.Length < 5)
            {
                MessageBox.Show("Niste unijeli sve potrebne podatke ili lozinka nema dovoljan broj karaktera");
            }
            else if (this.textBox4.Text != this.textBox5.Text)
            {
                MessageBox.Show("Lozinke se ne podudaraju");
            }
            else 
            {
                using (SqlConnection con = new SqlConnection(konekcijskiString)) { 

                    con.Open();
                string insert = "INSERT INTO db_securityadmin(Username, Ime, Prezime, Lozinka) VALUES ('" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "')";
                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Uspješno ste se registrirali");
                    con.Close();
                Form2 f2 = new Form2();
                this.Hide();
                f2.Show();
                
                }
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.UseSystemPasswordChar = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            textBox5.UseSystemPasswordChar = true;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
           Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();

        }
    }
}
