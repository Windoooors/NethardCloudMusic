using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Setchin.NethardCloudMusic.Collections;
namespace Setchin.NethardCloudMusic
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

        private PlaylistResponseDto firstDto;

        public int loadedIdsCount;

        public int loadableIdsCount;

        private static Playlist GetPlaylist(ApiOperator @operator, long id, PlaylistResponseDto firstDto , int loadIdsIndex)
        {
            string postContent = string.Empty;

            var tracks = new List<SonglistDto.TrackDto>();

            int i = 0;

            foreach (var ids in firstDto.Playlist.TrackIds.Select(it => it.Id.ToString()).Slice(300))
            {
                string idsString = string.Join(",", ids.ToArray());

                if (i == loadIdsIndex)
                {
                    string result = @operator.Get("song/detail", new { Ids = idsString });
                    tracks.AddRange(JsonConvert.DeserializeObject<SonglistDto>(result).Tracks);
                }
                i++;
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
            if (firstDto == null)
            {
                string content = @operator.Get("playlist/detail", new { Id = Id });
                firstDto = JsonConvert.DeserializeObject<PlaylistResponseDto>(content);
                var count = firstDto.Playlist.TrackIds.Count();
                loadableIdsCount = (count / 300) + (count % 300 == 0 ? 0 : 1);
            }
            if (loadedIdsCount < loadableIdsCount)
            {
                loadedIdsCount++;
                return GetPlaylist(@operator, Id, firstDto, loadedIdsCount - 1);
            }
            else
                return null;
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
