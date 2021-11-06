using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Setchin.NethardMusic
{
    public partial class LyricBox : UserControl
    {
        public LyricBox()
        {
            InitializeComponent();
        }

        private List<Label> _lyricLabels = new List<Label>();
        private int _previousLyricIndex;

        private void LyricBox_Load(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
        }

        private void LyricBox_Resize(object sender, EventArgs e)
        {
            panel1.Width = this.Width;
        }

        public void Initialize(string[] lyrics)
        {
            panel1.Controls.Clear();
            panel1.Top = 0;
            _lyricLabels.Clear();
            foreach (string lyric in lyrics)
            {
                Label lyricLabel = new Label();
                panel1.Controls.Add(lyricLabel);
                lyricLabel.Text = lyric;
                lyricLabel.Height = 20;
                lyricLabel.Width = panel1.Width;
                lyricLabel.Top = _lyricLabels.Count * lyricLabel.Height;
                lyricLabel.Left = 0;
                lyricLabel.TextAlign = ContentAlignment.MiddleLeft;
                _lyricLabels.Add(lyricLabel);
            }
        }

        public void Update(int lyricIndex)
        {
            _lyricLabels[_previousLyricIndex].Font = new Font(_lyricLabels[_previousLyricIndex].Font.Name, 9f);
            _lyricLabels[lyricIndex].Font = new Font(_lyricLabels[lyricIndex].Font.Name, 9f, FontStyle.Bold);
            if (lyricIndex * 20 > this.Height / 2)
                panel1.Top = -lyricIndex * 20 + this.Height / 2;
            else
                panel1.Top = 0;
            _previousLyricIndex = lyricIndex;
        }
    }
}
