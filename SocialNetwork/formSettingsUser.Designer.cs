namespace SocialNetwork
{
    partial class formSettingsUser
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
            this.btnCustomizeWindow = new System.Windows.Forms.Button();
            this.btnRemoveOwnAccount = new System.Windows.Forms.Button();
            this.btnBackupPosts = new System.Windows.Forms.Button();
            this.btnRestorePosts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChangeDetails
            // 
            this.btnChangeDetails.Location = new System.Drawing.Point(124, 6);
            // 
            // btnCustomizeWindow
            // 
            this.btnCustomizeWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomizeWindow.Location = new System.Drawing.Point(124, 61);
            this.btnCustomizeWindow.Name = "btnCustomizeWindow";
            this.btnCustomizeWindow.Size = new System.Drawing.Size(353, 48);
            this.btnCustomizeWindow.TabIndex = 1;
            this.btnCustomizeWindow.Text = "Customize Window";
            this.btnCustomizeWindow.UseVisualStyleBackColor = true;
            this.btnCustomizeWindow.Click += new System.EventHandler(this.btnCustomizeWindow_Click);
            // 
            // btnRemoveOwnAccount
            // 
            this.btnRemoveOwnAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveOwnAccount.Location = new System.Drawing.Point(124, 248);
            this.btnRemoveOwnAccount.Name = "btnRemoveOwnAccount";
            this.btnRemoveOwnAccount.Size = new System.Drawing.Size(353, 48);
            this.btnRemoveOwnAccount.TabIndex = 2;
            this.btnRemoveOwnAccount.Text = "Remove your account";
            this.btnRemoveOwnAccount.UseVisualStyleBackColor = true;
            this.btnRemoveOwnAccount.Click += new System.EventHandler(this.btnRemoveOwnAccount_Click);
            // 
            // btnBackupPosts
            // 
            this.btnBackupPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackupPosts.Location = new System.Drawing.Point(124, 115);
            this.btnBackupPosts.Name = "btnBackupPosts";
            this.btnBackupPosts.Size = new System.Drawing.Size(353, 48);
            this.btnBackupPosts.TabIndex = 3;
            this.btnBackupPosts.Text = "Backup Posts";
            this.btnBackupPosts.UseVisualStyleBackColor = true;
            //this.btnBackupPosts.Click += new System.EventHandler(this.btnBackupPosts_Click);
            // 
            // btnRestorePosts
            // 
            this.btnRestorePosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestorePosts.Location = new System.Drawing.Point(124, 169);
            this.btnRestorePosts.Name = "btnRestorePosts";
            this.btnRestorePosts.Size = new System.Drawing.Size(353, 48);
            this.btnRestorePosts.TabIndex = 4;
            this.btnRestorePosts.Text = "Restore Posts";
            this.btnRestorePosts.UseVisualStyleBackColor = true;
            //this.btnRestorePosts.Click += new System.EventHandler(this.btnRestorePosts_Click);
            // 
            // formSettingsUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 350);
            this.Controls.Add(this.btnRestorePosts);
            this.Controls.Add(this.btnBackupPosts);
            this.Controls.Add(this.btnRemoveOwnAccount);
            this.Controls.Add(this.btnCustomizeWindow);
            this.Name = "formSettingsUser";
            this.Load += new System.EventHandler(this.formSettingsUser_Load);
            this.Controls.SetChildIndex(this.btnChangeDetails, 0);
            this.Controls.SetChildIndex(this.btnCustomizeWindow, 0);
            this.Controls.SetChildIndex(this.btnRemoveOwnAccount, 0);
            this.Controls.SetChildIndex(this.btnBackupPosts, 0);
            this.Controls.SetChildIndex(this.btnRestorePosts, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCustomizeWindow;
        private System.Windows.Forms.Button btnRemoveOwnAccount;
        private System.Windows.Forms.Button btnBackupPosts;
        private System.Windows.Forms.Button btnRestorePosts;
    }
}