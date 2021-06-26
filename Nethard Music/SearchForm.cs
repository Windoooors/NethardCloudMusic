using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Setchin.NethardMusic
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (searchTextBox.Text != string.Empty)
            {
                switch (searchTab.SelectedIndex)
                {
                    case 0:
                        {
                            playlistListView.Items.Clear();

                            var songs = Song.Search(Program.Operator, searchTextBox.Text);

                            foreach (var song in songs)
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

                            break;
                        }
                    case 1:
                        {
                            break;
                        }
                }
            }
            else
                MessageBox.Show("搜了个寂寞");
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Program.Player.Show();
            Program.Player.Play((Song)playlistListView.SelectedItems[0].Tag);
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            songNameColumn.Width = (playlistListView.Width - 25) / 3;
            musicianNameColumn.Width = (playlistListView.Width - 25) / 3;
            albumNameColumn.Width = (playlistListView.Width - 25) / 3;
        }
    }
}
