using System;
using System.Windows.Forms;

namespace Setchin.NethardMusic
{
    public partial class UserInformationForm : Form
    {
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
            var user = Program.Operator.User;
            userNameLabel.Text = user.Nickname;

            var playlists = User.GetPlaylists(Program.Operator, user.Id);

            foreach (var playlist in playlists)
            {
                var item = new ListViewItem(playlist.Name) { Tag = playlist };
                playlistsListView.Items.Add(item);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                PlaylistForm playListForm = new PlaylistForm();
                playListForm.Initialize((Playlist)playlistsListView.SelectedItems[0].Tag);
                playListForm.Show();
            }
            catch
            {
                MessageBox.Show("请检查网络或 Netease Cloud Music Api 地址设置");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Show();
        }

        private void UserInformationForm_Load(object sender, EventArgs e)
        {
            playlistColumn.Width = playlistsListView.Width - 25;
        }

        private void playlistsListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}