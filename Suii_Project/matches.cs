using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System.Numerics;

namespace Suii_Project
{
    public partial class matches : Form
    {
        public string pid, name1;
        public matches(string pid1, string name)
        {
            InitializeComponent();
            pid = pid1;
            name1= name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player_view f1 = new player_view();
            this.Close();
            f1.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void matches_Load(object sender, EventArgs e)
        {
            label2.Text = name1;
            string connetionString = "server=localhost;database=suii;uid=root;pwd=rakshit";
            using (MySqlConnection con = new MySqlConnection(connetionString))
            {
                con.Open();
                string query = "select hometid, awaytid,score,wintid from plays where hometid in(select tid from player where pid='" + pid + "') or awaytid in (select tid from player where pid='" + pid + "')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                /*{
                    MySqlDataReader reader = cmd.ExecuteReader();
                    StringBuilder sb = new StringBuilder();
                    while (reader.Read())
                    {
                        label5.Text = reader.GetString(0);
                        label6.Text = reader.GetString(1);
                        label7.Text = reader.GetString(2);
                        label8.Text = reader.GetString(3);
                    }*/
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
