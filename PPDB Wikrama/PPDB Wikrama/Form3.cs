using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PPDB_Wikrama
{
    public partial class Form3 : Form
    {
        MySqlConnection conn = connectionService.getConnection();
        public Form3()
        {
            InitializeComponent();
        }

        public void lihatData()
        {
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM data_ppdb";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lihatData();
        }
    }
}
