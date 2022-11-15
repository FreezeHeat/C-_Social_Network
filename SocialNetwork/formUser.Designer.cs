namespace SocialNetwork
{
    partial class formUser
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
            this.panSocial = new System.Windows.Forms.Panel();
            this.btnDeletePost = new System.Windows.Forms.Button();
            this.btnRestoreYourPosts = new System.Windows.Forms.Button();
            this.txtTargetUsername = new System.Windows.Forms.TextBox();
            this.btnPlaylist = new System.Windows.Forms.Button();
            this.btnSendTicket = new System.Windows.Forms.Button();
            this.btnGetPost = new System.Windows.Forms.Button();
            this.btnNextPost = new System.Windows.Forms.Button();
            this.btnPreviousPost = new System.Windows.Forms.Button();
            this.btnNewPost = new System.Windows.Forms.Button();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.labPost = new System.Windows.Forms.Label();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.labStatus = new System.Windows.Forms.Label();
            this.btnGetUserInfo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panSocial.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSend
            // 
            this.txtSend.TextChanged += new System.EventHandler(this.txtSend_TextChanged_1);
            // 
            // txtRecipient
            // 
            this.txtRecipient.Click += new System.EventHandler(this.txtRecipient_Click);
            // 
            // panSocial
            // 
            this.panSocial.Controls.Add(this.btnGetUserInfo);
            this.panSocial.Controls.Add(this.btnDeletePost);
            this.panSocial.Controls.Add(this.btnRestoreYourPosts);
            this.panSocial.Controls.Add(this.txtTargetUsername);
            this.panSocial.Controls.Add(this.btnPlaylist);
            this.panSocial.Controls.Add(this.btnSendTicket);
            this.panSocial.Controls.Add(this.btnGetPost);
            this.panSocial.Controls.Add(this.btnNextPost);
            this.panSocial.Controls.Add(this.btnPreviousPost);
            this.panSocial.Controls.Add(this.btnNewPost);
            this.panSocial.Controls.Add(this.txtPost);
            this.panSocial.Controls.Add(this.labPost);
            this.panSocial.Controls.Add(this.btnUpdateStatus);
            this.panSocial.Controls.Add(this.txtStatus);
            this.panSocial.Controls.Add(this.labStatus);
            this.panSocial.Location = new System.Drawing.Point(-1, 0);
            this.panSocial.Margin = new System.Windows.Forms.Padding(2);
            this.panSocial.Name = "panSocial";
            this.panSocial.Size = new System.Drawing.Size(282, 351);
            this.panSocial.TabIndex = 1;
            this.panSocial.Paint += new System.Windows.Forms.PaintEventHandler(this.panSocial_Paint);
            // 
            // btnDeletePost
            // 
            this.btnDeletePost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePost.Location = new System.Drawing.Point(133, 213);
            this.btnDeletePost.Name = "btnDeletePost";
            this.btnDeletePost.Size = new System.Drawing.Size(61, 26);
            this.btnDeletePost.TabIndex = 13;
            this.btnDeletePost.Text = "Delete";
            this.btnDeletePost.UseVisualStyleBackColor = true;
            this.btnDeletePost.Click += new System.EventHandler(this.btnDeletePost_Click);
            // 
            // btnRestoreYourPosts
            // 
            this.btnRestoreYourPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestoreYourPosts.Location = new System.Drawing.Point(4, 213);
            this.btnRestoreYourPosts.Name = "btnRestoreYourPosts";
            this.btnRestoreYourPosts.Size = new System.Drawing.Size(75, 26);
            this.btnRestoreYourPosts.TabIndex = 12;
            this.btnRestoreYourPosts.Text = "My Posts";
            this.btnRestoreYourPosts.UseVisualStyleBackColor = true;
            this.btnRestoreYourPosts.Click += new System.EventHandler(this.btnRestoreYourPosts_Click);
            // 
            // txtTargetUsername
            // 
            this.txtTargetUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtTargetUsername.Location = new System.Drawing.Point(9, 282);
            this.txtTargetUsername.Name = "txtTargetUsername";
            this.txtTargetUsername.Size = new System.Drawing.Size(268, 26);
            this.txtTargetUsername.TabIndex = 11;
            this.txtTargetUsername.Text = "Enter target username";
            this.txtTargetUsername.Click += new System.EventHandler(this.txtTargetUsername_Click);
            // 
            // btnPlaylist
            // 
            this.btnPlaylist.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaylist.Location = new System.Drawing.Point(147, 315);
            this.btnPlaylist.Name = "btnPlaylist";
            this.btnPlaylist.Size = new System.Drawing.Size(133, 33);
            this.btnPlaylist.TabIndex = 10;
            this.btnPlaylist.Text = "Music Playlist";
            this.btnPlaylist.UseVisualStyleBackColor = true;
            this.btnPlaylist.Click += new System.EventHandler(this.btnPlaylist_Click);
            // 
            // btnSendTicket
            // 
            this.btnSendTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendTicket.Location = new System.Drawing.Point(2, 315);
            this.btnSendTicket.Name = "btnSendTicket";
            this.btnSendTicket.Size = new System.Drawing.Size(133, 33);
            this.btnSendTicket.TabIndex = 9;
            this.btnSendTicket.Text = "Send Ticket";
            this.btnSendTicket.UseVisualStyleBackColor = true;
            this.btnSendTicket.Click += new System.EventHandler(this.btnSendTicket_Click);
            // 
            // btnGetPost
            // 
            this.btnGetPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPost.Location = new System.Drawing.Point(97, 250);
            this.btnGetPost.Name = "btnGetPost";
            this.btnGetPost.Size = new System.Drawing.Size(80, 26);
            this.btnGetPost.TabIndex = 8;
            this.btnGetPost.Text = "Get Posts";
            this.btnGetPost.UseVisualStyleBackColor = true;
            this.btnGetPost.Click += new System.EventHandler(this.btnGetPost_Click);
            // 
            // btnNextPost
            // 
            this.btnNextPost.Location = new System.Drawing.Point(238, 213);
            this.btnNextPost.Name = "btnNextPost";
            this.btnNextPost.Size = new System.Drawing.Size(39, 26);
            this.btnNextPost.TabIndex = 7;
            this.btnNextPost.Text = ">";
            this.btnNextPost.UseVisualStyleBackColor = true;
            this.btnNextPost.Click += new System.EventHandler(this.btnNextPost_Click);
            // 
            // btnPreviousPost
            // 
            this.btnPreviousPost.Location = new System.Drawing.Point(196, 213);
            this.btnPreviousPost.Name = "btnPreviousPost";
            this.btnPreviousPost.Size = new System.Drawing.Size(39, 26);
            this.btnPreviousPost.TabIndex = 6;
            this.btnPreviousPost.Text = "<";
            this.btnPreviousPost.UseVisualStyleBackColor = true;
            this.btnPreviousPost.Click += new System.EventHandler(this.btnPreviousPost_Click);
            // 
            // btnNewPost
            // 
            this.btnNewPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewPost.Location = new System.Drawing.Point(83, 213);
            this.btnNewPost.Name = "btnNewPost";
            this.btnNewPost.Size = new System.Drawing.Size(46, 26);
            this.btnNewPost.TabIndex = 5;
            this.btnNewPost.Text = "New";
            this.btnNewPost.UseVisualStyleBackColor = true;
            this.btnNewPost.Click += new System.EventHandler(this.btnNewPost_Click);
            // 
            // txtPost
            // 
            this.txtPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtPost.Location = new System.Drawing.Point(2, 101);
            this.txtPost.Margin = new System.Windows.Forms.Padding(2);
            this.txtPost.Multiline = true;
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(275, 109);
            this.txtPost.TabIndex = 4;
            this.txtPost.TextChanged += new System.EventHandler(this.txtPost_TextChanged);
            // 
            // labPost
            // 
            this.labPost.AutoSize = true;
            this.labPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPost.Location = new System.Drawing.Point(116, 80);
            this.labPost.Name = "labPost";
            this.labPost.Size = new System.Drawing.Size(49, 20);
            this.labPost.TabIndex = 3;
            this.labPost.Text = "Posts";
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(213, 29);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(66, 45);
            this.btnUpdateStatus.TabIndex = 2;
            this.btnUpdateStatus.Text = "Update";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtStatus.Location = new System.Drawing.Point(12, 29);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(2);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(196, 45);
            this.txtStatus.TabIndex = 1;
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labStatus.Location = new System.Drawing.Point(79, 8);
            this.labStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(56, 20);
            this.labStatus.TabIndex = 0;
            this.labStatus.Text = "Status";
            this.labStatus.Click += new System.EventHandler(this.txtStatus_Click);
            // 
            // btnGetUserInfo
            // 
            this.btnGetUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetUserInfo.Location = new System.Drawing.Point(9, 250);
            this.btnGetUserInfo.Name = "btnGetUserInfo";
            this.btnGetUserInfo.Size = new System.Drawing.Size(80, 26);
            this.btnGetUserInfo.TabIndex = 14;
            this.btnGetUserInfo.Text = "User Info";
            this.btnGetUserInfo.UseVisualStyleBackColor = true;
            this.btnGetUserInfo.Click += new System.EventHandler(this.btnGetUserInfo_Click);
            // 
            // formUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 350);
            this.Controls.Add(this.panSocial);
            this.Name = "formUser";
            this.Text = "User Menu";
            this.Load += new System.EventHandler(this.formUser_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panSocial, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panSocial.ResumeLayout(false);
            this.panSocial.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panSocial;
        protected System.Windows.Forms.TextBox txtStatus;
        protected System.Windows.Forms.Label labStatus;
        protected System.Windows.Forms.Button btnUpdateStatus;
        protected System.Windows.Forms.Label labPost;
        protected System.Windows.Forms.TextBox txtPost;
        protected System.Windows.Forms.Button btnNewPost;
        protected System.Windows.Forms.Button btnNextPost;
        protected System.Windows.Forms.Button btnPreviousPost;
        protected System.Windows.Forms.Button btnGetPost;
        protected System.Windows.Forms.Button btnPlaylist;
        protected System.Windows.Forms.Button btnSendTicket;
        protected System.Windows.Forms.TextBox txtTargetUsername;
        protected System.Windows.Forms.Button btnRestoreYourPosts;
        protected System.Windows.Forms.Button btnDeletePost;
        protected System.Windows.Forms.Button btnGetUserInfo;
    }
}