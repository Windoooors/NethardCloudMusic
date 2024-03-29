﻿using System;
using System.IO;
using System.Windows.Forms;

namespace Setchin.NethardCloudMusic
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("设置值不能为空");
            }
            else
            {
                File.WriteAllText(Application.StartupPath + @"\config.conf", textBox1.Text);
                Program.Operator = new ApiOperator(textBox1.Text, Program.Operator.Cookie);
                Close();
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Program.Operator.BaseUrl;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
