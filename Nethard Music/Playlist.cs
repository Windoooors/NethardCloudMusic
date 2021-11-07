using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Setchin.NethardMusic.Collections;
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
            var firstDto = JsonConvert.DeserializeObject<PlaylistResponseDto>(content);
            string postContent = string.Empty;

            foreach (PlaylistDto.TrackIdDto trackIdDto in firstDto.Playlist.TrackIds) {
                postContent += trackIdDto.id + ",";
            }
            postContent = postContent.Substring(0, postContent.Length - 1);
            List<string> partedPostContents = new List<string>();
            int a = (int)Math.Floor((decimal)(postContent.Split(',').Length / 300));
            if (a >= 1)
            {
                for (int i = 0; i < a; i++)
                {
                    var b = "ids=";
                    if (i + 1 <= a)
                    {
                        for (int j = i * 300; j < (i + 1) * 300; j++)
                        {
                            b += postContent.Split(',')[j] + ",";
                        }
                        b = b.Substring(0, b.Length - 1);
                    }
                    else
                    {
                        for (int j = a * 300; j < postContent.Split(',').Length; j++)
                        {
                            b += postContent.Split(',')[j] + ",";
                        }
                        b = b.Substring(0, b.Length - 1);
                    }
                    partedPostContents.Add(@operator.Post("song/detail", b));
                }
            }
            else 
            {
                var b = "ids=";
                for (int j = 0; j < postContent.Split(',').Length; j++)
                {
                    b += postContent.Split(',')[j] + ",";
                }
                b = b.Substring(0, b.Length - 1);
                partedPostContents.Add(@operator.Post("song/detail", b));
            }

            List<SonglistDto.TrackDto> tracks = new List<SonglistDto.TrackDto>();

            foreach (string c in partedPostContents)
            {
                tracks.AddRange(JsonConvert.DeserializeObject<SonglistDto>(c).Tracks);
            }

            List<Song> songs = null;

            if (tracks != null)
            {
                songs = tracks.Select(track => new Song(
                    track.Id,
                    track.Name,
                    track.Artists.Select(artist => new Artist(artist.Id, artist.Name)).ToArray(),
                    new Album(track.Album.Id, track.Album.Name)))
                    .ToList();
            }

            return new Playlist(id, firstDto.Playlist.Name, songs);
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

        private class SonglistResponseDto 
        {
            [JsonProperty("songs")]
            public SonglistDto Songlist;
        }
    }
}
