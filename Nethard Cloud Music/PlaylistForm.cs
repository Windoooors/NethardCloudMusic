using System;
using System.Windows.Forms;
using Setchin.NethardCloudMusic.Collections;

namespace Setchin.NethardCloudMusic
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

        private void PlaylistForm_Resize(object sender, EventArgs e)
        {
            playlistListView.Width = this.Width - 32;
            playlistListView.Height = this.Height - 104;
            songNameColumn.Width = (playlistListView.Width - 25) / 3;
            musicianNameColumn.Width = (playlistListView.Width - 25) / 3;
            albumNameColumn.Width = (playlistListView.Width - 25) / 3;
        }

        public void Initialize(Playlist playlist)
        {
            playlistListView.Items.Clear();

            _playlist = new Playlist(playlist.Id, playlist.Name, playlist);
            _playlist.AddRange(_playlist.GetData(Program.Operator));
            titleLabel.Text = _playlist.Name;

            foreach (var song in _playlist)
            {
                var item = new ListViewItem() { Tag = song };

                item.Text = song.Name;

                item.SubItems.Add(string.Join(",", song.Artists.Select(artist => artist.Name).ToArray()));
                item.SubItems.Add(song.Album.Name);

                playlistListView.Items.Add(item);
            }

            LoadedMonitorToolStripMenuItem.Text = "已载入 " + playlistListView.Items.Count + " 首歌曲";
        }

        public void LoadMore()
        {
            var _playlistAddition = _playlist.GetData(Program.Operator);
            if (_playlistAddition != null)
            {
                _playlist.AddRange(_playlistAddition);

                int i = 0;

                foreach (var song in _playlist)
                {
                    if (i >= (_playlist.loadedIdsCount - 1) * 300)
                    {
                        var item = new ListViewItem() { Tag = song };

                        item.Text = song.Name;

                        item.SubItems.Add(string.Join(",", song.Artists.Select(artist => artist.Name).ToArray()));
                        item.SubItems.Add(song.Album.Name);

                        playlistListView.Items.Add(item);
                    }
                    i++;
                }

                LoadedMonitorToolStripMenuItem.Text = "已载入 " + playlistListView.Items.Count + " 首歌曲";
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

        private void playlistList_Click(object sender, EventArgs e)
        {
            if (playlistListView.SelectedItems[0].Index == playlistListView.Items.Count - 1)
            {
                LoadMore();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 载入所有歌曲ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var loadedIdsCount = _playlist.loadedIdsCount;
            for (int i = 0; i < _playlist.loadableIdsCount - loadedIdsCount; i++)
                LoadMore();
        }

        private void 载入下一部分歌曲ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoadMore();
        }

        private void playlistListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
