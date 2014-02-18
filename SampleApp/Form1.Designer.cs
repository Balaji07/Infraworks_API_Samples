namespace SampleApp
{
    partial class Form1
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
            this.cbServices = new System.Windows.Forms.ComboBox();
            this.cbModels = new System.Windows.Forms.ComboBox();
            this.cbModelClasses = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbServices
            // 
            this.cbServices.FormattingEnabled = true;
            this.cbServices.Location = new System.Drawing.Point(12, 22);
            this.cbServices.Name = "cbServices";
            this.cbServices.Size = new System.Drawing.Size(283, 23);
            this.cbServices.TabIndex = 0;
            // 
            // cbModels
            // 
            this.cbModels.FormattingEnabled = true;
            this.cbModels.Location = new System.Drawing.Point(12, 51);
            this.cbModels.Name = "cbModels";
            this.cbModels.Size = new System.Drawing.Size(283, 23);
            this.cbModels.TabIndex = 1;
            this.cbModels.SelectedIndexChanged += new System.EventHandler(this.cbModels_SelectedIndexChanged);
            // 
            // cbModelClasses
            // 
            this.cbModelClasses.FormattingEnabled = true;
            this.cbModelClasses.Location = new System.Drawing.Point(12, 79);
            this.cbModelClasses.Name = "cbModelClasses";
            this.cbModelClasses.Size = new System.Drawing.Size(283, 23);
            this.cbModelClasses.TabIndex = 2;
            this.cbModelClasses.SelectedIndexChanged += new System.EventHandler(this.cbModelClasses_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 352);
            this.Controls.Add(this.cbModelClasses);
            this.Controls.Add(this.cbModels);
            this.Controls.Add(this.cbServices);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbServices;
        private System.Windows.Forms.ComboBox cbModels;
        private System.Windows.Forms.ComboBox cbModelClasses;

    }
}

