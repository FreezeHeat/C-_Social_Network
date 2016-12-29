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
        private List<Account> userslist;

        public formAdmin(Account account, Home parent) : base(account, parent)
        {
            InitializeComponent();
            admin = (Admin)account;
            this.parent = parent;
            loadTable(admin);

            if (admin.Text.ToArgb() != 0 || admin.BG.ToArgb() != 0) 
            {
                this.ForeColor = admin.Text;
                this.BackColor = admin.BG;
            }
        }

        private void loadTable(Admin admin)
        {
            dgvManage.Rows.Clear();
            userslist = database.getAllAccounts();

            for (int i = 0; i < userslist.Count; i++)
            {
                if (userslist[i].Username != admin.Username)
                {
                    string[] row = new string[] { userslist[i].Fname, userslist[i].Lname, userslist[i].Username };
                    dgvManage.Rows.Add(row);  
                } 
            }

            dgvManage.Refresh();
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

            String username = dgvManage.Rows[i].Cells[2].Value.ToString();

            if (admin.Username != username) 
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
            formSignUp form = new formSignUp(this, admin, (int)Program.permissionLevels.Admin);
            form.FormClosed += new FormClosedEventHandler(childClosed);
            this.Hide();
            form.Show();
        }

        private void btnAddTech_Click(object sender, EventArgs e)
        {
            formSignUp form = new formSignUp(this, admin, (int)Program.permissionLevels.TechSupport);
            form.FormClosed += new FormClosedEventHandler(childClosed);
            this.Hide();
            form.Show();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            formSignUp form = new formSignUp(this, admin, (int)Program.permissionLevels.User);
            form.FormClosed += new FormClosedEventHandler(childClosed);
            this.Hide();
            form.Show();
        }

        private void btnDisableAccount_Click(object sender, EventArgs e)
        {
            int i = dgvManage.Rows[dgvManage.CurrentRow.Index].Index;

            String username = dgvManage.Rows[i].Cells[2].Value.ToString();

            if (admin.Username != username) 
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
                MessageBox.Show("You can't disable yourself...");
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
            loadTable(admin);
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            int i = dgvManage.Rows[dgvManage.CurrentRow.Index].Index;

            String username = dgvManage.Rows[i].Cells[2].Value.ToString();

            if (admin.Username != username) 
            {
                if (dgvRow.Index > -1)
                {
                    admin.reEnableAccount(username);
                    dgvManage.Refresh();
                    MessageBox.Show(username + " was re-enabled");
                }
            }
        }

    }
}
