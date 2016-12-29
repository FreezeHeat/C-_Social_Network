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
    public partial class formCustomizeWindow : Form
    {
        User user;
        Admin admin;
        formAccount parent;
        Database database = Database.getDatabase();
        Color defaultText; 
        Color defaultBG;

        public formCustomizeWindow(Account account, formAccount parent)
        {
            InitializeComponent();
            this.Show();
            this.parent = parent;

            if(account.Permission == 2)
            {
                this.admin = (Admin)account;
                this.defaultText = this.parent.ForeColor;
                this.defaultBG = this.parent.BackColor;
                if (admin.BG == null)
                {
                    admin.BG = defaultBG;
                }
                if (admin.Text == null)
                {
                    admin.Text = defaultText;
                }
            }

            if(account.Permission == 0)
            {
                this.user = (User)account;
                this.defaultText = this.parent.ForeColor;
                this.defaultBG = this.parent.BackColor;
                if (user.BG.ToArgb() == 0)
                {
                    user.BG = defaultBG;
                }
                if (user.Text.ToArgb() == 0)
                {
                    user.Text = defaultText;
                }
            }
        }

        private void formCustomizeWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            if (admin == null)
            {
                if (this.colorDialog.ShowDialog() == DialogResult.OK)
                {
                    if (sameColors(colorDialog.Color, this.user.BG) == false) 
                    {
                        user.Text = colorDialog.Color;
                        this.ForeColor = colorDialog.Color;
                        parent.ForeColor = colorDialog.Color;
                        this.Refresh();
                        parent.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Text and BG cannot be the same color");
                    }
                }
            }
            else
            {
                if (this.colorDialog.ShowDialog() == DialogResult.OK)
                {
                    if (sameColors(colorDialog.Color, this.admin.Text) == false) 
                    {
                        admin.Text = colorDialog.Color;
                        this.ForeColor = colorDialog.Color;
                        parent.ForeColor = colorDialog.Color;
                        this.Refresh();
                        parent.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Text and BG cannot be the same color");
                    }
                }
            }
        }

        private void btnBackgroundColor_Click(object sender, EventArgs e)
        {
            if (admin == null)
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    if (sameColors(colorDialog.Color, this.user.Text) == false)
                    {
                        user.BG = colorDialog.Color;
                        this.BackColor = colorDialog.Color;
                        parent.BackColor = colorDialog.Color;
                        this.Refresh();
                        parent.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Text and BG cannot be the same color");
                    }
                }
            }

            else
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    if (sameColors(colorDialog.Color, this.admin.Text) == false)
                    {
                        admin.BG = colorDialog.Color;
                        this.BackColor = colorDialog.Color;
                        parent.BackColor = colorDialog.Color;
                        this.Refresh();
                        parent.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Text and BG cannot be the same color");
                    }
                }
            }
        }

        private bool sameColors(Color a, Color b)
        {
            if(a.Equals(b)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (admin == null)
            {
                user.changeColors(user.Text, user.BG);
            }
            else
            {
                admin.changeColors(admin.Text, admin.BG);
            }
            parent.Show();
        }
    }
}
