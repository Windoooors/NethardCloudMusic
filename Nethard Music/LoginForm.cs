using System;
using System.IO;
using System.Windows.Forms;

namespace NetHard_Music
{
    public partial class LoginForm : Form
    {
        public static string address;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                UserInformationForm userInformationForm = new UserInformationForm();
                userInformationForm.userInformation = new UserInformation();
                userInformationForm.userInformation.Initialize(Request.Get(address + "/login/cellphone?phone=" + phoneNumberTextBox.Text + "&password=" + passwordTextBox.Text, null), Request.Cookie(address + "/login/cellphone?phone=" + phoneNumberTextBox.Text + "&password=" + passwordTextBox.Text));
                userInformationForm.Intialize();
                userInformationForm.Show();
                this.Visible = false;
            }
            catch
            {
                MessageBox.Show("请检查网络或 Netease Cloud Music Api 地址设置");
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
            settingsForm.loginForm = this;
            this.Enabled = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + @"\config.conf"))
                address = File.ReadAllText(Application.StartupPath + @"\config.conf");
            else
            {
                File.WriteAllText(Application.StartupPath + @"\config.conf", "http://mscapi.setchin.com");
                address = "http://mscapi.setchin.com";
            }
        }
    }
}
