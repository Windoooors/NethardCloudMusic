
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
            this.songNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.musicianNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.albumNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(46, 24);
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
            this.playlistListView.Location = new System.Drawing.Point(16, 36);
            this.playlistListView.MultiSelect = false;
            this.playlistListView.Name = "playlistListView";
            this.playlistListView.Size = new System.Drawing.Size(772, 402);
            this.playlistListView.TabIndex = 1;
            this.playlistListView.UseCompatibleStateImageBehavior = false;
            this.playlistListView.View = System.Windows.Forms.View.Details;
            this.playlistListView.SelectedIndexChanged += new System.EventHandler(this.playlistList_SelectedIndexChanged);
            this.playlistListView.DoubleClick += new System.EventHandler(this.playlistList_DoubleClick);
            // 
            // songNameColumn
            // 
            this.songNameColumn.Text = "音乐标题";
            this.songNameColumn.Width = 274;
            // 
            // musicianNameColumn
            // 
            this.musicianNameColumn.Text = "歌手";
            this.musicianNameColumn.Width = 236;
            // 
            // albumNameColumn
            // 
            this.albumNameColumn.Text = "专辑";
            this.albumNameColumn.Width = 258;
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.playlistListView);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PlaylistForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Playlist";
            this.Load += new System.EventHandler(this.PlaylistForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ListView playlistListView;
        private System.Windows.Forms.ColumnHeader songNameColumn;
        private System.Windows.Forms.ColumnHeader musicianNameColumn;
        private System.Windows.Forms.ColumnHeader albumNameColumn;
    }
}