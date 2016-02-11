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

        public formAccount()
        {
            InitializeComponent();
        }

        protected virtual void formAccount_Load(object sender, EventArgs e)
        {

        }

        protected virtual void btnSettings_Click(object sender, EventArgs e)
        {
            
        }

        protected void gridInbox_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // הצגת ההודעה
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

        }
    }
}
