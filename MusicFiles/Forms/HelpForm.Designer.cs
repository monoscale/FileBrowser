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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.PanelContent = new System.Windows.Forms.Panel();
            this.HelpLabel4 = new MusicFiles.FormControls.HelpLabel(this.components);
            this.HelpLabel3 = new MusicFiles.FormControls.HelpLabel(this.components);
            this.HelpLabel2 = new MusicFiles.FormControls.HelpLabel(this.components);
            this.HelpLabel1 = new MusicFiles.FormControls.HelpLabel(this.components);
            this.PanelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelContent
            // 
            this.PanelContent.Controls.Add(this.HelpLabel4);
            this.PanelContent.Controls.Add(this.HelpLabel3);
            this.PanelContent.Controls.Add(this.HelpLabel2);
            this.PanelContent.Controls.Add(this.HelpLabel1);
            this.PanelContent.Location = new System.Drawing.Point(12, 12);
            this.PanelContent.Name = "PanelContent";
            this.PanelContent.Size = new System.Drawing.Size(339, 237);
            this.PanelContent.TabIndex = 3;
            // 
            // HelpLabel4
            // 
            this.HelpLabel4.AutoSize = true;
            this.HelpLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.HelpLabel4.Location = new System.Drawing.Point(0, 82);
            this.HelpLabel4.MaximumSize = new System.Drawing.Size(350, 0);
            this.HelpLabel4.Name = "HelpLabel4";
            this.HelpLabel4.Padding = new System.Windows.Forms.Padding(5);
            this.HelpLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HelpLabel4.Size = new System.Drawing.Size(274, 23);
            this.HelpLabel4.TabIndex = 6;
            this.HelpLabel4.Text = "4. On program startup, the list will automatically refresh.";
            // 
            // HelpLabel3
            // 
            this.HelpLabel3.AutoSize = true;
            this.HelpLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.HelpLabel3.Location = new System.Drawing.Point(0, 46);
            this.HelpLabel3.MaximumSize = new System.Drawing.Size(350, 0);
            this.HelpLabel3.Name = "HelpLabel3";
            this.HelpLabel3.Padding = new System.Windows.Forms.Padding(5);
            this.HelpLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HelpLabel3.Size = new System.Drawing.Size(350, 36);
            this.HelpLabel3.TabIndex = 5;
            this.HelpLabel3.Text = "3. When done, exit the settings menu and click on \"Refresh\". This will generate a" +
    " list of all the files";
            // 
            // HelpLabel2
            // 
            this.HelpLabel2.AutoSize = true;
            this.HelpLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.HelpLabel2.Location = new System.Drawing.Point(0, 23);
            this.HelpLabel2.MaximumSize = new System.Drawing.Size(350, 0);
            this.HelpLabel2.Name = "HelpLabel2";
            this.HelpLabel2.Padding = new System.Windows.Forms.Padding(5);
            this.HelpLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HelpLabel2.Size = new System.Drawing.Size(254, 23);
            this.HelpLabel2.TabIndex = 4;
            this.HelpLabel2.Text = "2. Add the extensions of the files you want to scan";
            // 
            // HelpLabel1
            // 
            this.HelpLabel1.AutoSize = true;
            this.HelpLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.HelpLabel1.Location = new System.Drawing.Point(0, 0);
            this.HelpLabel1.MaximumSize = new System.Drawing.Size(350, 0);
            this.HelpLabel1.Name = "HelpLabel1";
            this.HelpLabel1.Padding = new System.Windows.Forms.Padding(5);
            this.HelpLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.HelpLabel1.Size = new System.Drawing.Size(349, 23);
            this.HelpLabel1.TabIndex = 3;
            this.HelpLabel1.Text = "1. Go to settings and add the directories you want this program to scan";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(363, 261);
            this.Controls.Add(this.PanelContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private FormControls.HelpLabel HelpLabel1;
        private FormControls.HelpLabel HelpLabel3;
        private FormControls.HelpLabel HelpLabel2;
        private FormControls.HelpLabel HelpLabel4;
    }
}