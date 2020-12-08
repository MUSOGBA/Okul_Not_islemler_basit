using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Okul
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        string c = "";
        SqlConnection baglanti = new SqlConnection(@"Data Source=MUSOGBA;Initial Catalog=Okul;Integrated Security=True");

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrencilerListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_kulupler WHERE DURUM=1",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbKulup.DisplayMember = "KULUPADI";
            CmbKulup.ValueMember = "KULUPID";
            CmbKulup.DataSource = dt;
            baglanti.Close();
        }
        string cins="";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            TxtOgrenciid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtOgrenciadi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtOgrenciSoyadi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbKulup.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            cins = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (cins == "Kız")

            {

                radioButton1.Checked = true;

                radioButton2.Checked = false;

            }

            if (cins == "Erkek")

            {

                radioButton1.Checked = false;

                radioButton2.Checked = true;

            }
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
           

            if (radioButton1.Checked==true)
            {
                c = "Kız";
            }
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }

            ds.OgrenciEkleme(TxtOgrenciadi.Text,TxtOgrenciSoyadi.Text,byte.Parse(CmbKulup.SelectedValue.ToString()),c);
            MessageBox.Show("Ekleme İşlemei Başarıyla Gerçekleştirilmiştir.");
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrencilerListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSilme(int.Parse(TxtOgrenciid.Text));
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(TxtOgrenciadi.Text,TxtOgrenciSoyadi.Text,byte.Parse(CmbKulup.SelectedValue.ToString()),c,int.Parse(TxtOgrenciid.Text));
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciAra(TxtAra.Text);
        }
    }
}
