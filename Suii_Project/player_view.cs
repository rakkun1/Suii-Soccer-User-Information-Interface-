using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Suii_Project
{
    public partial class player_view : Form
    {
        public player_view()
        {
            InitializeComponent();
        }
        public int pid1;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private bool isEdit = true;
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int pid;
            if (!int.TryParse(textBox4.Text, out pid))
            {
                MessageBox.Show("Invalid Player ID!\n Player ID must be between 1 and 25", "Error");
                textBox4.Text = string.Empty;
                pid1 = pid;
            }
            else if (pid>25)
            {
                MessageBox.Show("Invalid Player ID!\n Player ID must be between 1 and 25", "Error");
                textBox1.Text = String.Empty;
                textBox2.Text = String.Empty;
                textBox3.Text = String.Empty;
                textBox4.Text= String.Empty;
                label2.Text = String.Empty;
                label11.Text = String.Empty;
                label14.Text = String.Empty;
            }
            else {
                button3.Enabled = true;
                button4.Enabled = true;
                string connetionString = "server=localhost;database=suii;uid=root;pwd=rakshit";
            using (MySqlConnection con = new MySqlConnection(connetionString))
            {
                con.Open();
                string query = "Select Pname, Page, jerseyno, Rating, Ppos, Tname from player natural join teams where pid= '" + pid + "'";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    StringBuilder sb = new StringBuilder();
                    while (reader.Read())
                    {
                        textBox1.Text = reader.GetString(1);
                        textBox2.Text = reader.GetString(4);
                        textBox3.Text = reader.GetString(2);
                        label2.Text = reader.GetString(0);
                        label3.Text = reader.GetString(5);
                        label11.Text = reader.GetString(3);


                    }
                    reader.Close();
                }
                string query1 = "select count(gid) from goals where pid= '" + pid + "'";
                using (MySqlCommand cmd1 = new MySqlCommand(query1, con))
                {
                    MySqlDataReader reader1 = cmd1.ExecuteReader();
                    StringBuilder sb1 = new StringBuilder();
                    while (reader1.Read())
                    {
                        label14.Text = reader1.GetString(0);
                    }
                }
            }

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                button2.Text = "Submit";
                textBox1.Enabled = !textBox1.Enabled;
                textBox2.Enabled = !textBox2.Enabled;
                textBox3.Enabled = !textBox3.Enabled;
                isEdit = false;
            }
            else if (!isEdit)
            {
                button2.Text = "Edit";
                textBox1.Enabled = !textBox1.Enabled;
                textBox2.Enabled = !textBox2.Enabled;
                textBox3.Enabled = !textBox3.Enabled;
                isEdit = true;
                string a = textBox1.Text;
                string b = textBox2.Text;
                int c = int.Parse(textBox3.Text);
                string connetionString = "server=localhost;database=suii;uid=root;pwd=rakshit";
                using (MySqlConnection con = new MySqlConnection(connetionString))
                {
                    con.Open();
                    string query = "Update player set page ='" + a + "',ppos='"+b+"',jerseyno='"+c+"'where pid='"+pid1+"'";
                    MySqlCommand updateCommand = new MySqlCommand(query, con);
                    updateCommand.ExecuteNonQuery();
                }

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string pid = textBox4.Text;
            Records f2 = new Records(pid);
            this.Hide();
            f2.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string name = label2.Text;
            string pid= textBox4.Text;
            matches f4 = new matches(pid,name);
            this.Hide();
            f4.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
