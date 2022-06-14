using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace rehberr
{
    public partial class KisiEkle : Form
    {
        public KisiEkle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=rehberr.mdb");
        private void KisiEkle_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select iladi from iller order by iladi",baglanti);
            OleDbDataReader oku = komut.ExecuteReader();           
            while (oku.Read())
            {
                comboBox1.Items.Add(oku["iladi"]);
            }
            baglanti.Close();
        }
        string kimlik;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            comboBox2.Items.Clear();
            OleDbCommand komut = new OleDbCommand("select kimlik from iller where iladi='" + comboBox1.Text + "'",baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
              kimlik=Convert.ToString(oku["kimlik"]);
            }
            OleDbCommand komut1 = new OleDbCommand("select ilceAdi from İLCE where ilıd='" + kimlik + "'",baglanti);
            OleDbDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {
                comboBox2.Items.Add(oku1["ilceAdi"]);
            }
            baglanti.Close();
        }
       
        string ilıd, ilceadi;
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut1 = new OleDbCommand("select kimlik from iller where iladi='" + comboBox1.Text + "'", baglanti);
            OleDbDataReader oku = komut1.ExecuteReader();
            while (oku.Read())
            {
                ilıd = Convert.ToString(oku["kimlik"]);
            }
            OleDbCommand komut2 = new OleDbCommand("select kimlik from İLCE where ilceAdi='" +comboBox2.Text+ "'", baglanti);
            OleDbDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                ilceadi = Convert.ToString(oku2["kimlik"]);
            }
            OleDbCommand komut = new OleDbCommand("insert into kisilistesi(ad,soyad,firmadi,yetkili,tc,tel1,tel2,gsm,fax,mail,web,il,ilce,adres) values(@ad,@soyad,@firmadi,@yetkili,@tc,@tel1,@tel2,@gsm,@fax,@mail,@web,@il,@ilce,@adres)", baglanti);
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@soyad", textBox2.Text);
            komut.Parameters.AddWithValue("@firmadi", textBox3.Text);
            komut.Parameters.AddWithValue("@yetkili", textBox4.Text);
            komut.Parameters.AddWithValue("@tc", textBox8.Text);
            komut.Parameters.AddWithValue("@tel1", textBox7.Text);
            komut.Parameters.AddWithValue("@tel2", textBox6.Text);
            komut.Parameters.AddWithValue("@gsm", textBox5.Text);
            komut.Parameters.AddWithValue("@fax", textBox12.Text);
            komut.Parameters.AddWithValue("@mail", textBox11.Text);
            komut.Parameters.AddWithValue("@web", textBox10.Text);
            komut.Parameters.AddWithValue("@il",ilıd);
            komut.Parameters.AddWithValue("@ilce",ilceadi);
            komut.Parameters.AddWithValue("@adres", textBox15.Text);
            komut.ExecuteNonQuery();
           
            MessageBox.Show("Kaydedildi");
        }
    }
}
