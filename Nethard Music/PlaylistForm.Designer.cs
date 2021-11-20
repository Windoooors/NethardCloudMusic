
namespace Setchin.NethardMusic
{
    partial class PlaylistForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaylistForm));
            this.titleLabel = new System.Windows.Forms.Label();
            this.playlistListView = new System.Windows.Forms.ListView();
            this.songNameColumn = new System.Windows.Forms.ColumnHeader();
            this.musicianNameColumn = new System.Windows.Forms.ColumnHeader();
            this.albumNameColumn = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.载入下一部分歌曲ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.载入所有歌曲ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadedMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel.Location = new System.Drawing.Point(10, 34);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(23, 12);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "NaN";
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
            this.playlistListView.Location = new System.Drawing.Point(12, 58);
            this.playlistListView.MultiSelect = false;
            this.playlistListView.Name = "playlistListView";
            this.playlistListView.Size = new System.Drawing.Size(270, 270);
            this.playlistListView.TabIndex = 1;
            this.playlistListView.UseCompatibleStateImageBehavior = false;
            this.playlistListView.View = System.Windows.Forms.View.Details;
            this.playlistListView.SelectedIndexChanged += new System.EventHandler(this.playlistListView_SelectedIndexChanged);
            this.playlistListView.DoubleClick += new System.EventHandler(this.playlistList_DoubleClick);
            this.playlistListView.Click += new System.EventHandler(this.playlistList_Click);
            // 
            // songNameColumn
            // 
            this.songNameColumn.Text = "音乐标题";
            this.songNameColumn.Width = 108;
            // 
            // musicianNameColumn
            // 
            this.musicianNameColumn.Text = "歌手";
            this.musicianNameColumn.Width = 93;
            // 
            // albumNameColumn
            // 
            this.albumNameColumn.Text = "专辑";
            this.albumNameColumn.Width = 139;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(294, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.载入下一部分歌曲ToolStripMenuItem,
            this.载入所有歌曲ToolStripMenuItem,
            this.LoadedMonitorToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // 载入下一部分歌曲ToolStripMenuItem
            // 
            this.载入下一部分歌曲ToolStripMenuItem.Name = "载入下一部分歌曲ToolStripMenuItem";
            this.载入下一部分歌曲ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.载入下一部分歌曲ToolStripMenuItem.Text = "载入下一部分歌曲";
            this.载入下一部分歌曲ToolStripMenuItem.Click += new System.EventHandler(this.载入下一部分歌曲ToolStripMenuItem_Click_1);
            // 
            // 载入所有歌曲ToolStripMenuItem
            // 
            this.载入所有歌曲ToolStripMenuItem.Name = "载入所有歌曲ToolStripMenuItem";
            this.载入所有歌曲ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.载入所有歌曲ToolStripMenuItem.Text = "载入所有歌曲";
            this.载入所有歌曲ToolStripMenuItem.Click += new System.EventHandler(this.载入所有歌曲ToolStripMenuItem_Click);
            // 
            // LoadedMonitorToolStripMenuItem
            // 
            this.LoadedMonitorToolStripMenuItem.Enabled = false;
            this.LoadedMonitorToolStripMenuItem.Name = "LoadedMonitorToolStripMenuItem";
            this.LoadedMonitorToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.LoadedMonitorToolStripMenuItem.Text = "已载入";
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 340);
            this.Controls.Add(this.playlistListView);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(302, 367);
            this.Name = "PlaylistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "播放列表";
            this.Load += new System.EventHandler(this.PlaylistForm_Load);
            this.Resize += new System.EventHandler(this.PlaylistForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ListView playlistListView;
        private System.Windows.Forms.ColumnHeader songNameColumn;
        private System.Windows.Forms.ColumnHeader musicianNameColumn;
        private System.Windows.Forms.ColumnHeader albumNameColumn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 载入下一部分歌曲ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadedMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 载入所有歌曲ToolStripMenuItem;
    }
}