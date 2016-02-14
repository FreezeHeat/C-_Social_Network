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
        private TechSupport tech;

        public formSettingsTechSupport(TechSupport tech, formTechSupport parent)
        {
            InitializeComponent();
            this.tech = tech;
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
            formChangeDetails form = new formChangeDetails(tech);
            form.FormClosed += new FormClosedEventHandler(childClosed);
            this.Hide();
            form.Show();
        }
    }
}
