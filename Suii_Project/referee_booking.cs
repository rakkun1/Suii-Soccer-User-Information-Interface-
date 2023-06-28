using MySql.Data.MySqlClient;
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

namespace Suii_Project
{
    public partial class referee_booking : Form
    {
        public referee_booking()
        {
            InitializeComponent();
        }

        private void referee_booking_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cid = textBox1.Text;
            string time = textBox3.Text;
            int pid = int.Parse(textBox2.Text);
            if (pid > 25)
            {
                MessageBox.Show("Enter valid Player ID", "Error");
                textBox2.Text = string.Empty;
            }
            else
            {
                string connetionString = "server=localhost;database=suii;uid=root;pwd=rakshit";
                using (MySqlConnection con = new MySqlConnection(connetionString))
                {
                    con.Open();
                    string query = "Insert into booking values('" + cid + "','" + pid + "','" + time + "')";
                    MySqlCommand updateCommand = new MySqlCommand(query, con);
                    updateCommand.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("Added successfully");
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Referee_view f1 = new Referee_view();
            f1.Show();
            this.Close();
        }
    }
}
