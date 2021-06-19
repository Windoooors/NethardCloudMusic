using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NetHard_Music
{
    public partial class UserInformationForm : Form
    {
        public UserInformation userInformation;
        public static PlayerForm player = new PlayerForm();

        public UserInformationForm()
        {
            InitializeComponent();
        }

        private void UserInformationForm_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Intialize()
        {
            userNameLabel.Text = userInformation.nickname;
            for (int i = 0; i < userInformation.songListNames.Count; i++)
            {
                playlistsListView.Items.Add(userInformation.songListNames[i]);
            }
            player.cookie = userInformation.savedCookie;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                PlaylistForm playListForm = new PlaylistForm();
                playListForm.playlist.Initialize(userInformation.songListIds[playlistsListView.SelectedItems[0].Index], userInformation.savedCookie);
                playListForm.Initialize();
                playListForm.Show();
            }
            catch
            {
                MessageBox.Show("请检查网络或 Netease Cloud Music Api 地址设置");
            }
        }

        private void playLists_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Show();
            searchForm.cookie = userInformation.savedCookie;
        }

        private void UserInformationForm_Load(object sender, EventArgs e)
        {
            playlistColumn.Width = playlistsListView.Width - 25;
        }
    }
}