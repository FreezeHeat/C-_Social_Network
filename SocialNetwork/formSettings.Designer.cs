namespace SocialNetwork
{
    partial class formSettings
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
            this.btnChangeDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChangeDetails
            // 
            this.btnChangeDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeDetails.Location = new System.Drawing.Point(124, 39);
            this.btnChangeDetails.Name = "btnChangeDetails";
            this.btnChangeDetails.Size = new System.Drawing.Size(353, 48);
            this.btnChangeDetails.TabIndex = 0;
            this.btnChangeDetails.Text = "Change Details";
            this.btnChangeDetails.UseVisualStyleBackColor = true;
            this.btnChangeDetails.Click += new System.EventHandler(this.btnChangeDetails_Click);
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 350);
            this.Controls.Add(this.btnChangeDetails);
            this.Name = "formSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.formSettings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnChangeDetails;
    }
}