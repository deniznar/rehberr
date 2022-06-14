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
    public partial class Anaform : Form
    {
        public Anaform()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kişiEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KisiEkle kayitEkle = new KisiEkle();
            kayitEkle.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked!=true)
            {
                button1.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox10.Enabled = false;
                textBox11.Enabled = false; 
                textBox12.Enabled = false;
                textBox8.Enabled = false;
                textBox15.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
            }
            else
            {
                temizle();
                getir();
                button1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                textBox10.Enabled = true;
                textBox11.Enabled = true;
                textBox12.Enabled = true;
                textBox15.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;

            }
        }

        private void kayıtGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KisiGuncelle kisigüncelle = new KisiGuncelle();
            kisigüncelle.Show();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=rehberr.mdb");
        public void getir()
        {
            baglanti.Open();
            OleDbDataAdapter komut = new OleDbDataAdapter("select*from kisilistesi", baglanti);
            DataTable dt = new DataTable();
            komut.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void a()
        {
            button1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox8.Enabled = false;
            textBox15.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }
        private void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox12.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            textBox15.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
           


        }
        private void Anaform_Load(object sender, EventArgs e)
        {
            getir();
            a();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbDataAdapter komut = new OleDbDataAdapter("select*from kisilistesi where ad like'"+textBox1.Text+"%' and soyad like'"+textBox2.Text+"%'and firmadi like'"+textBox3.Text+"%' and yetkili like '"+textBox4.Text+"%' and tc like'"+textBox8.Text+"%' and tel1 like'"+textBox7.Text+"%' and tel2 like'"+textBox6.Text+"%' and gsm like'"+textBox5.Text+"%'and fax like'"+textBox12.Text+"%' and mail like'"+textBox11.Text+"%' and web like '"+textBox10.Text+"%' and il like'"+comboBox1.Text+"%' and ilce like'"+comboBox2.Text+"%' and adres like '"+textBox15.Text+"%'", baglanti);
            DataTable dt = new DataTable();
            komut.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text=dataGridView1.CurrentRow.Cells["ad"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["soyad"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["firmadi"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["yetkili"].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells["tel1"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["tel2"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["gsm"].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells["fax"].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells["mail"].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells["web"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["il"].Value.ToString();
           comboBox2.Text = dataGridView1.CurrentRow.Cells["ilce"].Value.ToString();
            textBox15.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temizle();
            getir();
        }
        public void filtreliGetir()
        {
            baglanti.Open();
            OleDbDataAdapter komut = new OleDbDataAdapter("select*from kisilistesi where ad like'" + textBox1.Text + "%' and soyad like'" + textBox2.Text + "%'and firmadi like'" + textBox3.Text + "%' and yetkili like '" + textBox4.Text + "%' and tc like'" + textBox8.Text + "%' and tel1 like'" + textBox7.Text + "%' and tel2 like'" + textBox6.Text + "%' and gsm like'" + textBox5.Text + "%'and fax like'" + textBox12.Text + "%' and mail like'" + textBox11.Text + "%' and web like '" + textBox10.Text + "%' and il like'" + comboBox1.Text + "%' and ilce like'" + comboBox2.Text + "%' and adres like '" + textBox15.Text + "%'", baglanti);
            DataTable dt = new DataTable();
            komut.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                filtreliGetir();
            }
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                filtreliGetir();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                filtreliGetir();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                filtreliGetir();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                filtreliGetir();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                filtreliGetir();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                filtreliGetir();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                filtreliGetir();
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                filtreliGetir();
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                filtreliGetir();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                filtreliGetir();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                filtreliGetir();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                filtreliGetir();
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                filtreliGetir();
            }
        }
    }
}
