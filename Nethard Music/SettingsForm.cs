using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetHard_Music
{
    public partial class SettingsForm : Form
    {
        public LoginForm loginForm;
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                loginForm.Enabled = true;
                LoginForm.address = textBox1.Text;
                File.WriteAllText(Application.StartupPath + @"\config.conf", textBox1.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("改了个寂寞");
            }
        }

        private void SettingsForm_UnLoad(object sender, EventArgs e)
        {
            loginForm.Enabled = true;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText(Application.StartupPath + @"\config.conf");
        }
    }
}
