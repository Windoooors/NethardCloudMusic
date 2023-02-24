using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace Setchin.NethardCloudMusic
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
                Operator = new ApiOperator(baseUrl, ReadCookiesFromDisk(Application.StartupPath + @"\cookie.conf"));
            }
            else
            {
                File.WriteAllText(Application.StartupPath + @"\config.conf", "http://mscapi.setchin.com");
                Operator = new ApiOperator("http://mscapi.setchin.com", null);
            }
        }

        public static void WriteCookiesToDisk(string file, CookieContainer cookieJar)
        {
            using (Stream stream = File.Create(file))
            {
                try
                {
                    Console.Out.Write("Writing cookies to disk... ");
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, cookieJar);
                    Console.Out.WriteLine("Done.");
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("Problem writing cookies to disk: " + e.GetType());
                }
            }
        }

        public static CookieContainer ReadCookiesFromDisk(string file)
        {
            try
            {
                using (Stream stream = File.Open(file, FileMode.Open))
                {
                    Console.Out.Write("Reading cookies from disk... ");
                    BinaryFormatter formatter = new BinaryFormatter();
                    Console.Out.WriteLine("Done.");
                    return (CookieContainer)formatter.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Problem reading cookies from disk: " + e.GetType());
                return null;
            }
        }
    }
}