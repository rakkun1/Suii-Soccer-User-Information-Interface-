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
    public partial class Records : Form
    {
        public string pid1;
        public Records(string pid)
        {
            InitializeComponent();
            pid1 = pid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player_view f3 = new player_view();
            f3.Show();
            this.Close();
        }

        private void Records_Load(object sender, EventArgs e)
        { 
            string connetionString = "server=localhost;database=suii;uid=root;pwd=rakshit";
            using (MySqlConnection con = new MySqlConnection(connetionString))
            {
                con.Open();
                string query = "Select des from injury where pid= '" + pid1 + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                string query1 = "select count(*)from booking where pid='" + pid1 + "'";
                using (MySqlCommand cmd1 = new MySqlCommand(query1, con))
                {
                    MySqlDataReader reader1 = cmd1.ExecuteReader();
                    StringBuilder sb = new StringBuilder();
                    while (reader1.Read())
                    {
                        //if (reader1.GetString(0) == null)
                            //label3.Text = "0";
                        //else
                            label3.Text = reader1.GetString(0);
                    }
                }

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

