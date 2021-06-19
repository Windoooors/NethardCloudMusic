using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using WMPLib;
using System.Windows.Forms;
using System.Net;

namespace NetHard_Music
{
    public partial class PlayerForm : Form
    {
        public CookieContainer cookie = null;
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public int playingPosition;
        public List<long> songIds = new List<long>();
        public enum PlayMode
        {
            SingleLoop,
            ListLoop,
            List
        }

        public PlayMode playMode;

        public PlayerForm()
        {
            InitializeComponent();
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            songNameColumn.Width = (playlistListView.Width - 25) / 3;
            musicianNameColumn.Width = (playlistListView.Width - 25) / 3;
            albumNameColumn.Width = (playlistListView.Width - 25) / 3;
            player.settings.volume = 100;
        }

        private void StatusChange()
        {

        }

        public void Play(long id)
        {
            try
            {
                player.URL = "http://music.163.com/song/media/outer/url?id=" + id.ToString() + ".mp3";
                player.controls.play();
                timer1.Enabled = true;
                player.StatusChange += new WMPLib._WMPOCXEvents_StatusChangeEventHandler(StatusChange);
            }
            catch
            {
                MessageBox.Show("请检查网络设置");
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Play(songIds[playlistListView.SelectedItems[0].Index]);
            player.controls.play();
            songTitleLabel.Text = playlistListView.SelectedItems[0].Text;
            playingPosition = playlistListView.SelectedItems[0].Index;
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
                switch (player.playState)
                {
                    case WMPPlayState.wmppsStopped:
                        {
                            progressTrackBar.Enabled = false;
                            switch (playMode)
                            {
                                case PlayMode.SingleLoop:
                                    {
                                        player.controls.play();
                                        break;
                                    }
                                case PlayMode.ListLoop:
                                    {
                                        if (playingPosition != songIds.Count - 1)
                                        {
                                            Play(songIds[playingPosition + 1]);
                                            songTitleLabel.Text = playlistListView.Items[playingPosition + 1].Text;
                                            playingPosition++;
                                        }
                                        else
                                        {
                                            Play(songIds[0]);
                                            songTitleLabel.Text = playlistListView.Items[0].Text;
                                            playingPosition = 0;
                                        }
                                        break;
                                    }
                                case PlayMode.List:
                                    {
                                        if (playingPosition != songIds.Count - 1)
                                        {
                                            Play(songIds[playingPosition + 1]);
                                            songTitleLabel.Text = playlistListView.Items[playingPosition + 1].Text;
                                            playingPosition++;
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
                            break;
                        }
                }
                progressTrackBar.Maximum = (int)player.currentMedia.duration;
                if (player.controls.currentPositionString != string.Empty)
                    positionLabel.Text = player.controls.currentPositionString + "/" + player.currentMedia.durationString;
                else
                    positionLabel.Text = "00:00" + "/" + player.currentMedia.durationString;
                progressTrackBar.Value = (int)player.controls.currentPosition;
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
                positionLabel.Text = "NaN" + "/" + "NaN";
                positionLabel.Location = new Point((panel1.Width - positionLabel.Width) / 2, positionLabel.Location.Y);
                songTitleLabel.Location = new Point((panel1.Width - songTitleLabel.Width) / 2, songTitleLabel.Location.Y);
            }
        }

        private void playlistListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void likeButton_Click(object sender, EventArgs e)
        {
            Request.Get(LoginForm.address + "/like?id=" + songIds[playlistListView.SelectedItems[0].Index].ToString(), cookie);
        }

        private void progressTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (player.playState == WMPPlayState.wmppsPaused || player.playState == WMPPlayState.wmppsStopped)
                player.controls.currentPosition = progressTrackBar.Value;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            player.controls.play();
        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            player.controls.pause();
        }

        private void lastButton_Click(object sender, EventArgs e)
        {
            if (playingPosition != 0)
            {
                Play(songIds[playingPosition - 1]);
                songTitleLabel.Text = playlistListView.Items[playingPosition - 1].Text;
                playingPosition--;
            }
            else
            {
                Play(songIds[songIds.Count - 1]);
                songTitleLabel.Text = playlistListView.Items[songIds.Count - 1].Text;
                playingPosition = songIds.Count - 1;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (playingPosition != songIds.Count - 1)
            {
                Play(songIds[playingPosition + 1]);
                songTitleLabel.Text = playlistListView.Items[playingPosition + 1].Text;
                playingPosition++;
            }
            else
            {
                Play(songIds[0]);
                songTitleLabel.Text = playlistListView.Items[0].Text;
                playingPosition = 0;
            }
        }

        private void volumeTrackBar_Scroll(object sender, EventArgs e)
        {
            player.settings.volume = volumeTrackBar.Value;
        }

        private void progressTrackBar_Scroll(object sender, EventArgs e)
        {

        }

        private void progressTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled = true;
            player.controls.play();
        }

        private void progressTrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
            player.controls.pause();
        }
    }
}
