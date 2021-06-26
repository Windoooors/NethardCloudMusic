using System.Collections.Generic;
using Newtonsoft.Json;

namespace Setchin.NethardMusic
{
    internal class PlaylistDto : IdNameDto
    {
        [JsonProperty("tracks")]
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
            var songs = new List<Song>();

            if (Tracks != null)
            {
                foreach (var track in Tracks)
                {
                    var artists = new List<Artist>();

                    foreach (var artist in track.Artists)
                    {
                        artists.Add(new Artist(artist.Id, artist.Name));
                    }

                    songs.Add(new Song(track.Id, track.Name, artists.ToArray(), new Album(track.Album.Id, track.Album.Name)));
                }
            }

            return new Playlist(Id, Name, songs);
        }
    }
}
