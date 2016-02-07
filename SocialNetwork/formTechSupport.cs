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
    public partial class formTechSupport : formAccount
    {
        private Home parent;
        private Database database = Database.getDatabase();


        
     
        
        public formTechSupport(int index, Home parent)
        {
            InitializeComponent();
            this.index = index;
            TechSupport tech = (TechSupport)database.Accounts[index];
            this.parent = parent;
            
        }


        private void Tickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            parent.Show();
        }

        private void btnManageUsers_Click_1(object sender, EventArgs e)
        {
            formManageUsers manageUsers = new formManageUsers(index, this);
            this.Hide();
            manageUsers.Show();

        }

        protected override void btnSettings_Click(object sender, EventArgs e)
        {
            formSettingsTechSupport form = new formSettingsTechSupport(ref index, this);
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
