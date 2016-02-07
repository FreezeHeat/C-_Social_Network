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
        formAccount parent;
        Database database = Database.getDatabase();
        Color defaultText; 
        Color defaultBG;

        public formCustomizeWindow(int index, formAccount parent)
        {
            InitializeComponent();
            this.Show();
            this.parent = parent;
            this.user = (User)database.Accounts[index];
            this.defaultText = this.parent.ForeColor;
            this.defaultBG = this.parent.BackColor;
            if (user.BG == null)
            {
                user.BG = defaultBG;
            }
            if (user.Text == null)
            {
                user.Text = defaultText;
            }
        }

        private void formCustomizeWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (sameColors(colorDialog.Color, this.user.Text) == false) // בדיקה בין טקסט לרקע
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

        private void btnBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                if (sameColors(colorDialog.Color, this.user.BG) == false)// בדיקה בין טקסט לרקע
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

        private bool sameColors(Color a, Color b)
        {
            if(a.Equals(b)) // אם אותם הצבעים, תחזיר לברירת  מחדל
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
            parent.Show();
        }
    }
}
