﻿namespace FileBrowser.UI
{
    partial class MenuButton
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
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button.BackColor = System.Drawing.Color.Transparent;
            this.button.Location = new System.Drawing.Point(0, 0);
            this.button.Name = "button1";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 0;
            this.button.UseVisualStyleBackColor = false;
            // 
            // MenuButton
            // 
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Size = new System.Drawing.Size(75, 43);
            this.Text = "MenuButton";
            this.MouseEnter += new System.EventHandler(this.MenuButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MenuButton_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button;
    }
}
