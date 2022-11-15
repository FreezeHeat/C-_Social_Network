namespace SocialNetwork
{
    partial class formAdmin
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
            this.panManage = new System.Windows.Forms.Panel();
            this.dgvManage = new System.Windows.Forms.DataGridView();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveAccount = new System.Windows.Forms.Button();
            this.btnDisableAccount = new System.Windows.Forms.Button();
            this.btnAddAdmin = new System.Windows.Forms.Button();
            this.btnAddTech = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.labManage = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManage)).BeginInit();
            this.SuspendLayout();
            // 
            // panManage
            // 
            this.panManage.Controls.Add(this.button1);
            this.panManage.Controls.Add(this.dgvManage);
            this.panManage.Controls.Add(this.btnRemoveAccount);
            this.panManage.Controls.Add(this.btnDisableAccount);
            this.panManage.Controls.Add(this.btnAddAdmin);
            this.panManage.Controls.Add(this.btnAddTech);
            this.panManage.Controls.Add(this.btnAddUser);
            this.panManage.Controls.Add(this.labManage);
            this.panManage.Location = new System.Drawing.Point(0, 0);
            this.panManage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panManage.Name = "panManage";
            this.panManage.Size = new System.Drawing.Size(375, 432);
            this.panManage.TabIndex = 1;
            this.panManage.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // dgvManage
            // 
            this.dgvManage.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.LastName,
            this.UserName});
            this.dgvManage.Location = new System.Drawing.Point(3, 38);
            this.dgvManage.Margin = new System.Windows.Forms.Padding(4);
            this.dgvManage.Name = "dgvManage";
            this.dgvManage.Size = new System.Drawing.Size(368, 292);
            this.dgvManage.TabIndex = 6;
            this.dgvManage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManage_CellContentClick);
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // btnRemoveAccount
            // 
            this.btnRemoveAccount.Location = new System.Drawing.Point(0, 388);
            this.btnRemoveAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveAccount.Name = "btnRemoveAccount";
            this.btnRemoveAccount.Size = new System.Drawing.Size(123, 41);
            this.btnRemoveAccount.TabIndex = 5;
            this.btnRemoveAccount.Text = "Remove Account";
            this.btnRemoveAccount.UseVisualStyleBackColor = true;
            this.btnRemoveAccount.Click += new System.EventHandler(this.btnRemoveAccount_Click);
            // 
            // btnDisableAccount
            // 
            this.btnDisableAccount.Location = new System.Drawing.Point(247, 390);
            this.btnDisableAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDisableAccount.Name = "btnDisableAccount";
            this.btnDisableAccount.Size = new System.Drawing.Size(125, 41);
            this.btnDisableAccount.TabIndex = 4;
            this.btnDisableAccount.Text = "Disable Account";
            this.btnDisableAccount.UseVisualStyleBackColor = true;
            this.btnDisableAccount.Click += new System.EventHandler(this.btnDisableAccount_Click);
            // 
            // btnAddAdmin
            // 
            this.btnAddAdmin.Location = new System.Drawing.Point(3, 336);
            this.btnAddAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddAdmin.Name = "btnAddAdmin";
            this.btnAddAdmin.Size = new System.Drawing.Size(120, 50);
            this.btnAddAdmin.TabIndex = 3;
            this.btnAddAdmin.Text = "Add Admin";
            this.btnAddAdmin.UseVisualStyleBackColor = true;
            this.btnAddAdmin.Click += new System.EventHandler(this.btnAddAdmin_Click);
            // 
            // btnAddTech
            // 
            this.btnAddTech.Location = new System.Drawing.Point(128, 336);
            this.btnAddTech.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddTech.Name = "btnAddTech";
            this.btnAddTech.Size = new System.Drawing.Size(113, 48);
            this.btnAddTech.TabIndex = 2;
            this.btnAddTech.Text = "Add Support Technician";
            this.btnAddTech.UseVisualStyleBackColor = true;
            this.btnAddTech.Click += new System.EventHandler(this.btnAddTech_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(247, 336);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(125, 50);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // labManage
            // 
            this.labManage.AutoSize = true;
            this.labManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labManage.Location = new System.Drawing.Point(121, 2);
            this.labManage.Name = "labManage";
            this.labManage.Size = new System.Drawing.Size(111, 31);
            this.labManage.TabIndex = 0;
            this.labManage.Text = "Manage";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 44);
            this.button1.TabIndex = 7;
            this.button1.Text = "Renable Account";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // formAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 448);
            this.Controls.Add(this.panManage);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "formAdmin";
            this.Text = "Admin Menu";
            this.Load += new System.EventHandler(this.formAdmin_Load);
            this.panManage.ResumeLayout(false);
            this.panManage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panManage;
        private System.Windows.Forms.Label labManage;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnAddAdmin;
        private System.Windows.Forms.Button btnAddTech;
        private System.Windows.Forms.Button btnDisableAccount;
        private System.Windows.Forms.Button btnRemoveAccount;
        private System.Windows.Forms.DataGridView dgvManage;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.Button button1;
    }
}