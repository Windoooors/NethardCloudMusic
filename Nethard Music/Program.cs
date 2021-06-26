using System;
using System.IO;
using System.Windows.Forms;

namespace Setchin.NethardMusic
{
    static class Program
    {
        public static ApiOperator Operator;
        public static PlayerForm Player;

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

            Application.Run(new LoginForm());
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