using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encrypt_AES
{
    public partial class mode_form : Form
    {
        public mode_form()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form aboutbox = new AboutBox();
            aboutbox.ShowDialog();
        }

        private void file_btn_Click(object sender, EventArgs e)
        {
            work_form n_tf = new work_form(1);
            n_tf.Show();
        }

        private void text_btn_Click(object sender, EventArgs e)
        {
            work_form n_tf = new work_form(0);
            n_tf.Show();
        }
    }
}
