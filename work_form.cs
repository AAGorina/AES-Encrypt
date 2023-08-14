using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Encrypt_AES
{
    public partial class work_form : Form
    {
        public static int min_length;
        public static int max_length;
        public static bool low;
        public static bool high;
        public static bool spec;

        private OpenFileDialog ofd;
        private SaveFileDialog sfd;
        public work_form(int reg)
        {
            InitializeComponent();
            min_length = 1;
            max_length = 16;
            low = false;
            high = false;
            spec = false;
            if (reg == 0)
            {
                text_panel.Visible = true;
            }
            else {
                file_panel.Visible = true;
            }
            ofd = new OpenFileDialog();
            sfd = new SaveFileDialog();
            ofd.Multiselect = false;
        }

        private void restrictions_btn_Click(object sender, EventArgs e)
        {
            password_restrictions_form n_prf = new password_restrictions_form(this, min_length, max_length, low, high, spec);
            n_prf.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            password_restrictions_form n_prf = new password_restrictions_form(this, min_length, max_length, low, high, spec);
            n_prf.Show();
        }

        private void openfile_btn_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK) {
                string path = ofd.FileName;
                textBox4.Text = path;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] info = default(byte[]);
            Encoding enc = Encoding.Default;
            if (pswd_check(textBox2.Text, textBox3.Text))
            {
                using (StreamReader sr = new StreamReader(textBox4.Text, enc))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        sr.BaseStream.CopyTo(ms);
                        info = ms.ToArray();
                    }
                }

                var md5 = MD5.Create();
                byte[] key = md5.ComputeHash(Encoding.Default.GetBytes(textBox3.Text));
                byte[] chip = AES_128.encrypt(info, key);

                if (del_checkbox.Checked) {
                    File.Delete(textBox4.Text);
                }

                if (sfd.ShowDialog() == DialogResult.OK) {
                    if (sfd.FileName == "")
                    {
                        MessageBox.Show("Файл сохранения не выбран", "Ошибка", MessageBoxButtons.OK);
                    }
                    else {
                        File.WriteAllBytes(sfd.FileName, chip);
                        //File.WriteAllText(sfd.FileName, Encoding.Default.GetString(chip));
                        MessageBox.Show("Файл сохранен", "ОК", MessageBoxButtons.OK);
                    }
                }
            }
            else {
                MessageBox.Show("Нарушение пароля. \nПроверьте совпадение паролей и установленные ограничения.", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private static bool pswd_check(string s1, string s2) {
            bool result = false;
            bool len = s1.Length >= min_length && s1.Length <= max_length;
            if (s1 != s2)
            {
                result = false;
            }
            else if (len && (!low || have_low(s1)) && (!high || have_high(s1)) && (!spec || have_spec(s1))) {
                result = true;
            }
            return result;
        }
        private static bool have_low(string s) {
            bool result = false;
            int i = 0;
            while (i < s.Length && !result)
            {
                result = char.IsLower(s[i]);
                i++;
            }
            return result;
        }
        private static bool have_high(string s) {
            bool result = false;
            int i = 0;
            while (i < s.Length && !result)
            {
                result = char.IsUpper(s[i]);
                i++;
            }
            return result;
        }
        private static bool have_spec(string s) {
            bool result = false;
            int i = 0;
            string tmp = "!@'#$;:%^&*(){}|/,>.<?`\\";
            while (i < tmp.Length && !result) {
                result = s.Contains(tmp[i]);
                i++;
            }
            return result;
        }
        public void set_min_max(int mi, int ma) {
            min_length = mi;
            max_length = ma;
        }
        public void set_restr(bool l, bool h, bool s) {
            low = l;
            high = h;
            spec = s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] info = default(byte[]);

            if (pswd_check(textBox2.Text, textBox3.Text))
            {
                Encoding enc = Encoding.Default;
                using (StreamReader sr = new StreamReader(textBox4.Text, enc))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        sr.BaseStream.CopyTo(ms);
                        info = ms.ToArray();
                    }
                }

                if (del_checkbox.Checked)
                {
                    File.Delete(textBox4.Text);
                }

                var md5 = MD5.Create();
                byte[] key = md5.ComputeHash(Encoding.Default.GetBytes(textBox3.Text));
                byte[] chip = AES_128.decrypt(info, key);
                if (AES_128.check_sign(chip))
                {
                    chip = AES_128.del_sign(chip);
                    MessageBox.Show("Расшифровано корректно.", "Ок", MessageBoxButtons.OK);
                }
                else {
                    MessageBox.Show("Расшифровано некорректно.", "Ошибка", MessageBoxButtons.OK);
                }

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FileName == "")
                    {
                        MessageBox.Show("Файл сохранения не выбран", "Ошибка", MessageBoxButtons.OK);
                    }
                    else
                    {
                        File.WriteAllBytes(sfd.FileName, chip);
                        MessageBox.Show("Файл сохранен", "ОК", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Нарушение пароля. \nПроверьте совпадение паролей и установленные ограничения.", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void encrypt_btn_Click(object sender, EventArgs e)
        {
            if (pswd_check(pswd_tb.Text, repeat_pswd_tb.Text))
            {
                if (textBox1.Text != "")
                {
                    byte[] info = Encoding.Default.GetBytes(textBox1.Text);
                    var md5 = MD5.Create();
                    byte[] key = md5.ComputeHash(Encoding.Default.GetBytes(pswd_tb.Text));
                    byte[] chip = AES_128.encrypt(info, key);

                    textBox1.Text = Encoding.Default.GetString(chip);
                }
                else {
                    MessageBox.Show("Текст для работы отсутствует.", "Ошибка", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("Нарушение пароля. \nПроверьте совпадение паролей и установленные ограничения.", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void decrypt_btn_Click(object sender, EventArgs e)
        {

            if (pswd_check(pswd_tb.Text, repeat_pswd_tb.Text))
            {
                if (textBox1.Text != "")
                {
                    byte[] info = Encoding.Default.GetBytes(textBox1.Text);
                    var md5 = MD5.Create();
                    byte[] key = md5.ComputeHash(Encoding.Default.GetBytes(pswd_tb.Text));
                    byte[] chip = AES_128.decrypt(info, key);

                    if (AES_128.check_sign(chip))
                    {
                        chip = AES_128.del_sign(chip);
                        MessageBox.Show("Расшифровано корректно.", "Ок", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Расшифровано некорректно.", "Ошибка", MessageBoxButtons.OK);
                    }

                    textBox1.Text = Encoding.Default.GetString(chip);
                }
                else
                {
                    MessageBox.Show("Текст для работы отсутствует.", "Ошибка", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Нарушение пароля. \nПроверьте совпадение паролей и установленные ограничения.", "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void save_file_btn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FileName == "")
                    {
                        MessageBox.Show("Файл сохранения не выбран", "Ошибка", MessageBoxButtons.OK);
                    }
                    else
                    {
                        File.WriteAllBytes(sfd.FileName, Encoding.Default.GetBytes(textBox1.Text));
                        MessageBox.Show("Файл сохранен", "ОК", MessageBoxButtons.OK);
                    }
                }
            }
            else {
                MessageBox.Show("Текст для сохранения отсутсвует.", "Ошибка", MessageBoxButtons.OK);
            }
        }

    }
}
