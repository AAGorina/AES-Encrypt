namespace Encrypt_AES
{
    partial class work_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.repeat_pswd_tb = new System.Windows.Forms.TextBox();
            this.pswd_tb = new System.Windows.Forms.TextBox();
            this.restrictions_btn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.save_file_btn = new System.Windows.Forms.Button();
            this.encrypt_btn = new System.Windows.Forms.Button();
            this.decrypt_btn = new System.Windows.Forms.Button();
            this.file_panel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.del_checkbox = new System.Windows.Forms.CheckBox();
            this.openfile_btn = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.text_panel = new System.Windows.Forms.Panel();
            this.file_panel.SuspendLayout();
            this.text_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Повтор пароля";
            // 
            // repeat_pswd_tb
            // 
            this.repeat_pswd_tb.Location = new System.Drawing.Point(227, 89);
            this.repeat_pswd_tb.Name = "repeat_pswd_tb";
            this.repeat_pswd_tb.Size = new System.Drawing.Size(252, 30);
            this.repeat_pswd_tb.TabIndex = 2;
            this.repeat_pswd_tb.UseSystemPasswordChar = true;
            // 
            // pswd_tb
            // 
            this.pswd_tb.Location = new System.Drawing.Point(227, 29);
            this.pswd_tb.Name = "pswd_tb";
            this.pswd_tb.Size = new System.Drawing.Size(252, 30);
            this.pswd_tb.TabIndex = 3;
            this.pswd_tb.UseSystemPasswordChar = true;
            // 
            // restrictions_btn
            // 
            this.restrictions_btn.Location = new System.Drawing.Point(568, 58);
            this.restrictions_btn.Name = "restrictions_btn";
            this.restrictions_btn.Size = new System.Drawing.Size(236, 30);
            this.restrictions_btn.TabIndex = 4;
            this.restrictions_btn.Text = "Сложность пароля";
            this.restrictions_btn.UseVisualStyleBackColor = true;
            this.restrictions_btn.Click += new System.EventHandler(this.restrictions_btn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 137);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(511, 313);
            this.textBox1.TabIndex = 5;
            // 
            // save_file_btn
            // 
            this.save_file_btn.Location = new System.Drawing.Point(568, 420);
            this.save_file_btn.Name = "save_file_btn";
            this.save_file_btn.Size = new System.Drawing.Size(236, 30);
            this.save_file_btn.TabIndex = 6;
            this.save_file_btn.Text = "Сохранить в файл";
            this.save_file_btn.UseVisualStyleBackColor = true;
            this.save_file_btn.Click += new System.EventHandler(this.save_file_btn_Click);
            // 
            // encrypt_btn
            // 
            this.encrypt_btn.Location = new System.Drawing.Point(568, 314);
            this.encrypt_btn.Name = "encrypt_btn";
            this.encrypt_btn.Size = new System.Drawing.Size(236, 30);
            this.encrypt_btn.TabIndex = 7;
            this.encrypt_btn.Text = "Зашифровать";
            this.encrypt_btn.UseVisualStyleBackColor = true;
            this.encrypt_btn.Click += new System.EventHandler(this.encrypt_btn_Click);
            // 
            // decrypt_btn
            // 
            this.decrypt_btn.Location = new System.Drawing.Point(568, 367);
            this.decrypt_btn.Name = "decrypt_btn";
            this.decrypt_btn.Size = new System.Drawing.Size(236, 30);
            this.decrypt_btn.TabIndex = 8;
            this.decrypt_btn.Text = "Дешифровать";
            this.decrypt_btn.UseVisualStyleBackColor = true;
            this.decrypt_btn.Click += new System.EventHandler(this.decrypt_btn_Click);
            // 
            // file_panel
            // 
            this.file_panel.Controls.Add(this.button1);
            this.file_panel.Controls.Add(this.textBox2);
            this.file_panel.Controls.Add(this.textBox3);
            this.file_panel.Controls.Add(this.label3);
            this.file_panel.Controls.Add(this.label4);
            this.file_panel.Controls.Add(this.label5);
            this.file_panel.Controls.Add(this.del_checkbox);
            this.file_panel.Controls.Add(this.openfile_btn);
            this.file_panel.Controls.Add(this.textBox4);
            this.file_panel.Controls.Add(this.button2);
            this.file_panel.Controls.Add(this.button3);
            this.file_panel.Location = new System.Drawing.Point(0, 0);
            this.file_panel.Name = "file_panel";
            this.file_panel.Size = new System.Drawing.Size(886, 464);
            this.file_panel.TabIndex = 14;
            this.file_panel.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(583, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(284, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Сложность пароля";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(211, 86);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(325, 30);
            this.textBox2.TabIndex = 3;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(211, 28);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(325, 30);
            this.textBox3.TabIndex = 2;
            this.textBox3.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Повтор пароля";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Пароль";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Входной файл";
            // 
            // del_checkbox
            // 
            this.del_checkbox.AutoSize = true;
            this.del_checkbox.Location = new System.Drawing.Point(30, 267);
            this.del_checkbox.Name = "del_checkbox";
            this.del_checkbox.Size = new System.Drawing.Size(385, 29);
            this.del_checkbox.TabIndex = 7;
            this.del_checkbox.Text = "Удалить входной файл после работы";
            this.del_checkbox.UseVisualStyleBackColor = true;
            // 
            // openfile_btn
            // 
            this.openfile_btn.Location = new System.Drawing.Point(670, 194);
            this.openfile_btn.Name = "openfile_btn";
            this.openfile_btn.Size = new System.Drawing.Size(197, 30);
            this.openfile_btn.TabIndex = 8;
            this.openfile_btn.Text = "Выбрать файл";
            this.openfile_btn.UseVisualStyleBackColor = true;
            this.openfile_btn.Click += new System.EventHandler(this.openfile_btn_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(178, 191);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(448, 30);
            this.textBox4.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(670, 265);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 30);
            this.button2.TabIndex = 11;
            this.button2.Text = "Зашифровать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(670, 344);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(197, 30);
            this.button3.TabIndex = 12;
            this.button3.Text = "Расшифровать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // text_panel
            // 
            this.text_panel.Controls.Add(this.decrypt_btn);
            this.text_panel.Controls.Add(this.encrypt_btn);
            this.text_panel.Controls.Add(this.save_file_btn);
            this.text_panel.Controls.Add(this.textBox1);
            this.text_panel.Controls.Add(this.pswd_tb);
            this.text_panel.Controls.Add(this.restrictions_btn);
            this.text_panel.Controls.Add(this.repeat_pswd_tb);
            this.text_panel.Controls.Add(this.label2);
            this.text_panel.Controls.Add(this.label1);
            this.text_panel.Location = new System.Drawing.Point(12, 12);
            this.text_panel.Name = "text_panel";
            this.text_panel.Size = new System.Drawing.Size(839, 461);
            this.text_panel.TabIndex = 15;
            this.text_panel.Visible = false;
            // 
            // work_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 485);
            this.Controls.Add(this.text_panel);
            this.Controls.Add(this.file_panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "work_form";
            this.Text = "Шифрование";
            this.file_panel.ResumeLayout(false);
            this.file_panel.PerformLayout();
            this.text_panel.ResumeLayout(false);
            this.text_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox repeat_pswd_tb;
        private System.Windows.Forms.TextBox pswd_tb;
        private System.Windows.Forms.Button restrictions_btn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button save_file_btn;
        private System.Windows.Forms.Button encrypt_btn;
        private System.Windows.Forms.Button decrypt_btn;
        private System.Windows.Forms.Panel file_panel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox del_checkbox;
        private System.Windows.Forms.Button openfile_btn;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel text_panel;
    }
}