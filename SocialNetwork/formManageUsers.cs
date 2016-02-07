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
    public partial class formManageUsers : Form
    {
        private formTechSupport parent;
        private Database database = Database.getDatabase();
        private List<Account> userslist=Database.getDatabase().Accounts;
        private TechSupport tech;
        private int index;
        private int ptr=-1;//מצביע  לשורה בטבלה
        private bool wasTriedToChange = false;//האם בוצע שינוי בטבלה או לא 



        
        public formManageUsers(int index,formTechSupport parent)
        {
            InitializeComponent();
            this.index = index;
            tech = (TechSupport)database.Accounts[index];
            this.parent = parent;
            loadTable(tech);
            dgvUsers.CurrentCell = dgvUsers.Rows[0].Cells["colPassword"];
            
     




        }

        private void loadTable(TechSupport tech)
        {
            for (int i = 0; i < userslist.Count; i++)//מילוי הטבלה בערכים חוץ מהנציג הנוכחי
            {
                if (!userslist[i].Equals(tech))
                {
                    string[] row = new string[] { userslist[i].Username, userslist[i].Password, userslist[i].Disabled.ToString() };
                    dgvUsers.Rows.Add(row);

                }

            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (wasTriedToChange)
            {
                int indexcmp = database.Accounts.FindIndex(x => x.Username.Equals(dgvUsers.Rows[ptr].Cells["colUserName"].FormattedValue.ToString()));
                String flag;
                for (int checker = 0; checker < dgvUsers.Rows.Count-1; checker++)//בדיקה ועדכון של שינויים בטבלה לפי הדגלים
                {
                    flag = dgvUsers.Rows[checker].Cells["colMaybeChanged"].FormattedValue.ToString();
                    if (flag.Equals("1"))
                        if (!dgvUsers.Rows[ptr].Cells["colPassword"].FormattedValue.Equals(database.Accounts[indexcmp].Password))//בדיקה אם הערכים בנתונים שווים לערכים בטבלה ואם לא נעשה עדכון
                            database.Accounts[indexcmp].Password = dgvUsers.Rows[ptr].Cells["colPassword"].Value.ToString();


                }
            }
                
            parent.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }

        private void  btnDisableAccount_Click(object sender, EventArgs e)//נעילת חשבון
        {
            if (ptr != -1)
            {
                if (database.Accounts[ptr].Disabled==false)
                {
                    database.Accounts[ptr].Disabled = true;
                    
                    dgvUsers.Rows[ptr].Cells["colEnableDisable"].Value = true;
                    dgvUsers.Refresh();
                }
            }

        }

        private void dgvUsers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)//הצבעה על שורה בטבלה
       {
           ptr =e.RowIndex;
           

        }

        private void btnReEnableAccount_Click(object sender, EventArgs e)//שחרור חשבון
        {
            if (ptr != -1)
            {
                if (database.Accounts[ptr].Disabled == true)
                {
                    database.Accounts[ptr].Disabled = false;

                    dgvUsers.Rows[ptr].Cells["colEnableDisable"].Value = false;
                    dgvUsers.Refresh();
                }
            }
        }

        private void btnEnableResetPassword_Click(object sender, EventArgs e)//ניתנת אפשרות לערוך את הסיסמא
        {
            try
            {
                if (ptr != -1)
                {////בדיקת קצה האם אנחנו באזור תקין בטבלה
                    dgvUsers.Rows[ptr].Cells["colPassword"].ReadOnly = false;
                    wasTriedToChange = true;
                    dgvUsers.Rows[ptr].Cells["colMaybeChanged"].Value = 1;//מדליק דגל שאולי מישהו רוצה לשנות משהו בתא  הזה
                    dgvUsers.Refresh();
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
          
        }

        private void btnDisableResetPassword_Click(object sender, EventArgs e)//ביטול אפשרות עריכה לסיסמא
        {
            try
            {
                if (ptr != -1)//בדיקת קצה האם אנחנו באזור תקין בטבלה
                {
                    dgvUsers.Rows[ptr].Cells["colPassword"].ReadOnly = true;
                    dgvUsers.RefreshEdit();
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

    }

}
