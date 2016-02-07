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
    public partial class formSettings : Form
    {
        protected int index;

        public formSettings()
        {
            InitializeComponent();
        }

        protected void formSettings_Load(object sender, EventArgs e)
        {

        }

        protected virtual void btnChangeDetails_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Change details!");
        }
    }
}
