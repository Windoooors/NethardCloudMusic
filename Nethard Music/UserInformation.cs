using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

namespace NetHard_Music
{
    public class UserInformation
    {
        public string nickname;
        public long uid;
        public List<string> songListNames = new List<string>();
        public List<long> songListIds = new List<long>();
        public CookieContainer savedCookie;

        public void Initialize(string json, CookieContainer cookie)
        {
            savedCookie = cookie;
            JToken jToken = JObject.Parse(json);
            nickname = jToken["profile"]["nickname"].ToString();
            uid = jToken["account"]["id"].ToObject<long>();
            JArray jArray = JArray.Parse(JObject.Parse(Request.Get(LoginForm.address + "/user/playlist?uid=" + uid.ToString(), cookie))["playlist"].ToString());
            for (int i = 0; i < jArray.Count; i++)
            {
                songListNames.Add(jArray[i]["name"].ToString());
                songListIds.Add(jArray[i]["id"].ToObject<long>());
            }
        }
    }
}
