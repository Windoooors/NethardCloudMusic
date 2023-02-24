using System;
using System.IO;
using System.Windows.Forms;

namespace Setchin.NethardCloudMusic
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            var user = Program.Operator.User;
            userNameLabel.Text = "欢迎您，" + user.Nickname;
            this.Text = user.Nickname + " 的用户主页";

            var playlists = User.GetPlaylists(Program.Operator, user.Id);

            foreach (var playlist in playlists)
            {
                var item = new ListViewItem(playlist.Name) { Tag = playlist };
                playlistsListView.Items.Add(item);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
                PlaylistForm playListForm = new PlaylistForm();
                playListForm.Initialize((Playlist)playlistsListView.SelectedItems[0].Tag);
                playListForm.Show();
            /*}
            catch
            {
                MessageBox.Show("请检查网络或 Netease Cloud Music Api 地址设置");
            }*/
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

        private void UserInformationForm_Resize(object sender, EventArgs e)
        {
            playlistsListView.Width = this.Width - 32;
            playlistsListView.Height = this.Height - 110;
            playlistColumn.Width = playlistsListView.Width - 25;
        }


        private void playlistsListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void userNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void 搜索ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 登出并退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete(Application.StartupPath + @"\cookie.conf");
            Application.Exit();
        }
    }
}