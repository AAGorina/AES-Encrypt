using System;
using System.Linq;
using System.Windows.Forms;

namespace Encrypt_AES
{
    public partial class password_restrictions_form : Form
    {
        private static work_form parent;
        public password_restrictions_form(work_form p, int mi, int ma, bool l, bool h, bool s)
        {
            InitializeComponent();
            parent = p;
            textBox1.Text = mi.ToString();
            textBox2.Text = ma.ToString();
            checkBox1.Checked = l;
            checkBox2.Checked = h;
            checkBox3.Checked = s;
        }

        private void confirm_btn_Click(object sender, EventArgs e)
        {
            string min_l = textBox1.Text;
            string max_l = textBox2.Text;
            bool low = checkBox1.Checked;
            bool high = checkBox2.Checked;
            bool spec = checkBox3.Checked;
            if (min_l == "" || max_l == "")
            {
                MessageBox.Show("Поля ограничения длины не могут быть пустыми", "Ошибка", MessageBoxButtons.OK);
            }
            else if (min_l.All(char.IsDigit) && max_l.All(char.IsDigit))
            {
                int mi = Convert.ToInt32(min_l);
                int ma = Convert.ToInt32(max_l);
                if (mi < 0 || ma < 0 || mi > ma)
                {
                    MessageBox.Show("Недопустимое значение длины", "Ошибка", MessageBoxButtons.OK);
                }
                else {
                    parent.set_min_max(mi, ma);
                    parent.set_restr(low, high, spec);
                    Close();
                }
            }
            else {
                MessageBox.Show("Недопустимое значение длины", "Ошибка", MessageBoxButtons.OK);
            }
        }
    }
}
