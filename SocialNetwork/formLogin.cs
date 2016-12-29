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
    public partial class formLogin : Form {

        private Home parent;
        private bool close = true;
        private Database database = Database.getDatabase();
        private int count = 0;

        public formLogin(Home parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void LogMain_Load(object sender, EventArgs e)
        {

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (close) 
            {
                parent.Show();
            }
        }

        private void formLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Return)
            {
                login();
            }
        }

        private void login()
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;

            


            
            if (database.checkIfUserExists(username) == false)
            {
                MessageBox.Show("Wrong Account Details");
                if (count++ == 3)
                { 
                    MessageBox.Show("Too many attempts");
                    this.Close();
                }
            }
            else
            {
                
                Account account = database.Login(username, password);

                if (account == null)
                {
                    MessageBox.Show("Wrong account details");
                }

                else
                {
                    
                    if (account.Disabled == true)
                    {
                        formDisabled disabled = new formDisabled(account, parent);
                    }
                    else {
                        switch (account.Permission) 
                        {
                            case 0:
                                close = false;
                                this.Close();
                                formUser user = new formUser(account, parent); 
                                user.Show();
                                break;
                            case 1:
                                close = false;
                                this.Close();
                                formTechSupport tech = new formTechSupport(account, parent); 
                                tech.Show();
                                break;
                            case 2:
                                close = false;
                                this.Close();
                                formAdmin admin = new formAdmin(account, parent); 
                                admin.Show();
                                break;
                            default:
                                MessageBox.Show("Error - account permission unknown"); 
                                close = false;
                                this.Close();
                                break;
                        }
                    }
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Return)
            {
                login();
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter || e.KeyValue == (char)Keys.Return)
            {
                login();
            }
        }
    }
}
