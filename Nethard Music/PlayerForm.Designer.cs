
namespace Setchin.NethardMusic
{
    partial class PlayerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                _player.close();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.durationLabel = new System.Windows.Forms.Label();
            this.songTitleLabel = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            this.modeButton = new System.Windows.Forms.Button();
            this.playlistListView = new System.Windows.Forms.ListView();
            this.songNameColumn = new System.Windows.Forms.ColumnHeader();
            this.musicianNameColumn = new System.Windows.Forms.ColumnHeader();
            this.albumNameColumn = new System.Windows.Forms.ColumnHeader();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.likeButton = new System.Windows.Forms.Button();
            this.progressTrackBar = new System.Windows.Forms.TrackBar();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.albumCoverPictureBox = new System.Windows.Forms.PictureBox();
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lyricBox1 = new Setchin.NethardMusic.LyricBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumCoverPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.durationLabel);
            this.panel1.Controls.Add(this.songTitleLabel);
            this.panel1.Controls.Add(this.positionLabel);
            this.panel1.Location = new System.Drawing.Point(22, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 86);
            this.panel1.TabIndex = 0;
            // 
            // durationLabel
            // 
            this.durationLabel.BackColor = System.Drawing.Color.Transparent;
            this.durationLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.durationLabel.ForeColor = System.Drawing.Color.Lime;
            this.durationLabel.Location = new System.Drawing.Point(0, 47);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(342, 19);
            this.durationLabel.TabIndex = 3;
            this.durationLabel.Text = "NaN";
            this.durationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // songTitleLabel
            // 
            this.songTitleLabel.AutoSize = true;
            this.songTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.songTitleLabel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.songTitleLabel.ForeColor = System.Drawing.Color.Lime;
            this.songTitleLabel.Location = new System.Drawing.Point(138, 68);
            this.songTitleLabel.Name = "songTitleLabel";
            this.songTitleLabel.Size = new System.Drawing.Size(28, 14);
            this.songTitleLabel.TabIndex = 1;
            this.songTitleLabel.Text = "NaN";
            this.songTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.BackColor = System.Drawing.Color.Transparent;
            this.positionLabel.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.positionLabel.ForeColor = System.Drawing.Color.Lime;
            this.positionLabel.Location = new System.Drawing.Point(123, 12);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(69, 35);
            this.positionLabel.TabIndex = 0;
            this.positionLabel.Text = "NaN";
            // 
            // modeButton
            // 
            this.modeButton.BackColor = System.Drawing.SystemColors.Control;
            this.modeButton.Location = new System.Drawing.Point(298, 122);
            this.modeButton.Name = "modeButton";
            this.modeButton.Size = new System.Drawing.Size(66, 31);
            this.modeButton.TabIndex = 5;
            this.modeButton.Text = "单曲循环";
            this.modeButton.UseVisualStyleBackColor = false;
            this.modeButton.Click += new System.EventHandler(this.modeButton_Click);
            // 
            // playlistListView
            // 
            this.playlistListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.songNameColumn,
            this.musicianNameColumn,
            this.albumNameColumn});
            this.playlistListView.FullRowSelect = true;
            this.playlistListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.playlistListView.HideSelection = false;
            this.playlistListView.Location = new System.Drawing.Point(0, 3);
            this.playlistListView.MultiSelect = false;
            this.playlistListView.Name = "playlistListView";
            this.playlistListView.Size = new System.Drawing.Size(373, 322);
            this.playlistListView.TabIndex = 6;
            this.playlistListView.UseCompatibleStateImageBehavior = false;
            this.playlistListView.View = System.Windows.Forms.View.Details;
            this.playlistListView.SelectedIndexChanged += new System.EventHandler(this.playlistListView_SelectedIndexChanged);
            this.playlistListView.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // songNameColumn
            // 
            this.songNameColumn.Text = "音乐标题";
            this.songNameColumn.Width = 109;
            // 
            // musicianNameColumn
            // 
            this.musicianNameColumn.Text = "歌手";
            this.musicianNameColumn.Width = 135;
            // 
            // albumNameColumn
            // 
            this.albumNameColumn.Text = "专辑";
            this.albumNameColumn.Width = 114;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // likeButton
            // 
            this.likeButton.BackColor = System.Drawing.SystemColors.Control;
            this.likeButton.Location = new System.Drawing.Point(245, 122);
            this.likeButton.Name = "likeButton";
            this.likeButton.Size = new System.Drawing.Size(47, 31);
            this.likeButton.TabIndex = 7;
            this.likeButton.Text = "喜欢";
            this.likeButton.UseVisualStyleBackColor = false;
            this.likeButton.Click += new System.EventHandler(this.likeButton_Click);
            // 
            // progressTrackBar
            // 
            this.progressTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.progressTrackBar.Location = new System.Drawing.Point(-3, 0);
            this.progressTrackBar.Name = "progressTrackBar";
            this.progressTrackBar.Size = new System.Drawing.Size(254, 42);
            this.progressTrackBar.TabIndex = 8;
            this.progressTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.progressTrackBar.ValueChanged += new System.EventHandler(this.progressTrackBar_ValueChanged);
            this.progressTrackBar.Scroll += new System.EventHandler(this.progressTrackBar_Scroll);
            this.progressTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.progressTrackBar_MouseDown);
            this.progressTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.progressTrackBar_MouseUp);
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.volumeTrackBar.Location = new System.Drawing.Point(257, 0);
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(82, 42);
            this.volumeTrackBar.TabIndex = 9;
            this.volumeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackBar.Value = 100;
            this.volumeTrackBar.Scroll += new System.EventHandler(this.volumeTrackBar_Scroll);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 219);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(384, 366);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.playlistListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(376, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "播放列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lyricBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(376, 340);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "歌词";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.panel2);
            this.controlPanel.Controls.Add(this.albumCoverPictureBox);
            this.controlPanel.Controls.Add(this.panel1);
            this.controlPanel.Controls.Add(this.playButton);
            this.controlPanel.Controls.Add(this.likeButton);
            this.controlPanel.Controls.Add(this.pauseButton);
            this.controlPanel.Controls.Add(this.modeButton);
            this.controlPanel.Controls.Add(this.prevButton);
            this.controlPanel.Controls.Add(this.nextButton);
            this.controlPanel.Controls.Add(this.pictureBox2);
            this.controlPanel.Location = new System.Drawing.Point(14, 12);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(386, 202);
            this.controlPanel.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.panel2.Controls.Add(this.progressTrackBar);
            this.panel2.Controls.Add(this.volumeTrackBar);
            this.panel2.Location = new System.Drawing.Point(25, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 28);
            this.panel2.TabIndex = 15;
            // 
            // albumCoverPictureBox
            // 
            this.albumCoverPictureBox.BackgroundImage = global::Setchin.NethardMusic.Properties.Resources.empty;
            this.albumCoverPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.albumCoverPictureBox.ErrorImage = global::Setchin.NethardMusic.Properties.Resources.empty;
            this.albumCoverPictureBox.Image = global::Setchin.NethardMusic.Properties.Resources.albumcover1;
            this.albumCoverPictureBox.InitialImage = global::Setchin.NethardMusic.Properties.Resources.empty;
            this.albumCoverPictureBox.Location = new System.Drawing.Point(11, 89);
            this.albumCoverPictureBox.Name = "albumCoverPictureBox";
            this.albumCoverPictureBox.Size = new System.Drawing.Size(64, 64);
            this.albumCoverPictureBox.TabIndex = 13;
            this.albumCoverPictureBox.TabStop = false;
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.SystemColors.Control;
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.playButton.Image = ((System.Drawing.Image)(resources.GetObject("playButton.Image")));
            this.playButton.Location = new System.Drawing.Point(81, 122);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(35, 31);
            this.playButton.TabIndex = 1;
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.SystemColors.Control;
            this.pauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pauseButton.Image = ((System.Drawing.Image)(resources.GetObject("pauseButton.Image")));
            this.pauseButton.Location = new System.Drawing.Point(122, 122);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(35, 31);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.UseVisualStyleBackColor = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // prevButton
            // 
            this.prevButton.BackColor = System.Drawing.SystemColors.Control;
            this.prevButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.prevButton.Image = ((System.Drawing.Image)(resources.GetObject("prevButton.Image")));
            this.prevButton.Location = new System.Drawing.Point(163, 122);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(35, 31);
            this.prevButton.TabIndex = 3;
            this.prevButton.UseVisualStyleBackColor = false;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.SystemColors.Control;
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nextButton.Image = ((System.Drawing.Image)(resources.GetObject("nextButton.Image")));
            this.nextButton.Location = new System.Drawing.Point(204, 122);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(35, 31);
            this.nextButton.TabIndex = 4;
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Setchin.NethardMusic.Properties.Resources.background1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(1, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(384, 201);
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // lyricBox1
            // 
            this.lyricBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lyricBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lyricBox1.Location = new System.Drawing.Point(0, 3);
            this.lyricBox1.Name = "lyricBox1";
            this.lyricBox1.Size = new System.Drawing.Size(373, 322);
            this.lyricBox1.TabIndex = 11;
            this.lyricBox1.Load += new System.EventHandler(this.lyricBox1_Load);
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 601);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.controlPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(423, 628);
            this.Name = "PlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "播放器";
            this.Load += new System.EventHandler(this.PlayerForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayerForm_FormClosed);
            this.Resize += new System.EventHandler(this.PlayerForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumCoverPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label songTitleLabel;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button modeButton;
        private System.Windows.Forms.ListView playlistListView;
        private System.Windows.Forms.ColumnHeader songNameColumn;
        private System.Windows.Forms.ColumnHeader musicianNameColumn;
        private System.Windows.Forms.ColumnHeader albumNameColumn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button likeButton;
        private System.Windows.Forms.TrackBar progressTrackBar;
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private LyricBox lyricBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.PictureBox albumCoverPictureBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Panel panel2;
    }
}