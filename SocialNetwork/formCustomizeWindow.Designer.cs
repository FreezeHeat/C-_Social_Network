namespace SocialNetwork
{
    partial class formCustomizeWindow
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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.btnTextColor = new System.Windows.Forms.Button();
            this.btnBackgroundColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTextColor
            // 
            this.btnTextColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTextColor.Location = new System.Drawing.Point(131, 77);
            this.btnTextColor.Name = "btnTextColor";
            this.btnTextColor.Size = new System.Drawing.Size(346, 71);
            this.btnTextColor.TabIndex = 0;
            this.btnTextColor.Text = "Pick Text Color";
            this.btnTextColor.UseVisualStyleBackColor = true;
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            // 
            // btnBackgroundColor
            // 
            this.btnBackgroundColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackgroundColor.Location = new System.Drawing.Point(131, 170);
            this.btnBackgroundColor.Name = "btnBackgroundColor";
            this.btnBackgroundColor.Size = new System.Drawing.Size(346, 71);
            this.btnBackgroundColor.TabIndex = 1;
            this.btnBackgroundColor.Text = "Pick Background Color";
            this.btnBackgroundColor.UseVisualStyleBackColor = true;
            this.btnBackgroundColor.Click += new System.EventHandler(this.btnBackgroundColor_Click);
            // 
            // formCustomizeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 350);
            this.Controls.Add(this.btnBackgroundColor);
            this.Controls.Add(this.btnTextColor);
            this.Name = "formCustomizeWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customize";
            this.Load += new System.EventHandler(this.formCustomizeWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnTextColor;
        private System.Windows.Forms.Button btnBackgroundColor;
    }
}