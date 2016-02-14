using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SocialNetwork.source;

namespace SocialNetwork
{
    public partial class formManageUsers : Form///עמר 2\12 כל המחלקה שונתה  
    {
        private formTechSupport parent;
        private Database database = Database.getDatabase();
        private List<Account> userslist;
        private TechSupport tech;
        private int ptr = -1;//מצביע  לשורה בטבלה




        public formManageUsers(TechSupport tech, formTechSupport parent)
        {
            InitializeComponent();
            this.tech = tech;
            this.parent = parent;
            userslist = database.getAllAccounts();
            loadTable(tech);
            dgvUsers.CurrentCell = dgvUsers.Rows[0].Cells["colPassword"];






        }

        private void loadTable(TechSupport tech)
        {
            for (int i = 0; i < userslist.Count; i++)//מילוי הטבלה בערכים חוץ מהנציג הנוכחי
            {
                if (userslist[i].Username != tech.Username)
                {
                    string[] row = new string[] { userslist[i].Username, userslist[i].Password, userslist[i].Disabled.ToString() };
                    dgvUsers.Rows.Add(row);

                }

            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            {



                parent.Show();
                this.Hide();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnDisableAccount_Click(object sender, EventArgs e)//נעילת חשבון
        {

            if (ptr != -1)
            {
                int tempLocal = userslist.FindIndex(x => x.Username.Equals(dgvUsers.Rows[ptr].Cells["colUserName"].FormattedValue.ToString()));

                if (userslist[tempLocal].Permission != 2 && userslist[tempLocal].Disabled == false)
                {

                    tech.disableAccount(dgvUsers.Rows[ptr].Cells["colUserName"].FormattedValue.ToString());
                    userslist[tempLocal].Disabled = true;
                    dgvUsers.Rows[ptr].Cells["colEnableDisable"].Value = true;
                    dgvUsers.Refresh();
                }
            }

        }

        private void dgvUsers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)//הצבעה על שורה בטבלה
        {
            ptr = e.RowIndex;


        }

        private void btnReEnableAccount_Click(object sender, EventArgs e)//שחרור חשבון
        {
            if (ptr != -1)
            {
                int tempLocal = userslist.FindIndex(x => x.Username.Equals(dgvUsers.Rows[ptr].Cells["colUserName"].FormattedValue.ToString()));
                if (userslist[tempLocal].Disabled == true)
                {
                    tech.reEnableAccount(dgvUsers.Rows[ptr].Cells["colUserName"].FormattedValue.ToString());
                    userslist[tempLocal].Disabled = false;
                    dgvUsers.Rows[ptr].Cells["colEnableDisable"].Value = false;
                    dgvUsers.Refresh();
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)//ניתנת אפשרות לערוך את הסיסמא
        {
            try
            {
                if (ptr != -1)////בדיקת קצה האם אנחנו באזור תקין בטבלה
                {
                    String tempLocal = dgvUsers.Rows[ptr].Cells["colUserName"].FormattedValue.ToString();
                    tech.resetPassword(tempLocal);

                    dgvUsers.Rows[ptr].Cells["colPassword"].Value = "0";
                    dgvUsers.Refresh();
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }



        private void dgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }

}
