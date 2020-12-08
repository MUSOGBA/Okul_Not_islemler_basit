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
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }

        public string no;

        SqlConnection baglanti = new SqlConnection(@"Data Source=MUSOGBA;Initial Catalog=Okul;Integrated Security=True");

        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM from Tbl_notlar INNER JOIN Tbl_dersler ON Tbl_notlar.DERSID = Tbl_dersler.DERSID WHERE OGRID = @p1",baglanti);

            komut.Parameters.AddWithValue("@p1",no);
            // this.Text = no.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt=new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select OGRID,ograd,ogrsoyad from Tbl_ogrenciler where OGRID=@d1",baglanti);
            komut1.Parameters.AddWithValue("@d1",no);

            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                this.Text = dr[1] + " " + dr[2].ToString();
            }
            baglanti.Close();

        }
    }
}
