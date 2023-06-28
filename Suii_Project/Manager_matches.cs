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
    public partial class Manager_matches : Form
    {
        string mid1;
        public Manager_matches(string mid)
        {
            InitializeComponent();
            mid1=mid;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Manager_matches_Load(object sender, EventArgs e)
        {
            string connetionString = "server=localhost;database=suii;uid=root;pwd=rakshit";
            using (MySqlConnection con = new MySqlConnection(connetionString))
            {
                con.Open();
                string query = "select homeTid, awayTid, score, winTid from plays where homeTid='" + mid1 + "' or awayTid='" + mid1 + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager_view f1=new Manager_view();
            this.Close();
            f1.Show();
        }
    }
}
