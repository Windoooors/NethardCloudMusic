using Newtonsoft.Json;

namespace Setchin.NethardMusic
{
    internal class IdNameDto
    {
        [JsonProperty("id")]
        public long Id;

        [JsonProperty("name")]
        public string Name;
    }
}
