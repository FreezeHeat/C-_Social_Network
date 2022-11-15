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
    public partial class formSettingsAdmin : formSettings
    {
        Admin admin;
        formAdmin parent;

        public formSettingsAdmin(Admin admin, formAdmin parent)
        {
            InitializeComponent();
            this.admin = admin;
            this.parent = parent;
        }

        private void btnCustomizeWindow_Click(object sender, EventArgs e)
        {
            formCustomizeWindow customize = new formCustomizeWindow(admin, this.parent);
            
            this.Hide();
        }

        protected override void btnChangeDetails_Click(object sender, EventArgs e)
        {
            formChangeDetails form = new formChangeDetails(admin);
            form.FormClosed += new FormClosedEventHandler(childClosed);
            this.Hide();
            form.Show();
        }

        private void childClosed(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnCustomizeWindow_Click_1(object sender, EventArgs e)
        {
            formCustomizeWindow customize = new formCustomizeWindow(admin, this.parent);
            
            this.Hide();
        }
    }
}
