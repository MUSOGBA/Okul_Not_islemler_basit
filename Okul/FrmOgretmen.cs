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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

       

        

        private void BtnKulup_Click(object sender, EventArgs e)
        {
            FrmKulup frmkulup = new FrmKulup();
            frmkulup.Show();
        }

        private void BtnDersler_Click(object sender, EventArgs e)
        {

            FrmDersler frmders = new FrmDersler();
            frmders.Show();
        }

        private void BtnOgrenci_Click(object sender, EventArgs e)
        {
            FrmOgrenci frmogr = new FrmOgrenci();
            frmogr.Show();
        }

        private void BtnSınavNotlar_Click(object sender, EventArgs e)
        {
            FrmSınavNotlar frmsn = new FrmSınavNotlar();
            frmsn.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
