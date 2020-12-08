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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgrenciNotlar ogrnot = new FrmOgrenciNotlar();
            ogrnot.no = textBox1.Text;
            ogrnot.Show();
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FrmOgretmen ogrislem = new FrmOgretmen();
            ogrislem.Show();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
