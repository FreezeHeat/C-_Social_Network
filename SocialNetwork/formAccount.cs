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
    public partial class formAccount : Form
    {
        protected int index;
        private Database database = Database.getDatabase();
        private Account account;
        private Home parent;

        private formAccount()
        {
            InitializeComponent();
        }
        public formAccount(Account account, Home parent)
        {
            InitializeComponent();
            this.account = account;
            this.parent = parent;
        }

        protected virtual void formAccount_Load(object sender, EventArgs e)
        {
            resetInbox();
        }

        protected virtual void btnSettings_Click(object sender, EventArgs e)
        {
            
        }

        protected void gridInbox_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            MessageBox.Show(gridInbox.Rows[gridInbox.CurrentRow.Index].Cells["Message"].Value.ToString());
        }

        protected void labInbox_Click(object sender, EventArgs e)
        {

        }

        protected void txtRecipient_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtSend_TextChanged(object sender, EventArgs e)
        {

        }

        protected virtual void btnSend_Click(object sender, EventArgs e)
        {
            String result = account.sendMessage(txtRecipient.Text, txtSend.Text);
            MessageBox.Show(result);
        }

        protected void btnDisconnect_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridInbox_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void gridInbox_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        protected virtual void gridInbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.gridInbox.RowCount > 0)
            {
                if (e.KeyValue == (char)Keys.Delete)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this message?",
                        "Delete Message", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        int index = Int32.Parse(gridInbox.Rows[gridInbox.CurrentRow.Index].Cells["ID"].Value.ToString());
                        account.deleteMessage(index);
                        resetInbox();
                        MessageBox.Show("Deleted Succesfully!");
                        gridInbox.Refresh();
                        e.Handled = true;
                    }
                }
            }
        }

        protected virtual void gridInbox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        protected void resetInbox()
        {
            this.gridInbox.Rows.Clear();             List<Message> messages = database.getInbox(this.account.Username);

            foreach (Message msg in messages)
            {
                string[] message = new string[] { msg.ID.ToString(), msg.Sender, msg.Mail, msg.Date };
                this.gridInbox.Rows.Add(message);
            }
        }
    }
}
