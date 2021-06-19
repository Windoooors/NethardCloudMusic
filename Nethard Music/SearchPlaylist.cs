using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

namespace NetHard_Music
{
    public class SeachPlaylist
    {
        public List<string> songNames = new List<string>();
        public List<string> musicianNames = new List<string>();
        public List<string> albumNames = new List<string>();
        public List<long> songIds = new List<long>();
        public string listName;

        public void Initialize(long id, CookieContainer cookie)
        {
            JObject jObject = JObject.Parse(Request.Get(LoginForm.address + "/playlist/detail?id=" + id.ToString(), cookie));
            JArray jArray = JArray.Parse(jObject["playlist"]["tracks"].ToString());
            for (int i = 0; i < jArray.Count; i++)
            {
                songNames.Add(jArray[i]["name"].ToString());
                string musicians = string.Empty;
                for (int j = 0; j < JArray.Parse(jArray[i]["ar"].ToString()).Count; j++)
                {
                    if (j != JArray.Parse(jArray[i]["ar"].ToString()).Count - 1)
                        musicians += JArray.Parse(jArray[i]["ar"].ToString())[j]["name"].ToString() + " & ";
                    else
                        musicians += JArray.Parse(jArray[i]["ar"].ToString())[j]["name"].ToString();
                }
                musicianNames.Add(musicians);
                albumNames.Add(jArray[i]["al"]["name"].ToString());
                songIds.Add(jArray[i]["id"].ToObject<long>());
            }
            listName = jObject["playlist"]["name"].ToString();
        }
    }
}
