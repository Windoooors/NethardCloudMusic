using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Setchin.NethardMusic
{
    internal class LyricParserDto
    {
        public class ContentDto
        {
            [JsonProperty("lyric")]
            public string Lyric;
        }
    }
}