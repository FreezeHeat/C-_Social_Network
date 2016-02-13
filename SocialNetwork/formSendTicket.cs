using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialNetwork.source
{
    public partial class formSendTicket : Form
    {
        private User user;
        private formAccount parent;
        private Database database = Database.getDatabase();

        public formSendTicket(formAccount parent, User user)
        {
            InitializeComponent();
            this.parent = parent;
            this.user = user;
            this.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            String ticket = user.sendTicket(txtTicket.Text);
            MessageBox.Show(ticket);
            this.Close();
        }

        private void formSendTicket_Load(object sender, EventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
                parent.Show();
        }

        private void txtTicket_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
