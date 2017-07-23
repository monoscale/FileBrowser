namespace FileBrowser.FormControls
{
    partial class HelpLabel
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label.CausesValidation = false;
            this.label.Dock = System.Windows.Forms.DockStyle.Right;
            this.label.Location = new System.Drawing.Point(0, 0);
            this.label.MaximumSize = new System.Drawing.Size(350, 0);
            this.label.Name = "label1";
            this.label.Size = new System.Drawing.Size(100, 0);
            this.label.TabIndex = 0;
            this.label.Text = "label1";
            // 
            // HelpLabel
            // 
            this.Padding = new System.Windows.Forms.Padding(5);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label;
    }
}
