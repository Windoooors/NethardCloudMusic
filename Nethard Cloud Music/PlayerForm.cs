using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Setchin.NethardCloudMusic.Collections;
using WMPLib;
using System.Net;
using System.Web;

namespace Setchin.NethardCloudMusic
{
    public partial class PlayerForm : Form
    {
        private static readonly Random Random = new Random();

        private readonly WindowsMediaPlayer _player = new WindowsMediaPlayer();

        private int _index;
        private int _previousIndex;
        private LyricController _lyricController = new LyricController();

        private Song Song { get { return (Song)playlistListView.Items[_index].Tag; } }

        public enum PlayMode
        {
            SingleLoop,
            ListLoop,
            Random,
            List
        }

        public PlayMode playMode;

        public PlayerForm()
        {
            InitializeComponent();
        }

        public void Play(Song song)
        {
            bool existed = false;

            int i = 0;

            foreach (var item in playlistListView.Items.Cast<ListViewItem>().Select(item => item.Tag).Cast<Song>())
            {
                if (song.Equals(item))
                {
                    _index = i;
                    existed = true;
                    break;
                }

                i++;
            }

            if (!existed)
            {
                AddSong(song);
                _index = playlistListView.Items.Count - 1;
            }

            playlistListView.Items[_index].Selected = true;
            songTitleLabel.Text = playlistListView.Items[_index].Text + " - " + playlistListView.Items[_index].SubItems[1].Text;

            InitializeSong();
        }

        public void InitializeLyric()
        {
            var lyric = Song.GetLyric(Program.Operator, Song.Id);

            lyricBox1.Initialize(lyric.Lyrics.Select(line => line.Content).ToArray());
            _lyricController.Initialize(lyric.Lyrics);
        }

        public void SetPlaylist(Playlist playlist)
        {
            playlistListView.Items.Clear();

            foreach (var song in playlist)
            {
                AddSong(song);
            }
        }

        private void AddSong(Song song)
        {
            var item = new ListViewItem() { Tag = song };
            var artists = new List<string>();

            item.Text = song.Name;

            item.SubItems.Add(string.Join(",", song.Artists.Select(artist => artist.Name).ToArray()));
            item.SubItems.Add(song.Album.Name);

            playlistListView.Items.Add(item);
        }

        private void InitializeSong()
        {
            try
            {
                _player.controls.stop();
                _player.URL = string.Empty;
                var songUrl = new Song.SongUrl();
                if (songUrl.IsChargeable(Program.Operator, Song.Id))
                {
                    Program.Operator.Download(songUrl.Url(Program.Operator, Song.Id), Song.Id);
                    _player.URL = Application.StartupPath + "\\temp\\" + Song.Id.ToString() + ".mp3";
                }
                else
                {
                    _player.URL = "http://music.163.com/song/media/outer/url?id=" + Song.Id.ToString() + ".mp3";
                }
                InitializeLyric();
                _player.controls.play();
                timer1.Enabled = true;
                _player.StatusChange += new _WMPOCXEvents_StatusChangeEventHandler(StatusChange);
                try
                {
                    WebRequest webRequest = WebRequest.Create(Song.GetAlbumCover(Program.Operator, Song.Id));
                    albumCoverPictureBox.BackgroundImage = Image.FromStream(webRequest.GetResponse().GetResponseStream());
                }
                catch
                {
                    albumCoverPictureBox.BackgroundImage = albumCoverPictureBox.InitialImage;
                }
            }
            catch
            {
                MessageBox.Show("无权播放或网络连接失败");
            }
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            tabControl1.Width = this.Width - 34;
            tabControl1.Height = this.Height - 255;
            playlistListView.Width = tabControl1.Width - 8;
            playlistListView.Height = tabControl1.Height - 9;
            lyricBox1.Width = tabControl1.Width - 8;
            lyricBox1.Height = tabControl1.Height - 9;
            songNameColumn.Width = (playlistListView.Width - 25) / 3;
            musicianNameColumn.Width = (playlistListView.Width - 25) / 3;
            albumNameColumn.Width = (playlistListView.Width - 25) / 3;
            _player.settings.volume = 100;
            positionLabel.Font = new Font(Program.PrivateFonts.Families[0], positionLabel.Font.Size);
            durationLabel.Font = new Font(Program.PrivateFonts.Families[0], durationLabel.Font.Size);
            controlPanel.Left = (this.Width - controlPanel.Width - 8) / 2;
        }

        private void PlayerForm_Resize(object sender, EventArgs e)
        {
            tabControl1.Width = this.Width - 34;
            tabControl1.Height = this.Height - 248;
            playlistListView.Width = tabControl1.Width - 8;
            playlistListView.Height = tabControl1.Height - 9;
            lyricBox1.Width = tabControl1.Width - 8;
            lyricBox1.Height = tabControl1.Height - 9;
            songNameColumn.Width = (playlistListView.Width - 25) / 3;
            musicianNameColumn.Width = (playlistListView.Width - 25) / 3;
            albumNameColumn.Width = (playlistListView.Width - 25) / 3;
            controlPanel.Left = (this.Width - controlPanel.Width - 8) / 2;
        }

        private void StatusChange()
        {
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            songTitleLabel.Text = playlistListView.SelectedItems[0].Text + " - " + playlistListView.SelectedItems[0].SubItems[1].Text;
            _index = playlistListView.SelectedItems[0].Index;

            InitializeSong();
        }

        private void modeButton_Click(object sender, EventArgs e)
        {
            switch (playMode)
            {
                case PlayMode.SingleLoop:
                    {
                        playMode = PlayMode.ListLoop;
                        modeButton.Text = "列表循环";
                        break;
                    }
                case PlayMode.ListLoop:
                    {
                        playMode = PlayMode.Random;
                        modeButton.Text = "随机播放";
                        break;
                    }
                case PlayMode.Random:
                    {
                        playMode = PlayMode.List;
                        modeButton.Text = "列表播放";
                        break;
                    }
                case PlayMode.List:
                    {
                        playMode = PlayMode.SingleLoop;
                        modeButton.Text = "单曲循环";
                        break;
                    }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                switch (_player.playState)
                {
                    case WMPPlayState.wmppsStopped:
                        {
                            progressTrackBar.Enabled = false;
                            switch (playMode)
                            {
                                case PlayMode.SingleLoop:
                                    {
                                        _player.controls.play();
                                        break;
                                    }
                                case PlayMode.ListLoop:
                                    {
                                        Next();
                                        break;
                                    }
                                case PlayMode.Random:
                                    {
                                        RandomNext();
                                        break;
                                    }
                                case PlayMode.List:
                                    {
                                        if (_index != playlistListView.Items.Count - 1)
                                        {
                                            Next();
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                    case WMPPlayState.wmppsPaused:
                        {
                            progressTrackBar.Enabled = false;
                            break;
                        }
                    case WMPPlayState.wmppsPlaying:
                        {
                            progressTrackBar.Enabled = true;
                            lyricBox1.Update(_lyricController.GetPosition(_player.controls.currentPosition));
                            break;
                        }
                }
                progressTrackBar.Maximum = (int)_player.currentMedia.duration;
                if (_player.controls.currentPositionString != string.Empty)
                {
                    positionLabel.Text = _player.controls.currentPositionString;
                    durationLabel.Text = "/" + _player.currentMedia.durationString;
                }
                else
                {
                    positionLabel.Text = "00:00";
                    durationLabel.Text = "/" + _player.currentMedia.durationString;
                }
                progressTrackBar.Value = (int)_player.controls.currentPosition;
                positionLabel.Location = new Point((panel1.Width - positionLabel.Width) / 2, positionLabel.Location.Y);
                if (songTitleLabel.Width <= panel1.Width)
                    songTitleLabel.Location = new Point((panel1.Width - songTitleLabel.Width) / 2, songTitleLabel.Location.Y);
                else
                {
                    if (songTitleLabel.Location.X >= 0 - songTitleLabel.Width)
                        songTitleLabel.Location = new Point(songTitleLabel.Location.X - 10, songTitleLabel.Location.Y);
                    else
                        songTitleLabel.Location = new Point(panel1.Width, songTitleLabel.Location.Y);
                }
            }
            catch
            {
                positionLabel.Text = "NaN";
                durationLabel.Text = "/" + "NaN";
                positionLabel.Location = new Point((panel1.Width - positionLabel.Width) / 2, positionLabel.Location.Y);
                songTitleLabel.Location = new Point((panel1.Width - songTitleLabel.Width) / 2, songTitleLabel.Location.Y);
            }
        }

        private void playlistListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void likeButton_Click(object sender, EventArgs e)
        {
            Song.Like(Program.Operator, Song.Id);
        }

        private void progressTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (_player.playState == WMPPlayState.wmppsPaused || _player.playState == WMPPlayState.wmppsStopped)
            {
                _player.controls.currentPosition = progressTrackBar.Value;
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            _player.controls.play();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            _player.controls.pause();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            Previous();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void RandomNext()
        {
            _previousIndex = _index;
            _index = Random.Next(0, playlistListView.Items.Count - 1);

            if (_previousIndex != _index)
            {
                songTitleLabel.Text = playlistListView.Items[_index].Text + " - " + playlistListView.Items[_index].SubItems[1].Text;

                InitializeSong();
            }
            else
            {
                RandomNext();
            }
        }

        private void Previous()
        {
            if (_index != 0)
            {
                songTitleLabel.Text = playlistListView.Items[--_index].Text + " - " + playlistListView.Items[_index].SubItems[1].Text;

            }
            else
            {
                _index = playlistListView.Items.Count - 1;
                songTitleLabel.Text = playlistListView.Items[playlistListView.Items.Count - 1].Text + " - " + playlistListView.Items[playlistListView.Items.Count - 1].SubItems[1].Text;
            }

            InitializeSong();
        }

        private void Next()
        {
            if (_index != playlistListView.Items.Count - 1)
            {
                songTitleLabel.Text = playlistListView.Items[++_index].Text + " - " + playlistListView.Items[_index].SubItems[1].Text;
            }
            else
            {
                _index = 0;
                songTitleLabel.Text = playlistListView.Items[0].Text + " - " + playlistListView.Items[0].SubItems[1].Text;
            }

            InitializeSong();
        }

        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            _player.settings.volume = volumeTrackBar.Value;
        }

        private void progressTrackBar_Scroll(object sender, EventArgs e)
        {

        }

        private void progressTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = true;
            _player.controls.play();
        }

        private void progressTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            _player.controls.pause();
        }

        private void PlayerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Player = new PlayerForm();
        }

        private void lyricBox1_Load(object sender, EventArgs e)
        {

        }
    }
}
