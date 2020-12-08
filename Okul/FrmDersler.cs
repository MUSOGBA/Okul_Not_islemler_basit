using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Okul
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_derslerTableAdapter ds = new DataSet1TableAdapters.Tbl_derslerTableAdapter();

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmDersler_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = ds.DersListesi();

        

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkleme(Txtdersadi.Text.ToUpper());
            MessageBox.Show("Ders Ekleme İşlemi Başarıyla Gerçekleştirilmiştir.");    
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
           ds.DersSilme(byte.Parse(Txtdersid.Text));
            MessageBox.Show("Ders Silme İşlemi Başarıyla Gerçekleştirilmiştir.");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            Txtdersid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            Txtdersadi.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(Txtdersadi.Text.ToUpper(),byte.Parse(Txtdersid.Text));
            MessageBox.Show("Ders Güncelleme İşlemi Başarıyla Gerçekleştirilmiştir.");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
