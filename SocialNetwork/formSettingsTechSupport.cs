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
    public partial class formSettingsTechSupport : formSettings
    {
        private formTechSupport parent;
        private Database database = Database.getDatabase();
        public formSettingsTechSupport(ref int index, formTechSupport parent)
        {
            InitializeComponent();
            this.index = index;
            TechSupport tech = (TechSupport)database.Accounts[index];
            this.parent = parent;

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            parent.Show();
        }
        private void childClosed(object sender, EventArgs e)
        {
            this.Show();
        }

        protected override void btnChangeDetails_Click(object sender, EventArgs e)
        {
            formChangeDetailsTechSupport form = new formChangeDetailsTechSupport(ref index);
            form.FormClosed += new FormClosedEventHandler(childClosed);
            this.Hide();
            form.Show();
        }
    }
}
