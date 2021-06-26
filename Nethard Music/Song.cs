using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Setchin.NethardMusic
{
    public class Song : IEquatable<Song>
    {
        private readonly long _id;
        private readonly string _name;
        private readonly Artist[] _artists;
        private readonly Album _album;

        public Song(long id, string name, Artist[] artists, Album album)
        {
            _id = id;
            _name = name;
            _artists = artists;
            _album = album;
        }

        public static Song[] Search(ApiOperator @operator, string keywords)
        {
            string content = @operator.Get("search", new { Keywords = keywords, Type = 1 });
            var dtos = JsonConvert.DeserializeObject<SearchResponseDto>(content).Result.Songs;

            var songs = new List<Song>();

            foreach (var dto in dtos)
            {
                var artists = new List<Artist>();

                foreach (var artist in dto.Artists)
                {
                    artists.Add(new Artist(artist.Id, artist.Name));
                }

                songs.Add(new Song(dto.Id, dto.Name, artists.ToArray(), new Album(dto.Album.Id, dto.Album.Name)));
            }

            return songs.ToArray();
        }

        public static void Like(ApiOperator @operator, long id)
        {
            @operator.Get("like", new { Id = id });
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Song);
        }

        public bool Equals(Song other)
        {
            return other != null &&
                   Id == other.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + Id.GetHashCode();
        }

        public long Id { get { return _id; } }

        public string Name { get { return _name; } }

        public Artist[] Artists { get { return _artists; } }

        public Album Album { get { return _album; } }

        private class SearchResponseDto
        {
            [JsonProperty("result")]
            public ResultDto Result;

            public class ResultDto
            {
                [JsonProperty("songs")]
                public SongDto[] Songs;

                public class SongDto : IdNameDto
                {
                    [JsonProperty("artists")]
                    public IdNameDto[] Artists;

                    [JsonProperty("album")]
                    public IdNameDto Album;
                }
            }
        }
    }
}
