using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Setchin.NethardCloudMusic.Collections;

namespace Setchin.NethardCloudMusic
{
    public partial class ApiOperator
    {
        public User PhoneLogin(string number, string password)
        {
            string md5Password = Md5Computing.Compute(password);

            string content = Get("login/cellphone", new { Phone = number, Md5Password = md5Password });
            var dto = JsonConvert.DeserializeObject<UserDto>(content);

            return _user = new User(dto.Data.Profile.UserId, dto.Data.Profile.Nickname);
        }

        public User QrCodeLogin(string key)
        {
            string checkContent = Post("login/qr/check", new { Key = key });
            var stateDto = JsonConvert.DeserializeObject<QrCodeLoginStateDto>(checkContent);

            if (stateDto.Code == 803)
            {
                //_cookie = new CookieContainer().Add();
                string content = Post("login/status", new { });
                var dto = JsonConvert.DeserializeObject<UserDto>(content);
                return _user = new User(dto.Data.Profile.UserId, dto.Data.Profile.Nickname);
            }
            else
                return null;
        }

        public User AutoLogin()
        {
            try
            {
                //_cookie = new CookieContainer().Add();
                string content = Post("login/status", new { });
                var dto = JsonConvert.DeserializeObject<UserDto>(content);
                return _user = new User(dto.Data.Profile.UserId, dto.Data.Profile.Nickname);
            }
            catch
            {
                return null;
            }
        }

        public string GetLoginQrCode(string key)
        {
            string content = Get("login/qr/create", new { Key = key, qrimg = true});
            return JsonConvert.DeserializeObject<LoginQrCodeDto>(content).Data.QrImage;
        }

        public string GetLoginQrCodeKey()
        {
            string content = Get("login/qr/key", new { });
            return JsonConvert.DeserializeObject<LoginQrCodeKeyDto>(content).Data.Key;
        }

        private class LoginQrCodeDto
        {
            [JsonProperty("data")]
            public DataDto Data;

            public class DataDto
            {
                [JsonProperty("qrimg")]
                public string QrImage;
            }
        }

        private class LoginQrCodeKeyDto
        {
            [JsonProperty("data")]
            public DataDto Data;

            public class DataDto
            {
                [JsonProperty("unikey")]
                public string Key;
            }
        }

        private class UserDto
        {
            [JsonProperty("data")]
            public DataDto Data;

            public class DataDto
            {
                [JsonProperty("profile")]
                public ProfileInfo Profile;
            }

            public class ProfileInfo
            {
                [JsonProperty("nickname")]
                public string Nickname;

                [JsonProperty("userId")]
                public long UserId;
            }
        }

        private class QrCodeLoginStateDto
        {
            [JsonProperty("code")]
            public int Code;

            [JsonProperty("cookie")]
            public string Cookie;
        }
    }

    public partial class ApiOperator
    {
        private readonly CookieContainer _cookie = new CookieContainer();
        private readonly string _baseUrl;

        private User _user;

        public string BaseUrl { get { return _baseUrl; } }
        public CookieContainer Cookie { get { return _cookie; } }

        public User User { get { return _user; } }

        public ApiOperator(string baseUrl, CookieContainer cookie)
        {
            if (baseUrl == null)
            {
                throw new ArgumentNullException("baseUrl");
            }
            if (cookie != null)
            {
                _cookie = cookie;
            }

            _baseUrl = baseUrl;
        }

        public string Post(string path, object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            string postableContent = ToUriQueryString(content);
            return PostCore(new UriBuilder(_baseUrl) { Path = path }.Uri.AbsoluteUri, postableContent);
        }

        public string Get(string path, object content)
        {
            string query = content == null ? null : ToUriQueryString(content);
            return GetCore(new UriBuilder(_baseUrl) { Path = path, Query = query }.Uri.AbsoluteUri);
        }


        public void Download(string url, long songId)
        {
            if (Directory.Exists(System.Windows.Forms.Application.StartupPath + "\\temp"))
            {
                new DirectoryInfo(System.Windows.Forms.Application.StartupPath + "\\temp").Delete(true);
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\temp");
            }
            else
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath + "\\temp");

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = _cookie;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0;)";

            var response = (HttpWebResponse)request.GetResponse();

            var stream = new FileStream(System.Windows.Forms.Application.StartupPath + "\\temp\\" + songId.ToString() + ".mp3", FileMode.CreateNew);

            var responseStream = response.GetResponseStream();

            byte[] bytes = new byte[1024];
            int size = responseStream.Read(bytes, 0, (int)bytes.Length);
            long totalDownloadBytes = 0;

            while (size > 0)
            {
                totalDownloadBytes += size;
                stream.Write(bytes, 0, size);
                size = responseStream.Read(bytes, 0, (int)bytes.Length);
            }
            stream.Close();
        }

        private static string ToUriQueryString(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            return string.Join("&", obj.GetType().GetProperties().Select(prop =>
                {
                    object value = prop.GetValue(obj, null);
                    return Uri.EscapeDataString(ToUnderScoreCase(prop.Name)) + "=" + Uri.EscapeDataString(value == null ? "null" : value.ToString());
                }).ToArray());
        }

        private static string ToUnderScoreCase(string str)
        {
            var builder = new StringBuilder();

            foreach (char c in str)
            {
                if (char.IsUpper(c))
                {
                    builder.Append('_');
                    builder.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    builder.Append(c);
                }
            }

            if (builder[0] == '_')
            {
                builder.Remove(0, 1);
            }

            return builder.ToString();
        }

        private string PostCore(string url, string content)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.CookieContainer = _cookie;
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0;)";

            byte[] data = Encoding.UTF8.GetBytes(content);
            request.ContentLength = data.Length;

            using (var reqStream = request.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            string result;
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        private string GetCore(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = _cookie;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0;)";

            var response = (HttpWebResponse)request.GetResponse();

            string result;
            using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
