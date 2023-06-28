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
    public partial class player_view_manager : Form
    {
        public string mid1;
        public player_view_manager(string mid)
        {
            InitializeComponent();
            mid1 = mid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager_view f1 = new Manager_view();
            this.Close();
            f1.Show();
        }

        private void player_view_manager_Load(object sender, EventArgs e)
        {
            string connetionString = "server=localhost;database=suii;uid=root;pwd=rakshit";
            using (MySqlConnection con = new MySqlConnection(connetionString))
            {
                con.Open();
                string query = " select tname,pname,page,ppos,jerseyno,rating from player natural join teams where tid='" + mid1 + "'";
                MySqlCommand cmd = new MySqlCommand(query, con) ;
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                /*MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                DataGridView dgv = new DataGridView();
                dgv.DataSource = table;
                this.Controls.Add(dgv);
                dgv.Dock = DockStyle.Fill;
                dgv.AllowUserToAddRows = false;
                dgv.ReadOnly = true;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;*/
            }
        }
    }
}
