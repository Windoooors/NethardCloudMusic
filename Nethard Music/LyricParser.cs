using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Setchin.NethardMusic
{
    public class LyricParser
    {
        public List<string> content = new List<string>();
        public List<double> time = new List<double>();

        private string _lrcContent;
        private string _lyricContent;

        public void GetLyric(long id)
        {
            var _content = Program.Operator.Get("lyric", new { Id = id });

            try
            {
                _lrcContent = JObject.Parse(_content)["lrc"].ToString();
                _lyricContent = JsonConvert.DeserializeObject<LyricParserDto.ContentDto>(_lrcContent).Lyric;

                content.Clear();
                time.Clear();
                for (int i = 0; i < _lyricContent.Split('\n').Length - 1; i++)
                {
                    content.Add(_lyricContent.Split('\n')[i].Split(']')[1]);
                    double _time;
                    _time = Int32.Parse(_lyricContent.Split('\n')[i].Split(']')[0].Split('[')[1].Split(':')[0]) * 60 + Double.Parse(_lyricContent.Split('\n')[i].Split(']')[0].Split('[')[1].Split(':')[1]);
                    time.Add(_time);
                }
            }
            catch {
                content.Clear();
                time.Clear();

                content.Add("暂无歌词");
                time.Add(0);
            }
        }
    }
}
