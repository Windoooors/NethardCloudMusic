﻿using Newtonsoft.Json;

namespace Setchin.NethardCloudMusic
{
    internal class IdNameDto
    {
        [JsonProperty("id")]
        public long Id;

        [JsonProperty("name")]
        public string Name;
    }
}
