using System.Windows.Forms;
namespace SocialNetwork
{
    partial class formManageUsers
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
            this.btnDisableAccount = new System.Windows.Forms.Button();
            this.btnReEnableAccount = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.ColUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnableDisable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDisableAccount
            // 
            this.btnDisableAccount.Location = new System.Drawing.Point(12, 12);
            this.btnDisableAccount.Name = "btnDisableAccount";
            this.btnDisableAccount.Size = new System.Drawing.Size(164, 23);
            this.btnDisableAccount.TabIndex = 0;
            this.btnDisableAccount.Text = "disableAccount";
            this.btnDisableAccount.UseVisualStyleBackColor = true;
            this.btnDisableAccount.Click += new System.EventHandler(this.btnDisableAccount_Click);
            // 
            // btnReEnableAccount
            // 
            this.btnReEnableAccount.Location = new System.Drawing.Point(13, 54);
            this.btnReEnableAccount.Name = "btnReEnableAccount";
            this.btnReEnableAccount.Size = new System.Drawing.Size(163, 23);
            this.btnReEnableAccount.TabIndex = 1;
            this.btnReEnableAccount.Text = "reEnableAccount";
            this.btnReEnableAccount.UseVisualStyleBackColor = true;
            this.btnReEnableAccount.Click += new System.EventHandler(this.btnReEnableAccount_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(12, 98);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(164, 23);
            this.btnResetPassword.TabIndex = 2;
            this.btnResetPassword.Text = "ResetPassword";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColUserName,
            this.colPassword,
            this.colEnableDisable});
            this.dgvUsers.Location = new System.Drawing.Point(284, 1);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(764, 355);
            this.dgvUsers.TabIndex = 3;
            this.dgvUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);
            this.dgvUsers.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsers_CellMouseClick);
            this.dgvUsers.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgv_RowPrePaint);
            // 
            // ColUserName
            // 
            this.ColUserName.HeaderText = "userName";
            this.ColUserName.Name = "ColUserName";
            this.ColUserName.ReadOnly = true;
            // 
            // colPassword
            // 
            this.colPassword.HeaderText = "Password";
            this.colPassword.Name = "colPassword";
            this.colPassword.ReadOnly = true;
            // 
            // colEnableDisable
            // 
            this.colEnableDisable.HeaderText = "enableDisable";
            this.colEnableDisable.Name = "colEnableDisable";
            this.colEnableDisable.ReadOnly = true;
            // 
            // formManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 358);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.btnReEnableAccount);
            this.Controls.Add(this.btnDisableAccount);
            this.Name = "formManageUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formManageUsers";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDisableAccount;
        private System.Windows.Forms.Button btnReEnableAccount;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.DataGridView dgvUsers;
        private DataGridViewTextBoxColumn ColUserName;
        private DataGridViewTextBoxColumn colPassword;
        private DataGridViewTextBoxColumn colEnableDisable;
    }
}