using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Suii_Project
{
    public partial class Referee_view : Form
    {
        public Referee_view()
        {
            InitializeComponent();
            label4.Text = string.Empty;
            label5.Text = string.Empty;
            label6.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            referee_booking f1 = new referee_booking();
            f1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            referee_injury f1 = new referee_injury();
            f1.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string rid = textBox1.Text;
            if (rid != "11" && rid != "12" && rid != "13")
            {
                MessageBox.Show("Enter correct referee ID\nID must be either '11','12','13'", "Error");
                textBox1.Text = string.Empty;
            }
            else {
                string connetionString = "server=localhost;database=suii;uid=root;pwd=rakshit";
                using (MySqlConnection con = new MySqlConnection(connetionString))
                {
                    con.Open();
                    string query = "Select *from referee where rid='" + rid + "'";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();
                        StringBuilder sb = new StringBuilder();
                        while (reader.Read())
                        {
                            label4.Text = reader.GetString(1);
                            label5.Text = reader.GetString(2);
                            label6.Text = reader.GetString(3);
                        }
                    }
                }
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Referee_view_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            referee_player_view f1= new referee_player_view();
            f1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            referee_standing f1= new referee_standing();
            f1.Show();
            this.Hide();
        }
    }
}