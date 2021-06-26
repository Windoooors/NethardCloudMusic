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

                var userInformationForm = new UserInformationForm();
                userInformationForm.Intialize();
                userInformationForm.Show();
                Visible = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("��������� Netease Cloud Music Api ��ַ����");
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
