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

        public formTechSupport(Account tech, Home parent) : base(tech, parent)//change
        {
            InitializeComponent();
            tickets = database.getAllTickets();
            this.tech = (TechSupport)tech;
            this.parent = parent;
            ticketComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ticketBox(this.tech);


        }

        private void ticketBox(TechSupport tech)
        {
            for (int i = 0; i < tickets.Count; i++)//מילוי הטבלה בערכים חוץ מהנציג הנוכחי
            {

                string[] row = new string[] { tickets[i].Id.ToString(), tickets[i].Username, tickets[i].Details, tickets[i].Representative, tickets[i].Date };
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
            formSettingsTechSupport form = new formSettingsTechSupport(tech, this);
            form.FormClosed += new FormClosedEventHandler(childClosed);
            this.Hide();
            form.Show();
        }
        private void childClosed(object sender, EventArgs e)
        {
            this.Show();
        }
        //omer 13.2
        private void ticketComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            String item = ticketComboBox.SelectedItem.ToString();
            switch (item)
            {
                case "Open":
                    dgvTicketBox.Rows.Clear();
                    for (int i = 0; i < tickets.Count; i++)//מילוי הטבלה בערכים חוץ מהנציג הנוכחי
                    {
                        if (tickets[i].Representative == "")
                        {
                            String[] row = new String[] { tickets[i].Id.ToString(), tickets[i].Username, tickets[i].Details, tickets[i].Representative, tickets[i].Date };
                            dgvTicketBox.Rows.Add(row);
                        }

                    }
                    dgvTicketBox.Refresh();
                    break;
                case "My Tickets":
                    dgvTicketBox.Rows.Clear();
                    for (int i = 0; i < tickets.Count; i++)//מילוי הטבלה בערכים חוץ מהנציג הנוכחי
                    {
                        if (tickets[i].Representative == tech.Username)
                        {
                            String[] row = new String[] { tickets[i].Id.ToString(), tickets[i].Username, tickets[i].Details, tickets[i].Representative, tickets[i].Date };
                            dgvTicketBox.Rows.Add(row);
                        }

                    }
                    dgvTicketBox.Refresh();
                    break;
                case "All Tickets":
                    dgvTicketBox.Rows.Clear();
                    for (int i = 0; i < tickets.Count; i++)//מילוי הטבלה בערכים חוץ מהנציג הנוכחי
                    {

                        String[] row = new String[] { tickets[i].Id.ToString(), tickets[i].Username, tickets[i].Details, tickets[i].Representative, tickets[i].Date };
                        dgvTicketBox.Rows.Add(row);

                    }
                    dgvTicketBox.Refresh();
                    break;
            }


        }
        //omer 13.2
        private void btnHandleTicket_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = dgvTicketBox.CurrentRow.Cells["colrepresentative"];
            DataGridViewCell id = dgvTicketBox.CurrentRow.Cells["colId"];
            String value = cell.Value.ToString();
            if (value == "")
            {

                Ticket ticket = tickets.Find(x => x.Id == Int32.Parse(id.Value.ToString()));
                tech.handleTicket(StringChecks.doubleApostrophy(tech.Username), ticket);
                cell.Value = tech.Username;
            }
            dgvTicketBox.Refresh();
        }
        //omer 13.2
        private void btnFinishTicket_Click(object sender, EventArgs e)
        {

            DataGridViewCell cell = dgvTicketBox.CurrentRow.Cells["colrepresentative"];
            DataGridViewCell id = dgvTicketBox.CurrentRow.Cells["colId"];
            String value = cell.Value.ToString();
            if (value != "" && value == tech.Username)
            {

                Ticket ticket = tickets.Find(x => x.Id == Int32.Parse(id.Value.ToString()));
                dgvTicketBox.Rows.Remove(dgvTicketBox.CurrentRow);
                tech.finishTicket(StringChecks.doubleApostrophy(tech.Username), ticket);


            }
            dgvTicketBox.Refresh();
        }

    }

}

