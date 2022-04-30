using System;
using System.Drawing;
using Kfstorm.LrcParser;
using Newtonsoft.Json;
using Setchin.NethardMusic.Collections;

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

            return dtos.Select(dto => new Song(dto.Id,
                dto.Name,
                dto.Artists.Select(artist => new Artist(artist.Id, artist.Name)).ToArray(),
                new Album(dto.Album.Id, dto.Album.Name)))
                .ToArray();
                
        }

        public static void Like(ApiOperator @operator, long id)
        {
            @operator.Get("like", new { Id = id });
        }

        public static Uri GetAlbumCover(ApiOperator @operator, long id) 
        {
            string content = @operator.Get("song/detail", new { Ids = id });
            var dto = JsonConvert.DeserializeObject<AlbumCoverResponseDto>(content);

            return new Uri(dto.Songs[0].Album.AlbumCover.Replace("https", "http"));
        }

        public static ILrc GetLyric(ApiOperator @operator, long id)
        {
            string content = @operator.Get("lyric", new { Id = id });
            var dto = JsonConvert.DeserializeObject<LyricResponseDto>(content);

            if (dto.Lrc != null && dto.Lrc.Lyric != string.Empty)
                try { return Lrc.FromText(dto.Lrc.Lyric); }
                catch {
                    return (Lrc.FromText("[00:00.00]" + dto.Lrc.Lyric.Replace('\n', ' ')));
                }
            else 
            {
                return Lrc.FromText("[00:00.00]该歌曲没有歌词");
            }
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

        private class AlbumCoverResponseDto
        {
            [JsonProperty("songs")]
            public SongDto[] Songs;

            public class SongDto : IdNameDto
            {
                [JsonProperty("al")]
                public AlbumDto Album;

                public class AlbumDto
                {
                    [JsonProperty("picUrl")]
                    public string AlbumCover;
                }
            }
        }

        private class LyricResponseDto
        {
            [JsonProperty("lrc")]
            public LrcDto Lrc;

            public class LrcDto
            {
                [JsonProperty("lyric")]
                public string Lyric;
            }
        }
    }
}
