namespace NetHard_Music
{
    partial class UserInformationForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInformationForm));
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.playlistsListView = new System.Windows.Forms.ListView();
            this.playlistColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(12, 8);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(236, 37);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome back!";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.Location = new System.Drawing.Point(9, 42);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(121, 55);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "NaN";
            // 
            // playlistsListView
            // 
            this.playlistsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.playlistColumn});
            this.playlistsListView.FullRowSelect = true;
            this.playlistsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.playlistsListView.HideSelection = false;
            this.playlistsListView.Location = new System.Drawing.Point(19, 100);
            this.playlistsListView.MultiSelect = false;
            this.playlistsListView.Name = "playlistsListView";
            this.playlistsListView.Size = new System.Drawing.Size(622, 295);
            this.playlistsListView.TabIndex = 2;
            this.playlistsListView.UseCompatibleStateImageBehavior = false;
            this.playlistsListView.View = System.Windows.Forms.View.Details;
            this.playlistsListView.SelectedIndexChanged += new System.EventHandler(this.playLists_SelectedIndexChanged);
            this.playlistsListView.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // playlistColumn
            // 
            this.playlistColumn.Text = "歌单名称";
            this.playlistColumn.Width = 617;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(531, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(110, 33);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // UserInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 407);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.playlistsListView);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.welcomeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UserInformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "You";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserInformationForm_FormClosed);
            this.Load += new System.EventHandler(this.UserInformationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.ListView playlistsListView;
        private System.Windows.Forms.ColumnHeader playlistColumn;
        private System.Windows.Forms.Button searchButton;
    }
}