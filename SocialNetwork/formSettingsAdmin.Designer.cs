namespace SocialNetwork
{
    partial class formSettingsAdmin
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
            this.btnCustomizeWindow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCustomizeWindow
            // 
            this.btnCustomizeWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomizeWindow.Location = new System.Drawing.Point(124, 93);
            this.btnCustomizeWindow.Name = "btnCustomizeWindow";
            this.btnCustomizeWindow.Size = new System.Drawing.Size(353, 48);
            this.btnCustomizeWindow.TabIndex = 2;
            this.btnCustomizeWindow.Text = "Customize Window";
            this.btnCustomizeWindow.UseVisualStyleBackColor = true;
            this.btnCustomizeWindow.Click += new System.EventHandler(this.btnCustomizeWindow_Click_1);
            // 
            // formSettingsAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 350);
            this.Controls.Add(this.btnCustomizeWindow);
            this.Name = "formSettingsAdmin";
            this.Text = "formSettingsAdmin";
            this.Controls.SetChildIndex(this.btnChangeDetails, 0);
            this.Controls.SetChildIndex(this.btnCustomizeWindow, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCustomizeWindow;
    }
}