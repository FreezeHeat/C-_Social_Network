using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialNetwork.source;

namespace SocialNetwork
{
    public partial class formDisabled : formAccount {
        private Home parent;
        private User user;
        public formDisabled(Account user,Home parent):base(user,parent)
        {

            InitializeComponent();
            this.parent = parent;
            this.user = (User)user;
            this.Show();
        }

        private void btnSendTicket_Click(object sender, EventArgs e)
        {

        }
        private void childClosed(object sender, EventArgs e)
        {
            this.Show();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            parent.Show();
        }
        private void button1_Click_1(object sender,EventArgs e)
        {
            formSendTicket sendTicket = new formSendTicket(this, user);
            this.Hide();
        }
    }
}
