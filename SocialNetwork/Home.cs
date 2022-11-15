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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            formLogin login = new formLogin(this);
            login.Show();
            this.Hide();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            formSignUp signup = new formSignUp(this);
            signup.Show();
            this.Hide();
        }

        private void labMenu_Click(object sender, EventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // Make sure user wants to exit
            DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Quit", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

    }
}
