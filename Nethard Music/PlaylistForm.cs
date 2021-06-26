using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Setchin.NethardMusic
{
    public partial class PlaylistForm : Form
    {
        private Playlist _playlist;

        public PlaylistForm()
        {
            InitializeComponent();
        }

        private void PlaylistForm_Load(object sender, EventArgs e)
        {
            songNameColumn.Width = (playlistListView.Width - 25) / 3;
            musicianNameColumn.Width = (playlistListView.Width - 25) / 3;
            albumNameColumn.Width = (playlistListView.Width - 25) / 3;
        }

        public void Initialize(Playlist playlist)
        {
            playlistListView.Items.Clear();

            _playlist = playlist.GetData(Program.Operator);
            titleLabel.Text = _playlist.Name;

            foreach (var song in _playlist)
            {
                var item = new ListViewItem() { Tag = song };
                var artists = new List<string>();

                item.Text = song.Name;

                foreach (var artist in song.Artists)
                {
                    artists.Add(artist.Name);
                }

                item.SubItems.Add(string.Join(",", artists.ToArray()));
                item.SubItems.Add(song.Album.Name);

                playlistListView.Items.Add(item);
            }
        }

        private void playlistList_DoubleClick(object sender, EventArgs e)
        {
            var player = Program.Player;
            var song = _playlist[playlistListView.SelectedItems[0].Index];

            player.Show();
            player.SetPlaylist(_playlist);
            player.Play(song);
        }

        private void playlistList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
