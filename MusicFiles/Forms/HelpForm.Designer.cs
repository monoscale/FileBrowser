namespace MusicFiles.Forms
{
    partial class HelpForm
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
            this.components = new System.ComponentModel.Container();
            this.PanelContent = new System.Windows.Forms.Panel();
            this.helpLabel3 = new MusicFiles.FormControls.HelpLabel(this.components);
            this.helpLabel2 = new MusicFiles.FormControls.HelpLabel(this.components);
            this.helpLabel1 = new MusicFiles.FormControls.HelpLabel(this.components);
            this.helpLabel4 = new MusicFiles.FormControls.HelpLabel(this.components);
            this.PanelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelContent
            // 
            this.PanelContent.Controls.Add(this.helpLabel4);
            this.PanelContent.Controls.Add(this.helpLabel3);
            this.PanelContent.Controls.Add(this.helpLabel2);
            this.PanelContent.Controls.Add(this.helpLabel1);
            this.PanelContent.Location = new System.Drawing.Point(12, 12);
            this.PanelContent.Name = "PanelContent";
            this.PanelContent.Size = new System.Drawing.Size(339, 237);
            this.PanelContent.TabIndex = 3;
            // 
            // helpLabel3
            // 
            this.helpLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.helpLabel3.Location = new System.Drawing.Point(0, 60);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.Padding = new System.Windows.Forms.Padding(5);
            this.helpLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.helpLabel3.Size = new System.Drawing.Size(339, 38);
            this.helpLabel3.TabIndex = 5;
            this.helpLabel3.Text = "3. When done, exit the settings menu and click on \"Refresh\". This will generate a" +
    " list of all the files";
            // 
            // helpLabel2
            // 
            this.helpLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.helpLabel2.Location = new System.Drawing.Point(0, 37);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.Padding = new System.Windows.Forms.Padding(5);
            this.helpLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.helpLabel2.Size = new System.Drawing.Size(339, 23);
            this.helpLabel2.TabIndex = 4;
            this.helpLabel2.Text = "2. Add the extensions of the files you want to scan";
            // 
            // helpLabel1
            // 
            this.helpLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.helpLabel1.Location = new System.Drawing.Point(0, 0);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.Padding = new System.Windows.Forms.Padding(5);
            this.helpLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.helpLabel1.Size = new System.Drawing.Size(339, 37);
            this.helpLabel1.TabIndex = 3;
            this.helpLabel1.Text = "1. Go to settings and add the directories you want this program to scan";
            // 
            // helpLabel4
            // 
            this.helpLabel4.AutoSize = true;
            this.helpLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.helpLabel4.Location = new System.Drawing.Point(0, 98);
            this.helpLabel4.Name = "helpLabel4";
            this.helpLabel4.Padding = new System.Windows.Forms.Padding(5);
            this.helpLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.helpLabel4.Size = new System.Drawing.Size(274, 23);
            this.helpLabel4.TabIndex = 6;
            this.helpLabel4.Text = "4. On program startup, the list will automatically refresh.";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(363, 261);
            this.Controls.Add(this.PanelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpForm";
            this.Text = "Help";
            this.PanelContent.ResumeLayout(false);
            this.PanelContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelContent;
        private FormControls.HelpLabel helpLabel1;
        private FormControls.HelpLabel helpLabel3;
        private FormControls.HelpLabel helpLabel2;
        private FormControls.HelpLabel helpLabel4;
    }
}