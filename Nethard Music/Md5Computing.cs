using System.Security.Cryptography;
using System.Text;

namespace Setchin.NethardMusic
{
    public static class Md5Computing
    {
        public static string Compute(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            var md5 = MD5.Create();
            byte[] md5Bytes = md5.ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();

            foreach (byte b in md5Bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
