using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetHard_Music
{
    public partial class PlaylistForm : Form
    {
        public Playlist playlist = new Playlist();

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

        public void Initialize()
        {
            playlistListView.Items.Clear();
            for (int i = 0; i < playlist.songNames.Count; i++)   //添加10行数据  
            {
                
                ListViewItem _item = new ListViewItem();
                _item.Text = playlist.songNames[i];
                _item.SubItems.Add(playlist.musicianNames[i]);
                _item.SubItems.Add(playlist.albumNames[i]);
                playlistListView.Items.Add(_item);
                titleLabel.Text = playlist.listName;
            }
        }

        private void playlistList_DoubleClick(object sender, EventArgs e)
        {
            UserInformationForm.player.Play(playlist.songIds[playlistListView.SelectedItems[0].Index]);
            UserInformationForm.player.Show();
            UserInformationForm.player.playlistListView.Items.Clear();
            for (int i = 0; i < playlist.songNames.Count; i++)   //添加10行数据  
            {
                ListViewItem _item = new ListViewItem();
                _item.Text = playlist.songNames[i];
                _item.SubItems.Add(playlist.musicianNames[i]);
                _item.SubItems.Add(playlist.albumNames[i]);
                UserInformationForm.player.playlistListView.Items.Add(_item);
            }
            UserInformationForm.player.playingPosition = playlistListView.SelectedItems[0].Index;
            UserInformationForm.player.songIds = playlist.songIds;
            UserInformationForm.player.songTitleLabel.Text = playlist.songNames[playlistListView.SelectedItems[0].Index];
            UserInformationForm.player.playlistListView.Items[playlistListView.SelectedItems[0].Index].Selected = true;
        }

        private void playlistList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
