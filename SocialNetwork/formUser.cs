using SocialNetwork.source;
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
    public partial class formUser : formAccount
    {
        private User user;
        private Home parent;
        private Database database = Database.getDatabase();
        private List<Post> posts;
        private List<Post> targetPosts; 
        private int yourPostLocation; 
        private int elsePostLocation; 
        private bool yourPosts = true; 
        
        public formUser(Account account, Home parent) : base(account, parent)
        {
            InitializeComponent();
            user = (User)account;

            if (user.Text.ToArgb() != 0 || user.BG.ToArgb() != 0) /* Implement the user's Text and BG color*/
            {
                this.ForeColor = user.Text;
                this.BackColor = user.BG;
            }

            this.posts = database.getAllPosts(user.Username);
            this.yourPostLocation = this.posts.Count - 1;
            this.parent = parent;
        }

        private void formUser_Load(object sender, EventArgs e)
        {
            this.txtStatus.Text = user.Status;
            txtPost.Text = ""; 
            if (yourPostLocation >= 0)
            { /* If there are posts*/
                txtPost.Text = posts[posts.Count - 1].ToString(); /* Latest post */
            }
            this.txtPost.ReadOnly = true; /* Make it read-only */
            this.Refresh();
        }

        
        
            
        

        protected override void btnSend_Click(object sender, EventArgs e) 
        {


            
            
            
            
            
            
            
            
            
            
            String result = user.sendMessage(txtRecipient.Text, txtSend.Text);
            MessageBox.Show(result);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtStatus_Click(object sender, EventArgs e)
        {

        }

        private void panSocial_Paint(object sender, PaintEventArgs e)
        {

        }

        protected override void btnSettings_Click(object sender, EventArgs e)
        {
            formSettingsUser form = new formSettingsUser(user, this);
            form.FormClosed += new FormClosedEventHandler(childClosed);
            this.Hide();
            form.Show();
        }

        private void childClosed(object sender, EventArgs e)
        {
            this.Show();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            parent.Show();
        }

        private void labPost_Click(object sender, EventArgs e)
        {

        }

        private void txtSend_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtRecipient_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            
            if (this.txtStatus.Text.Any(Char.IsLetterOrDigit) == true)
            {
                MessageBox.Show(user.updateStatus(txtStatus.Text));
                user.Status = this.txtStatus.Text;
            }
        }

        private void btnNewPost_Click(object sender, EventArgs e)
        {
            txtPost.ReadOnly = false; 
            txtPost.Text = "Please enter your new post";
            txtPost.Focus();
            txtPost.Leave += TxtPost_Leave; /* in a situation where the user posts a new post and didn't do anything*/
        }

        private void TxtPost_Leave(object sender, EventArgs e)
        {
            String result = user.checkPost(txtPost.Text);
            if (result != null) 
            {
                MessageBox.Show(result);
                txtPost.Focus();
            }

            else 
            {
                DialogResult = MessageBox.Show("Confirm Your Post", "Confirm Dialog", MessageBoxButtons.OKCancel);

                if (DialogResult == DialogResult.OK)
                {
                    Post post = new Post(user.Username, txtPost.Text);
                    MessageBox.Show(user.addPost(post));
                    this.reset();
                    txtPost.Leave -= TxtPost_Leave;
                    txtPost.ReadOnly = true;
                }

                else
                {
                    txtPost.Leave -= TxtPost_Leave;
                    this.txtPost.Clear();
                }
            }
        }

        private void btnPreviousPost_Click(object sender, EventArgs e)
        {
            if (this.yourPosts == true)
            {
                if (this.yourPostLocation > 0)
                {
                    this.yourPostLocation--;
                    txtPost.Text = posts[this.yourPostLocation].ToString();
                }
                else
                {
                    MessageBox.Show("No previous posts");
                }
            }



            else
            {
                if (this.elsePostLocation > 0)
                {
                    this.elsePostLocation--;
                    txtPost.Text = targetPosts[this.elsePostLocation].ToString();
                }
                else
                {
                    MessageBox.Show("No previous posts");
                }
            }
        }

        private void btnNextPost_Click(object sender, EventArgs e)
        {
            if (this.yourPosts == true)
            {
                if (this.yourPostLocation < posts.Count - 1)
                {
                    this.yourPostLocation++;
                    txtPost.Text = posts[this.yourPostLocation].ToString();
                }
                else
                {
                    MessageBox.Show("No newer posts");
                }
            }



            else
            {
                if (this.elsePostLocation < targetPosts.Count - 1)
                {
                    this.elsePostLocation++;
                    txtPost.Text = targetPosts[this.elsePostLocation].ToString();
                }
                else
                {
                    MessageBox.Show("No newer posts");
                }
            }
        }

        private void txtPost_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGetPost_Click(object sender, EventArgs e)
        {
            if (database.checkIfUserExists(this.txtTargetUsername.Text) == true) 
            {
                if (database.checkPermission(this.txtTargetUsername.Text) != null) 
                {
                    this.yourPosts = false;
                    this.targetPosts = database.getAllPosts(this.txtTargetUsername.Text); 
                    this.elsePostLocation = this.targetPosts.Count - 1;
                    if (this.elsePostLocation >= 0) { this.refreshPost(); }
                    else { MessageBox.Show("This user has no posts..."); }
                }
            }

            else
            {
                MessageBox.Show("No such user found");
            }
        }

        private void btnRestoreYourPosts_Click(object sender, EventArgs e)
        {
            this.yourPosts = true;
            if(posts.Count <= 0)
            {
                MessageBox.Show("You have no posts...");
            }
            this.refreshPost();
        }

        private void refreshPost() 
        {

            if (this.yourPosts == true && this.yourPostLocation >= 0) {
                this.txtPost.Text = posts[yourPostLocation].ToString();
            }

            else if (this.yourPosts == false && this.elsePostLocation >= 0) {
                this.txtPost.Text = targetPosts[elsePostLocation].ToString();
            }
            else
            {
                this.txtPost.Text = "";
            }

            this.Refresh();
        }

        private void txtTargetUsername_Click(object sender, EventArgs e)
        {
            this.txtTargetUsername.Text = "";
            this.txtTargetUsername.Focus();
        }

        private void btnBackupPosts_Click(object sender, EventArgs e)
        {

        }

        private void btnDeletePost_Click(object sender, EventArgs e)
        {
            if (this.yourPosts == false)
            {
                MessageBox.Show("You can't delete someone else's posts");
            }
            else if (this.yourPostLocation >= 0)
            {
                
                database.RemovePost(this.posts[this.yourPostLocation].ID);

                
                this.posts.RemoveAt(this.yourPostLocation);
                this.yourPostLocation--;
                this.refreshPost();
            }
            else
            {
                MessageBox.Show("No posts to delete");
            }
        }

        private void txtRecipient_Click(object sender, EventArgs e)
        {
            this.txtRecipient.Text = "";
            this.txtRecipient.Focus();
        }

        private void btnSendTicket_Click(object sender, EventArgs e)
        {
            formSendTicket sendTicket = new formSendTicket(this, user);
            this.Hide();
        }

        public void btnPlaylist_Click(object sender, EventArgs e)
        {
            MP3Player mp3 = new MP3Player();
            mp3.Show();
        }

        public void reset() 
        {
            this.database = Database.getDatabase();
            this.posts = database.getAllPosts(user.Username);
            this.targetPosts = null;
            this.yourPostLocation = this.posts.Count - 1;
            this.elsePostLocation = -1;
            this.yourPosts = true;
            this.refreshPost();

            if (user.Text.ToArgb() != 0 || user.BG.ToArgb() != 0) 
            {
                this.ForeColor = user.Text;
                this.BackColor = user.BG;
            }
            this.Refresh();
        }

        private void btnGetUserInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(user.getUserDetails(txtTargetUsername.Text));
        }
    }
}
