using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace NetHard_Music
{
    public partial class SearchForm : Form
    {
        SearchSong searchSong = new SearchSong();
        public CookieContainer cookie;

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
                            searchSong = new SearchSong();
                            playlistListView.Items.Clear();
                            try
                            {
                                searchSong.Initialize(searchTextBox.Text, cookie);
                            }
                            catch
                            {
                                MessageBox.Show("请检查网络或 Netease Cloud Music Api 地址设置");
                            }
                            for (int i = 0; i < searchSong.songNames.Count; i++)   //添加10行数据  
                            {
                                ListViewItem _item = new ListViewItem();
                                _item.Text = searchSong.songNames[i];
                                _item.SubItems.Add(searchSong.musicianNames[i]);
                                _item.SubItems.Add(searchSong.albumNames[i]);
                                playlistListView.Items.Add(_item);
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
            UserInformationForm.player.Play(searchSong.songIds[playlistListView.SelectedItems[0].Index]);
            UserInformationForm.player.Show();
            UserInformationForm.player.playlistListView.Items.Clear();
            for (int i = 0; i < searchSong.songNames.Count; i++)   //添加10行数据  
            {
                ListViewItem _item = new ListViewItem();
                _item.Text = searchSong.songNames[i];
                _item.SubItems.Add(searchSong.musicianNames[i]);
                _item.SubItems.Add(searchSong.albumNames[i]);
                UserInformationForm.player.playlistListView.Items.Add(_item);
            }
            UserInformationForm.player.playingPosition = playlistListView.SelectedItems[0].Index;
            UserInformationForm.player.songIds = searchSong.songIds;
            UserInformationForm.player.songTitleLabel.Text = searchSong.songNames[playlistListView.SelectedItems[0].Index];
            UserInformationForm.player.playlistListView.Items[playlistListView.SelectedItems[0].Index].Selected = true;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            songNameColumn.Width = (playlistListView.Width - 25) / 3;
            musicianNameColumn.Width = (playlistListView.Width - 25) / 3;
            albumNameColumn.Width = (playlistListView.Width - 25) / 3;
        }
    }
}
