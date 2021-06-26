
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
            this.songTitleLabel = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.modeButton = new System.Windows.Forms.Button();
            this.playlistListView = new System.Windows.Forms.ListView();
            this.songNameColumn = new System.Windows.Forms.ColumnHeader();
            this.musicianNameColumn = new System.Windows.Forms.ColumnHeader();
            this.albumNameColumn = new System.Windows.Forms.ColumnHeader();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.likeButton = new System.Windows.Forms.Button();
            this.progressTrackBar = new System.Windows.Forms.TrackBar();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.artistLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.artistLabel);
            this.panel1.Controls.Add(this.songTitleLabel);
            this.panel1.Controls.Add(this.positionLabel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 122);
            this.panel1.TabIndex = 0;
            // 
            // songTitleLabel
            // 
            this.songTitleLabel.AutoSize = true;
            this.songTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.songTitleLabel.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.songTitleLabel.ForeColor = System.Drawing.Color.Lime;
            this.songTitleLabel.Location = new System.Drawing.Point(126, 12);
            this.songTitleLabel.Name = "songTitleLabel";
            this.songTitleLabel.Size = new System.Drawing.Size(92, 48);
            this.songTitleLabel.TabIndex = 1;
            this.songTitleLabel.Text = "NaN";
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.BackColor = System.Drawing.Color.Transparent;
            this.positionLabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.positionLabel.ForeColor = System.Drawing.Color.Lime;
            this.positionLabel.Location = new System.Drawing.Point(131, 86);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(87, 21);
            this.positionLabel.TabIndex = 0;
            this.positionLabel.Text = "NaN/NaN";
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.playButton.Image = ((System.Drawing.Image)(resources.GetObject("playButton.Image")));
            this.playButton.Location = new System.Drawing.Point(12, 140);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(47, 41);
            this.playButton.TabIndex = 1;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pauseButton.Image = ((System.Drawing.Image)(resources.GetObject("pauseButton.Image")));
            this.pauseButton.Location = new System.Drawing.Point(65, 140);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(47, 41);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // prevButton
            // 
            this.prevButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.prevButton.Image = ((System.Drawing.Image)(resources.GetObject("prevButton.Image")));
            this.prevButton.Location = new System.Drawing.Point(118, 140);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(47, 41);
            this.prevButton.TabIndex = 3;
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nextButton.Image = ((System.Drawing.Image)(resources.GetObject("nextButton.Image")));
            this.nextButton.Location = new System.Drawing.Point(171, 140);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(47, 41);
            this.nextButton.TabIndex = 4;
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // modeButton
            // 
            this.modeButton.Location = new System.Drawing.Point(327, 140);
            this.modeButton.Name = "modeButton";
            this.modeButton.Size = new System.Drawing.Size(47, 41);
            this.modeButton.TabIndex = 5;
            this.modeButton.Text = "单曲循环";
            this.modeButton.UseVisualStyleBackColor = true;
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
            this.playlistListView.Location = new System.Drawing.Point(12, 219);
            this.playlistListView.MultiSelect = false;
            this.playlistListView.Name = "playlistListView";
            this.playlistListView.Size = new System.Drawing.Size(362, 309);
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
            this.likeButton.Location = new System.Drawing.Point(274, 140);
            this.likeButton.Name = "likeButton";
            this.likeButton.Size = new System.Drawing.Size(47, 41);
            this.likeButton.TabIndex = 7;
            this.likeButton.Text = "喜欢";
            this.likeButton.UseVisualStyleBackColor = true;
            this.likeButton.Click += new System.EventHandler(this.likeButton_Click);
            // 
            // progressTrackBar
            // 
            this.progressTrackBar.BackColor = System.Drawing.SystemColors.Control;
            this.progressTrackBar.Location = new System.Drawing.Point(12, 187);
            this.progressTrackBar.Name = "progressTrackBar";
            this.progressTrackBar.Size = new System.Drawing.Size(261, 45);
            this.progressTrackBar.TabIndex = 8;
            this.progressTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.progressTrackBar.ValueChanged += new System.EventHandler(this.progressTrackBar_ValueChanged);
            this.progressTrackBar.Scroll += new System.EventHandler(this.progressTrackBar_Scroll);
            this.progressTrackBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.progressTrackBar_MouseDown);
            this.progressTrackBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.progressTrackBar_MouseUp);
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.Location = new System.Drawing.Point(274, 187);
            this.volumeTrackBar.Maximum = 100;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(100, 45);
            this.volumeTrackBar.TabIndex = 9;
            this.volumeTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackBar.Value = 100;
            this.volumeTrackBar.Scroll += new System.EventHandler(this.volumeTrackBar_Scroll);
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.BackColor = System.Drawing.Color.Transparent;
            this.artistLabel.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.artistLabel.ForeColor = System.Drawing.Color.Lime;
            this.artistLabel.Location = new System.Drawing.Point(142, 60);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(43, 21);
            this.artistLabel.TabIndex = 2;
            this.artistLabel.Text = "NaN";
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 540);
            this.Controls.Add(this.playlistListView);
            this.Controls.Add(this.progressTrackBar);
            this.Controls.Add(this.likeButton);
            this.Controls.Add(this.modeButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.volumeTrackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlayerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player";
            this.Load += new System.EventHandler(this.PlayerForm_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayerForm_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label artistLabel;
    }
}