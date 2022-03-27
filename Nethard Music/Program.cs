using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Setchin.NethardMusic
{
    static class Program
    {
        public static ApiOperator Operator;
        public static PlayerForm Player;
        public static System.Drawing.Text.PrivateFontCollection PrivateFonts;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitializeOperator();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Player = new PlayerForm();

            new LoginForm().ShowDialog();

            if (Operator.User == null)
            {
                return;
            }

            PrivateFonts = new System.Drawing.Text.PrivateFontCollection();
            PrivateFonts.AddFontFile(Application.StartupPath + @"\resources\font.ttf");

            var mainForm = new MainForm();
            mainForm.Initialize();

            Application.Run(mainForm);
        }

        private static void InitializeOperator()
        {
            if (File.Exists(Application.StartupPath + @"\config.conf"))
            {
                string baseUrl = File.ReadAllText(Application.StartupPath + @"\config.conf");
                Operator = new ApiOperator(baseUrl);
            }
            else
            {
                File.WriteAllText(Application.StartupPath + @"\config.conf", "http://mscapi.setchin.com");
                Operator = new ApiOperator("http://mscapi.setchin.com");
            }
        }
    }
}