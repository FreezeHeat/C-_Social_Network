namespace SocialNetwork
{
    partial class formTechSupport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTicketBox = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRepresentative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketComboBox = new System.Windows.Forms.ComboBox();
            this.btnHandleTicket = new System.Windows.Forms.Button();
            this.btnFinishTicket = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labTicketBox = new System.Windows.Forms.Label();
            this.btnManageUsers = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicketBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // txtSend
            // 
            this.txtSend.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.txtSend.Size = new System.Drawing.Size(432, 90);
            // 
            // txtRecipient
            // 
            this.txtRecipient.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // dgvTicketBox
            // 
            this.dgvTicketBox.BackgroundColor = System.Drawing.Color.White;
            this.dgvTicketBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTicketBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colUserName,
            this.coldetails,
            this.colRepresentative,
            this.colDate});
            this.dgvTicketBox.Location = new System.Drawing.Point(-1, 36);
            this.dgvTicketBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTicketBox.Name = "dgvTicketBox";
            this.dgvTicketBox.RowTemplate.Height = 24;
            this.dgvTicketBox.Size = new System.Drawing.Size(384, 224);
            this.dgvTicketBox.TabIndex = 1;
            this.dgvTicketBox.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Tickets_CellContentClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colUserName
            // 
            this.colUserName.HeaderText = "userName";
            this.colUserName.Name = "colUserName";
            this.colUserName.ReadOnly = true;
            // 
            // coldetails
            // 
            this.coldetails.HeaderText = "Details";
            this.coldetails.Name = "coldetails";
            this.coldetails.ReadOnly = true;
            // 
            // colRepresentative
            // 
            this.colRepresentative.HeaderText = "Representative";
            this.colRepresentative.Name = "colRepresentative";
            this.colRepresentative.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // ticketComboBox
            // 
            this.ticketComboBox.FormattingEnabled = true;
            this.ticketComboBox.Items.AddRange(new object[] {
            "Open",
            "My Tickets",
            "All Tickets"});
            this.ticketComboBox.Location = new System.Drawing.Point(248, 266);
            this.ticketComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ticketComboBox.Name = "ticketComboBox";
            this.ticketComboBox.Size = new System.Drawing.Size(127, 24);
            this.ticketComboBox.TabIndex = 2;
            this.ticketComboBox.SelectedIndexChanged += new System.EventHandler(this.ticketComboBox_SelectedIndexChanged);
            // 
            // btnHandleTicket
            // 
            this.btnHandleTicket.Location = new System.Drawing.Point(124, 268);
            this.btnHandleTicket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHandleTicket.Name = "btnHandleTicket";
            this.btnHandleTicket.Size = new System.Drawing.Size(120, 23);
            this.btnHandleTicket.TabIndex = 3;
            this.btnHandleTicket.Text = "HandleTicket";
            this.btnHandleTicket.UseVisualStyleBackColor = true;
            this.btnHandleTicket.Click += new System.EventHandler(this.btnHandleTicket_Click);
            // 
            // btnFinishTicket
            // 
            this.btnFinishTicket.Location = new System.Drawing.Point(1, 268);
            this.btnFinishTicket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFinishTicket.Name = "btnFinishTicket";
            this.btnFinishTicket.Size = new System.Drawing.Size(120, 23);
            this.btnFinishTicket.TabIndex = 4;
            this.btnFinishTicket.Text = "FinishTicket";
            this.btnFinishTicket.UseVisualStyleBackColor = true;
            this.btnFinishTicket.Click += new System.EventHandler(this.btnFinishTicket_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labTicketBox);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(384, 37);
            this.panel2.TabIndex = 9;
            // 
            // labTicketBox
            // 
            this.labTicketBox.AutoSize = true;
            this.labTicketBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labTicketBox.Location = new System.Drawing.Point(119, 0);
            this.labTicketBox.Name = "labTicketBox";
            this.labTicketBox.Size = new System.Drawing.Size(134, 31);
            this.labTicketBox.TabIndex = 0;
            this.labTicketBox.Text = "TicketBox";
            // 
            // btnManageUsers
            // 
            this.btnManageUsers.Location = new System.Drawing.Point(50, 355);
            this.btnManageUsers.Name = "btnManageUsers";
            this.btnManageUsers.Size = new System.Drawing.Size(140, 23);
            this.btnManageUsers.TabIndex = 10;
            this.btnManageUsers.Text = "manageUsers";
            this.btnManageUsers.UseVisualStyleBackColor = true;
            this.btnManageUsers.Click += new System.EventHandler(this.btnManageUsers_Click_1);
            // 
            // formTechSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 431);
            this.Controls.Add(this.btnManageUsers);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnFinishTicket);
            this.Controls.Add(this.btnHandleTicket);
            this.Controls.Add(this.ticketComboBox);
            this.Controls.Add(this.dgvTicketBox);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "formTechSupport";
            this.Text = "TechSupport Menu";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dgvTicketBox, 0);
            this.Controls.SetChildIndex(this.ticketComboBox, 0);
            this.Controls.SetChildIndex(this.btnHandleTicket, 0);
            this.Controls.SetChildIndex(this.btnFinishTicket, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.btnManageUsers, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTicketBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTicketBox;
        private System.Windows.Forms.ComboBox ticketComboBox;
        private System.Windows.Forms.Button btnHandleTicket;
        private System.Windows.Forms.Button btnFinishTicket;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labTicketBox;
        private System.Windows.Forms.Button btnManageUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepresentative;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
    }
}
