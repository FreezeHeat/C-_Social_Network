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
    public partial class formTechSupport : formAccount//change omer 12.2
    {
        private Home parent;
        private Database database = Database.getDatabase();
        private List<Ticket> tickets;
        private TechSupport tech;

        public formTechSupport(Account tech, Home parent)//change
        {
            InitializeComponent();
            tickets = database.getAllTickets();
            this.tech = (TechSupport)tech;
            this.parent = parent;
            ticketComboBox.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private void ticketBox(TechSupport tech)
        {
            for (int i = 0; i < tickets.Count; i++)//מילוי הטבלה בערכים חוץ מהנציג הנוכחי
            {

                string[] row = new string[] { tickets[i].Username, tickets[i].Details, tickets[i].Representative, tickets[i].Date };
                dgvTicketBox.Rows.Add(row);

            }


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
            formManageUsers manageUsers = new formManageUsers(tech, this);//change
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

        private void ticketComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            String item = ticketComboBox.SelectedItem.ToString();
            switch (item)
            {
                case "Open Tickets":
                    dgvTicketBox.Columns.Clear();
                    //for (int i = 0; i < tickets.Count; i++)//מילוי הטבלה בערכים חוץ מהנציג הנוכחי
                    //{
                    //    if(tickets[i].Representative==null)
                    //    string[] row = new string[] { tickets[i].Username, tickets[i].Details, tickets[i].Representative, tickets[i].Date };
                    //    dgvTicketBox.Rows.Add(row);

                    //}
                    break;
                case "My Tickets":
                    dgvTicketBox.Columns.Clear();
                    break;
                case "All Tickets":
                    dgvTicketBox.Columns.Clear();
                    break;
            }


        }

    }
}
