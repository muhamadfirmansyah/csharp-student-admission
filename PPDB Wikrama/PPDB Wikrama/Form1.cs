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
    public partial class Form1 : Form
    {
        MySqlConnection conn = connectionService.getConnection();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login(textBox1.Text, textBox2.Text))
            {
                textBox1.Text = "";
                textBox2.Text = "";
                Form2 oForm2 = new Form2();
                oForm2.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Gagal");
                textBox2.Text = "";
            }
        }

        private Boolean login(string sUsername, string sPassword)
        {
            string SQL = "SELECT username, password From admin";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(SQL, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if ((sUsername == reader.GetString(0)) && (sPassword == reader.GetString(1)))
                {
                    return true;
                }
            }
            conn.Close();
            return false;
        }
    }
}