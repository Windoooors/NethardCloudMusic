using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Setchin.NethardMusic
{
    public partial class Playlist : List<Song>, IEquatable<Playlist>
    {
        private readonly long _id;
        private readonly string _name;
        private readonly bool _hasData = false;

        public Playlist(long id, string name, List<Song> songs)
        {
            _id = id;
            _name = name;

            if (songs != null)
            {
                AddRange(songs);
                _hasData = true;
            }
        }

        public long Id { get { return _id; } }

        public string Name { get { return _name; } }

        public bool HasData { get { return _hasData; } }

        public static Playlist GetPlaylist(ApiOperator @operator, long id)
        {
            string content = @operator.Get("playlist/detail", new { Id = id });
            var dto = JsonConvert.DeserializeObject<PlaylistResponseDto>(content);
            return dto.Playlist.ToPlaylist();
        }

        public Playlist GetData(ApiOperator @operator)
        {
            if (!_hasData)
            {
                return GetPlaylist(@operator, Id);
            }

            return this;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Playlist);
        }

        public bool Equals(Playlist other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        private class PlaylistResponseDto
        {
            [JsonProperty("playlist")]
            public PlaylistDto Playlist;
        }
    }
}
