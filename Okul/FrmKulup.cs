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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=MUSOGBA;Initial Catalog=Okul;Integrated Security=True");

        public void temizle()
        {
            Txtkulupadi.Text = "";
            Txtkulupid.Text = "";

        }
       
       public void listele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_kulupler WHERE DURUM=1",baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            temizle();
            baglanti.Close();
        }

        private void FrmKulup_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into  Tbl_kulupler(KULUPADI,DURUM) values (@k2,1)", baglanti);
          
            komut.Parameters.AddWithValue("@k2",Txtkulupadi.Text.ToUpper());
            komut.ExecuteNonQuery();
            MessageBox.Show("Kulup Ekleme İşlemei Başarıyla Gerçekleştirildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            baglanti.Close();
            temizle();
            listele();
        }

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtkulupid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            Txtkulupadi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("update  TBL_KULUPLER SET DURUM=0 WHERE KULUPID=@S1 ", baglanti);
            komut1.Parameters.AddWithValue("@s1", Txtkulupid.Text);
            komut1.ExecuteNonQuery();
            MessageBox.Show("Kulup Silme İşlemi Başarıyla Gerçekleştirilmiştir.");
            baglanti.Close();
            listele();
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("UPDATE Tbl_Kulupler SET KULUPADI=@g1 where KULUPID=@g2",baglanti);
            komut2.Parameters.AddWithValue("@g1",Txtkulupadi.Text);
            komut2.Parameters.AddWithValue("@g2",Txtkulupid.Text);
            komut2.ExecuteNonQuery();
            MessageBox.Show("Güncelleme İşlemi Başarıyla Gerçekleştirilmiştir.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            baglanti.Close();
            temizle();
            listele();
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
