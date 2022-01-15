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
    public partial class Form2 : Form
    {
        MySqlConnection conn = connectionService.getConnection();
        string a, b, c, d;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO `data_ppdb`(`nis`, `nama`, `ttl`, `jk`, `sekolah_asal`, `Alamat`) VALUES (@nis,@nama,@ttl,@jk,@sekolah_asal,@Alamat)";
            cmd.Parameters.AddWithValue("@nis", textBox1.Text);
            cmd.Parameters.AddWithValue("@nama", textBox2.Text);
            cmd.Parameters.AddWithValue("@ttl", textBox3.Text);
            cmd.Parameters.AddWithValue("@jk", comboBox2.Text);
            cmd.Parameters.AddWithValue("@sekolah_asal", textBox4.Text);
            cmd.Parameters.AddWithValue("@alamat", textBox5.Text);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "insert into tb_pendaftaran values (@nis, @no_pendaftaran, @tanggal_pendaftaran, @gelombang, @kelengkapan, @keterangan)";
            cmd.Parameters.AddWithValue("@no_pendaftaran", textBox6.Text);
            cmd.Parameters.AddWithValue("@tanggal_pendaftaran", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@gelombang", comboBox1.Text);
            cmd.Parameters.AddWithValue("@kelengkapan", a + " " + b + " " + c + " " + d);
            cmd.Parameters.AddWithValue("@keterangan", textBox9.Text);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO `kontak`(`nis`, `nama`, `email`, `no_telp`) VALUES (@nis, @nama, @email, @no_telp)";
            cmd.Parameters.AddWithValue("@email", textBox7.Text);
            cmd.Parameters.AddWithValue("@no_telp", textBox8.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Input Data Berhasil");
            conn.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            a = checkBox5.Text;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            b = checkBox2.Text;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            c = checkBox3.Text;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            d = checkBox4.Text;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 oForm3 = new Form3();
            oForm3.ShowDialog();
        }
    }
}
