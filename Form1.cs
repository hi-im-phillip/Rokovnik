using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;


namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        string konekcijskiString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Filip\source\repos\WindowsFormsApp5\WindowsFormsApp5\SQL\Data.mdf;Integrated Security=True;Connect Timeout=30";
        public Form1(string Username)
        {
            InitializeComponent();
            label6.Text = Username;
            FillCombo(Username);           
            timer1.Start();           
        }

        private void FillCombo(string Username)
        {
            label6.Text = Username;
            //spajanje na bazu
            using (SqlConnection conn = new SqlConnection(konekcijskiString))
            {
                //sql upit      
                string query = "select * from KORISNICI WHERE IdKorisnik = '" + Username + "'  ;";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader myReader;
                try
                {
                    conn.Open();
                    //cmd.ExecuteNonQuery();
                    myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {
                        // u nazivSql se storaju svi podaci iz 1. stupca 
                        string nazivSql = myReader.GetString(1);
                        //string nazivSql ce se dodati u comboBox a posto smo u while loopu, dodati ce ih od prvog do zadnjeg
                        comboBox1.Items.Add(nazivSql);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
            }

            private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //spajanje na bazu
            using (SqlConnection conn = new SqlConnection(konekcijskiString))
            { 
            //sql upit
            string query = "UPDATE KORISNICI SET Naziv = '" + this.textBox1.Text + 
                    "' , Email = '" + this.textBox2.Text + 
                    "' , Adresa = '" + this.textBox3.Text +
                     "' , IdKorisnik = '" + label6.Text +
                    "' ,  Datum = '" + this.dateTimePicker1.Value.Date.ToString("yyyy/MM/dd") + 
                    "' , Informacije = '" + this.textBox4.Text +
                    "' WHERE Naziv = '" + this.textBox1.Text + "' ;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader myReader;
            //cmd.CommandText = "INSERT INTO KORISNICI(Datum) VALUES(@Datum);";
            //cmd.Parameters.Add("@Datum", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
            try
            {
                conn.Open();
                //cmd.ExecuteNonQuery();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Uspjesno promijenjeni podaci");
                    comboBox1.ResetText();
                    while (myReader.Read())
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //spajanje na bazu
            using (SqlConnection conn = new SqlConnection(konekcijskiString)) { 
                //sql upit
                string query = "DELETE FROM KORISNICI WHERE Naziv = '" + this.textBox1.Text + "' ;";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader myReader;        
            try
            {
                conn.Open();
                //cmd.ExecuteNonQuery();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Uspjesno obrisani podaci");
                    comboBox1.ResetText();
                    while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            }
        }
        private void obrisiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // dateTimePicker1.Value = DateTime.Parse("dd/MM/yyyy");
          

            if (this.textBox1.Text == string.Empty)
            {
                MessageBox.Show("Potrebno je unijeti naziv događaja");
            }
            else
            {

                //spajanje na bazu
                using (SqlConnection conn = new SqlConnection(konekcijskiString)) { 

                    //sql upit
                    string query = "INSERT INTO KORISNICI(Naziv, Email, IdKorisnik, Adresa, Datum, Informacije) VALUES " +
                        "('" + this.textBox1.Text + "' , " + 
                        " '" + this.textBox2.Text + "' , " +
                        " '" + label6.Text + "' , " +
                        "'" + this.textBox3.Text + "' ,  " +
                        "'" + this.dateTimePicker1.Value.Date.ToString("yyyy/MM/dd") + 
                        "' , '" + this.textBox4.Text + "' " +
                        ")";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader myReader;
                //cmd.CommandText = "INSERT INTO KORISNICI(Datum) VALUES(@Datum);";
                //cmd.Parameters.Add("@Datum", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
                try
                {
                    conn.Open();
                    //cmd.ExecuteNonQuery();
                    myReader = cmd.ExecuteReader();
                    MessageBox.Show("Uspjesno uneseni podaci");
                        comboBox1.ResetText();
                        while (myReader.Read())
                    {

                    }                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                }
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // var f2 = new Form2();
            // f2.FormClosed += (s, args) => this.Close();
            // this.Close();
            // f2.Show();
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            this.Close();    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //spajanje na bazu
            using (SqlConnection con = new SqlConnection(konekcijskiString)) { 

                //sql upit
                string query = "select * from KORISNICI where Naziv= '" + comboBox1.Text + "' ;";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader myReader;
            //cmd.CommandText = "INSERT INTO KORISNICI(Datum) VALUES(@Datum);";
            //cmd.Parameters.Add("@Datum", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
            try
            {
                con.Open();
                //cmd.ExecuteNonQuery();
                myReader = cmd.ExecuteReader();

                while (myReader.Read())
                {
                    string nazivSql = myReader.GetString(1);
                    string emailSql = myReader.GetString(2);
                    string adreasSql = myReader.GetString(3);
                    string datumSql = myReader.GetDateTime(4).ToString();
                    string informacijeSql = myReader.GetString(5);

                    textBox1.Text = nazivSql;
                    textBox2.Text = emailSql;
                    textBox3.Text = adreasSql;
                    dateTimePicker1.Text = datumSql;
                    textBox4.Text = informacijeSql;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            }
        }
        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.labelTime.Text = dateTime.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
         //Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
  
}
