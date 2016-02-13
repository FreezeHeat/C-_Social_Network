namespace SocialNetwork
{
    partial class formAccount
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.txtRecipient = new System.Windows.Forms.TextBox();
            this.labInbox = new System.Windows.Forms.Label();
            this.gridInbox = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Timestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInbox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDisconnect);
            this.panel1.Controls.Add(this.btnSettings);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.txtSend);
            this.panel1.Controls.Add(this.txtRecipient);
            this.panel1.Controls.Add(this.labInbox);
            this.panel1.Controls.Add(this.gridInbox);
            this.panel1.Location = new System.Drawing.Point(285, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 351);
            this.panel1.TabIndex = 0;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(174, 320);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(151, 31);
            this.btnDisconnect.TabIndex = 6;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(0, 320);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(170, 31);
            this.btnSettings.TabIndex = 5;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1, 293);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(324, 28);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSend.Location = new System.Drawing.Point(0, 234);
            this.txtSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(325, 61);
            this.txtSend.TabIndex = 3;
            this.txtSend.TextChanged += new System.EventHandler(this.txtSend_TextChanged);
            // 
            // txtRecipient
            // 
            this.txtRecipient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtRecipient.Location = new System.Drawing.Point(0, 213);
            this.txtRecipient.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(325, 23);
            this.txtRecipient.TabIndex = 2;
            this.txtRecipient.Text = "Recipient\'s Username";
            this.txtRecipient.TextChanged += new System.EventHandler(this.txtRecipient_TextChanged);
            // 
            // labInbox
            // 
            this.labInbox.AutoSize = true;
            this.labInbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labInbox.Location = new System.Drawing.Point(133, 2);
            this.labInbox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labInbox.Name = "labInbox";
            this.labInbox.Size = new System.Drawing.Size(81, 26);
            this.labInbox.TabIndex = 1;
            this.labInbox.Text = "INBOX";
            this.labInbox.Click += new System.EventHandler(this.labInbox_Click);
            // 
            // gridInbox
            // 
            this.gridInbox.AllowUserToAddRows = false;
            this.gridInbox.BackgroundColor = System.Drawing.Color.White;
            this.gridInbox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridInbox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.From,
            this.Message,
            this.Timestamp});
            this.gridInbox.GridColor = System.Drawing.Color.DeepSkyBlue;
            this.gridInbox.Location = new System.Drawing.Point(0, 29);
            this.gridInbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridInbox.Name = "gridInbox";
            this.gridInbox.ReadOnly = true;
            this.gridInbox.RowTemplate.Height = 24;
            this.gridInbox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInbox.Size = new System.Drawing.Size(325, 182);
            this.gridInbox.TabIndex = 0;
            this.gridInbox.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInbox_CellContentClick);
            this.gridInbox.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInbox_CellContentDoubleClick);
            this.gridInbox.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridInbox_UserDeletedRow);
            this.gridInbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridInbox_KeyDown);
            this.gridInbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridInbox_KeyPress);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // From
            // 
            this.From.HeaderText = "From";
            this.From.Name = "From";
            this.From.ReadOnly = true;
            // 
            // Message
            // 
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            // 
            // Timestamp
            // 
            this.Timestamp.HeaderText = "Timestamp";
            this.Timestamp.Name = "Timestamp";
            this.Timestamp.ReadOnly = true;
            // 
            // formAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 350);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "formAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account Menu";
            this.Load += new System.EventHandler(this.formAccount_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.DataGridView gridInbox;
        protected System.Windows.Forms.Label labInbox;
        protected System.Windows.Forms.Button btnDisconnect;
        protected System.Windows.Forms.Button btnSettings;
        protected System.Windows.Forms.Button btnSend;
        protected System.Windows.Forms.TextBox txtSend;
        protected System.Windows.Forms.TextBox txtRecipient;
        protected System.Windows.Forms.DataGridViewTextBoxColumn ID;
        protected System.Windows.Forms.DataGridViewTextBoxColumn From;
        protected System.Windows.Forms.DataGridViewTextBoxColumn Message;
        protected System.Windows.Forms.DataGridViewTextBoxColumn Timestamp;
    }
}