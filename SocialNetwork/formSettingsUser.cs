using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialNetwork
{
    public partial class formSettingsUser : formSettings
    {
        private User user;
        private Database database = Database.getDatabase();
        private formUser parent;

        public formSettingsUser(User user, formUser parent)
        {
            InitializeComponent();
            this.user = user;
            this.parent = parent;
        }

        private void formSettingsUser_Load(object sender, EventArgs e)
        {
        }

        protected override void btnChangeDetails_Click(object sender, EventArgs e)
        {
            formChangeDetailsUser form = new formChangeDetailsUser(user);
            form.FormClosed += new FormClosedEventHandler(childClosed);
            this.Hide();
            form.Show();
        }

        private void btnCustomizeWindow_Click(object sender, EventArgs e)
        {
            formCustomizeWindow customize = new formCustomizeWindow(user, this.parent);
            //customize.FormClosed += new 
            this.Hide();
        }

        private void childClosed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnRemoveOwnAccount_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Remove your account", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes)
            {
                database.deleteAccount(user.Username);
                this.Close();
                parent.Close();
            }
        }

        //private void btnBackupPosts_Click(object sender, EventArgs e)
        //{
        //    if (user.posts.Posts.Count > 0)
        //    {
        //        user.posts.createBackup();
        //        MessageBox.Show("Backup is complete");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Nothing to backup (No posts)");
        //    }
        //}

        //private void btnRestorePosts_Click(object sender, EventArgs e)
        //{
        //    if(user.posts.Backup == null)
        //    {
        //        MessageBox.Show("No backup available");
        //    }
        //    else { 
        //    DialogResult result = MessageBox.Show("Are you sure you want to restore backup from:\r\n" +
        //        user.posts.BackupTime, "Confirm Restore", MessageBoxButtons.YesNo);

        //        if (result == DialogResult.Yes)
        //        {
        //            user.posts.restoreBackup();
        //            MessageBox.Show("Restore Complete");
        //            parent.reset();
        //        }
        //    }
        //}
    }
}
