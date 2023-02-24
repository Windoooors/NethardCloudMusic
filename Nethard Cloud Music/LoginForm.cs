using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Setchin.NethardCloudMusic
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
                Program.Operator.PhoneLogin(phoneNumberTextBox.Text, passwordTextBox.Text);
                Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("Çë¼ì²éÍøÂç»ò Netease Cloud Music Api µØÖ·ÉèÖÃ");
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (Program.Operator.Cookie.Count != 0)
            {
                AutoLogin();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (loginQrCodeKey == null)
                loginQrCodeKey = Program.Operator.GetLoginQrCodeKey();
            LoadQrCodeImage(Program.Operator.GetLoginQrCode(loginQrCodeKey).Split(',')[1]);
        }

        private void LoadQrCodeImage(string image)
        {
            byte[] bytes = Convert.FromBase64String(image);
            MemoryStream memoryStream = new MemoryStream(bytes);
            Bitmap bitmap = new Bitmap(memoryStream);
            pictureBox1.Image = bitmap;
        }

        private string loginQrCodeKey;

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //loginQrCodeKey = Program.Operator.GetLoginQrCodeKey();
        }

        private void QrCodeLogin()
        {
            try
            {
                var user = Program.Operator.QrCodeLogin(loginQrCodeKey);
                if (user == null)
                    MessageBox.Show("ÍøÂçÒì³£»òÄúÎ´È·ÈÏµÇÂ½");
                else
                {
                    Program.WriteCookiesToDisk(Application.StartupPath + @"\cookie.conf", Program.Operator.Cookie);
                    Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("µÇÂ¼Ê§°Ü£¬ÇëÖØÐÂµÇÂ½");
            }
        }

        private void AutoLogin() 
        {
            try
            {
                var user = Program.Operator.AutoLogin();
                if (user == null)
                    MessageBox.Show("ÍøÂçÒì³£»òÄúÎ´È·ÈÏµÇÂ½");
                else
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessageBox.Show("µÇÂ¼Ê§°Ü£¬ÇëÖØÐÂµÇÂ½");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QrCodeLogin();
        }
    }
}
