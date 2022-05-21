using System;
using Newtonsoft.Json;
using Setchin.NethardCloudMusic.Collections;

namespace Setchin.NethardCloudMusic
{
    public class User : IEquatable<User>
    {
        private readonly long _id;
        private readonly string _nickname;

        public User(long id, string nickname)
        {
            _id = id;
            _nickname = nickname;
        }

        public static Playlist[] GetPlaylists(ApiOperator @operator, long userId)
        {
            string content = @operator.Get("user/playlist", new { Uid = userId });
            var dtos = JsonConvert.DeserializeObject<PlaylistsResponseDto>(content).Playlists;

            return dtos.Select(dto => dto.ToPlaylist()).ToArray();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public long Id { get { return _id; } }

        public string Nickname { get { return _nickname; } }

        private class PlaylistsResponseDto
        {
            [JsonProperty("playlist")]
            public PlaylistDto[] Playlists;
        }
    }
}
