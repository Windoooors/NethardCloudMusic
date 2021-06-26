
namespace Setchin.NethardMusic
{
    partial class SearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.searchTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.playlistListView = new System.Windows.Forms.ListView();
            this.songNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.musicianNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.albumNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchTab
            // 
            this.searchTab.Controls.Add(this.tabPage1);
            this.searchTab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.searchTab.Location = new System.Drawing.Point(12, 68);
            this.searchTab.Name = "searchTab";
            this.searchTab.SelectedIndex = 0;
            this.searchTab.Size = new System.Drawing.Size(772, 431);
            this.searchTab.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.playlistListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(764, 405);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "歌曲";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.playlistListView.Location = new System.Drawing.Point(0, 0);
            this.playlistListView.MultiSelect = false;
            this.playlistListView.Name = "playlistListView";
            this.playlistListView.Size = new System.Drawing.Size(764, 405);
            this.playlistListView.TabIndex = 1;
            this.playlistListView.UseCompatibleStateImageBehavior = false;
            this.playlistListView.View = System.Windows.Forms.View.Details;
            this.playlistListView.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // songNameColumn
            // 
            this.songNameColumn.Text = "歌曲标题";
            this.songNameColumn.Width = 238;
            // 
            // musicianNameColumn
            // 
            this.musicianNameColumn.Text = "歌手";
            this.musicianNameColumn.Width = 261;
            // 
            // albumNameColumn
            // 
            this.albumNameColumn.Text = "专辑";
            this.albumNameColumn.Width = 258;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(772, 21);
            this.searchTextBox.TabIndex = 1;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(709, 39);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 2;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 506);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.searchTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.searchTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl searchTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ListView playlistListView;
        private System.Windows.Forms.ColumnHeader songNameColumn;
        private System.Windows.Forms.ColumnHeader musicianNameColumn;
        private System.Windows.Forms.ColumnHeader albumNameColumn;
    }
}