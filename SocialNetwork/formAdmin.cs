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
    public partial class formAdmin : formAccount
    {
        private Home parent;
        private Admin admin;
        private DataGridViewRow dgvRow = new DataGridViewRow();
        private Database database = Database.getDatabase();
        private List<Account> userslist = Database.getDatabase().getAllAccounts();

        public formAdmin(Account account, Home parent) : base(account, parent)
        {
            InitializeComponent();
            admin = (Admin)account;
            this.parent = parent;
            loadTable(admin);
        }

        private void loadTable(Admin admin)
        {
            for (int i = 0; i < userslist.Count; i++)//מילוי הטבלה בערכים חוץ מהנציג הנוכחי
            {
                string[] row = new string[] { userslist[i].Fname, userslist[i].Lname, userslist[i].Username };
                    dgvManage.Rows.Add(row);   
            }
        }

        private void formAdmin_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        protected override void OnClosing(CancelEventArgs e)
        {
            parent.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

          
           
        }
        private void dgvManage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRow = dgvManage.Rows[e.RowIndex];
          
        }



        private void btnRemoveAccount_Click(object sender, EventArgs e)
        {
            int i = dgvManage.Rows[dgvManage.CurrentRow.Index].Index;

            String username = dgvManage.Rows[i].Cells[2].Value.ToString();//neora

            if (i != this.index) //כשאר מנהל רוצה למחוק את עצמו
            {
                if (dgvRow.Index > -1)
                {
                    dgvManage.Rows.Remove(dgvRow);
                    dgvManage.Refresh();
                    MessageBox.Show(admin.DeleteAccount(username));
                }
            }
            else
            {
                MessageBox.Show("You can't delete yourself...");
            }
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            formSignUp form = new formSignUp(this, admin);
            form.adminScheme();
            this.Hide();
            form.Show();
        }

        private void btnAddTech_Click(object sender, EventArgs e)
        {
            formSignUp form = new formSignUp(this, admin);
            form.adminScheme();
            this.Hide();
            form.Show();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            formSignUp form = new formSignUp(this, admin);
            form.adminScheme();
            this.Hide();
            form.Show();
        }

        private void btnDisableAccount_Click(object sender, EventArgs e)
        {
            int i = dgvManage.Rows[dgvManage.CurrentRow.Index].Index;

            String username = dgvManage.Rows[i].Cells[2].Value.ToString();//neora

            if (i != this.index) //כשאר מנהל רוצה למחוק את עצמו
            {
                if (dgvRow.Index > -1)
                {
                    admin.disableAccount(username);
                    dgvManage.Refresh();
                    MessageBox.Show(username + " was disabled");
                }
            }
            else
            {
                MessageBox.Show("You can't delete yourself...");
            }
        }

        protected override void btnSettings_Click(object sender, EventArgs e)
        {
            formSettingsAdmin form = new formSettingsAdmin(admin, this);
            form.FormClosed += new FormClosedEventHandler(childClosed);
            this.Hide();
            form.Show();
        }

        private void childClosed(object sender, EventArgs e)
        {
            this.Show();
        }

    }
}
