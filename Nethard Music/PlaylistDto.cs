using System.Collections.Generic;
using Newtonsoft.Json;
using Setchin.NethardMusic.Collections;

namespace Setchin.NethardMusic
{
    internal class PlaylistDto : IdNameDto
    {
        [JsonProperty("tracks")]
        public IEnumerable<TrackDto> Tracks;

        [JsonProperty("trackIds")]
        public IEnumerable<TrackIdDto> TrackIds;

        public class TrackDto : IdNameDto
        {
            [JsonProperty("al")]
            public IdNameDto Album;

            [JsonProperty("ar")]
            public IEnumerable<IdNameDto> Artists;
        }

        public class TrackIdDto {
            [JsonProperty("id")]
            public string id;
        }

        public Playlist ToPlaylist()
        {
            List<Song> songs = null;

            if (Tracks != null)
            {
                songs = Tracks.Select(track => new Song(
                    track.Id,
                    track.Name,
                    track.Artists.Select(artist => new Artist(artist.Id, artist.Name)).ToArray(),
                    new Album(track.Album.Id, track.Album.Name)))
                    .ToList();
            }

            return new Playlist(Id, Name, songs);
        }
    }

    internal class SonglistDto : IdNameDto
    {
        [JsonProperty("songs")]
        public IEnumerable<TrackDto> Tracks;

        public class TrackDto : IdNameDto
        {
            [JsonProperty("al")]
            public IdNameDto Album;

            [JsonProperty("ar")]
            public IEnumerable<IdNameDto> Artists;
        }

        public Playlist ToPlaylist()
        {
            List<Song> songs = null;

            if (Tracks != null)
            {
                songs = Tracks.Select(track => new Song(
                    track.Id,
                    track.Name,
                    track.Artists.Select(artist => new Artist(artist.Id, artist.Name)).ToArray(),
                    new Album(track.Album.Id, track.Album.Name)))
                    .ToList();
            }

            return new Playlist(Id, Name, songs);
        }
    }
}
