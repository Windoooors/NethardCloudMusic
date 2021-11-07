using System;
using System.Windows.Forms;

namespace Setchin.NethardMusic
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
            userNameLabel.Text = "»¶Ó­Äú£¬" + user.Nickname;

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
                MessageBox.Show("Çë¼ì²éÍøÂç»ò Netease Cloud Music Api µØÖ·ÉèÖÃ");
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
            playlistColumn.Width = playlistsListView.Width - 25;
            playlistsListView.Width = this.Width - 30;
            playlistsListView.Height = this.Height - 110;
        }


        private void playlistsListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void userNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void ËÑË÷ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Show();
        }

        private void ÍË³öToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}