namespace GUI
{
    partial class FormUserPermissions
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
            this.TreePermissions = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // TreePermissions
            // 
            this.TreePermissions.Location = new System.Drawing.Point(12, 12);
            this.TreePermissions.Name = "TreePermissions";
            this.TreePermissions.Size = new System.Drawing.Size(945, 580);
            this.TreePermissions.TabIndex = 0;
            // 
            // FormUserPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(969, 604);
            this.Controls.Add(this.TreePermissions);
            this.Name = "FormUserPermissions";
            this.Text = "FormUserPermissions";
            this.Load += new System.EventHandler(this.FormUserPermissions_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TreePermissions;
    }
}