using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;

namespace Suii_Project
{
    public partial class Manager_view : Form
    {
        public Manager_view()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            string mid=textBox1.Text;
            Manager_matches f1 = new Manager_matches(mid);
            f1.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mid = textBox1.Text;
            if (mid.ToUpper() != "CHE" && mid.ToUpper() != "ARS" && mid.ToUpper() != "MCI" && mid.ToUpper() != "LIV" && mid.ToUpper() != "MUN")
            {
                MessageBox.Show("Enter valid manager id!\n Manager ID must be among 'CHE','ARS','LIV','MCI','MUN'", "Error");
                textBox1.Text = string.Empty;
                /*label3.Text = String.Empty;
                label11.Text = String.Empty;
                label5.Text = String.Empty;
                label7.Text = String.Empty;
                label16.Text = String.Empty;
                label14.Text = String.Empty;
                label18.Text = String.Empty;
                label8.Text = String.Empty;
                label9.Text = String.Empty;
                label10.Text = String.Empty;
                label11.Text = String.Empty;
                label12.Text = String.Empty;
                label13.Text = String.Empty;
                label14.Text = String.Empty;
                label18.Text = String.Empty;
                label19.Text = String.Empty;
                label20.Text = String.Empty;*/
            }
            else
            {
                button2.Enabled = true;
                button3.Enabled = true;
            }
            string connetionString = "server=localhost;database=suii;uid=root;pwd=rakshit";
            using (MySqlConnection con = new MySqlConnection(connetionString))
            {
                con.Open();
                string query = "select * from teams where tid= '" + mid + "'";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    StringBuilder sb = new StringBuilder();
                    while (reader.Read())
                    {
                        label3.Text = reader.GetString(1);
                        label11.Text = reader.GetString(9);
                        label5.Text = reader.GetString(2);
                        label7.Text = reader.GetString(3);
                        label16.Text = reader.GetString(6);
                        label14.Text = reader.GetString(5);
                        label18.Text = reader.GetString(8);
                        label8.Text = reader.GetString(4);
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string mid = textBox1.Text;
            player_view_manager f1 = new player_view_manager(mid);
            this.Hide();
            f1.Show();
        }
        private void label2_Click(object sender, EventArgs e)
        {
        
        }

        private void label20_Click(object sender, EventArgs e)
        {
        
        }

        private void label18_Click(object sender, EventArgs e)
        {
        
        }

        private void label6_Click(object sender, EventArgs e)
        {
        
        }

        private void label14_Click(object sender, EventArgs e)
        {
        
        }

        private void Manager_view_Load(object sender, EventArgs e)
        {

        }
    }
}
