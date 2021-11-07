using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Setchin.NethardMusic
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                Program.Operator.Login(phoneNumberTextBox.Text, passwordTextBox.Text);
                Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("请检查网络或 Netease Cloud Music Api 地址设置");
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }
    }
}
