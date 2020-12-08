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
    public partial class FrmSınavNotlar : Form
    {
        public FrmSınavNotlar()
        {
            InitializeComponent();
        }

         SqlConnection baglanti = new SqlConnection(@"Data Source=MUSOGBA;Initial Catalog=Okul;Integrated Security=True");

        DataSet1TableAdapters.Tbl_notlarTableAdapter ds = new DataSet1TableAdapters.Tbl_notlarTableAdapter();

       

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotlarListesi(int.Parse(TxtOgrenciid.Text),byte.Parse(CmBDers.SelectedValue.ToString()));

        }

        int notid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtOgrenciid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();


        }
        int sinav1, sinav2, sinav3, proje;
        decimal ortalama;
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelleme(byte.Parse(CmBDers.SelectedValue.ToString()),int.Parse(TxtOgrenciid.Text),byte.Parse(TxtSınav1.Text.ToString()), byte.Parse(TxtSınav2.Text.ToString()), byte.Parse(TxtSınav3.Text.ToString()), byte.Parse(TxtProje.Text.ToString()), decimal.Parse(TxtOrtalama.Text.ToString()), bool.Parse(TxtDurum.Text.ToString()),notid);
        }

        private void FrmSınavNotlar_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_dersler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmBDers.DisplayMember = "DERSAD";
            CmBDers.ValueMember = "DERSID";
            CmBDers.DataSource = dt;
            baglanti.Close();
        }
       
        private void BtnHesapla_Click(object sender, EventArgs e)
        {
           
       

            sinav1 = Convert.ToInt16(TxtSınav1.Text);
            sinav2 = Convert.ToInt16(TxtSınav2.Text);
            sinav3 = Convert.ToInt16(TxtSınav3.Text);
            proje = Convert.ToInt16(TxtProje.Text);
            ortalama=(sinav1+sinav2+sinav3+proje)/ 4;
            TxtOrtalama.Text = ortalama.ToString();
            if (ortalama <= 50)
            {
                TxtDurum.Text = "True";
            }
            else
            {
                TxtDurum.Text = "False";
            }
        }
    }
}
