﻿namespace MusicFiles
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PanelMenu = new System.Windows.Forms.Panel();
            this.MenuButtonSettings = new MusicFiles.UI.MenuButton(this.components);
            this.LabelHorizontalLine = new System.Windows.Forms.Label();
            this.MenuButtonRefresh = new MusicFiles.UI.MenuButton(this.components);
            this.TreeViewDirectories = new System.Windows.Forms.TreeView();
            this.PanelContent = new System.Windows.Forms.Panel();
            this.PanelSearch = new System.Windows.Forms.Panel();
            this.LabelSearch = new System.Windows.Forms.Label();
            this.TextBoxSearch = new System.Windows.Forms.TextBox();
            this.PanelMenu.SuspendLayout();
            this.PanelContent.SuspendLayout();
            this.PanelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMenu
            // 
            this.PanelMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PanelMenu.Controls.Add(this.MenuButtonSettings);
            this.PanelMenu.Controls.Add(this.LabelHorizontalLine);
            this.PanelMenu.Controls.Add(this.MenuButtonRefresh);
            this.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMenu.Font = new System.Drawing.Font("Cambria", 12.25F);
            this.PanelMenu.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PanelMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.PanelMenu.Name = "PanelMenu";
            this.PanelMenu.Size = new System.Drawing.Size(141, 561);
            this.PanelMenu.TabIndex = 0;
            // 
            // MenuButtonSettings
            // 
            this.MenuButtonSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuButtonSettings.FlatAppearance.BorderSize = 0;
            this.MenuButtonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButtonSettings.Location = new System.Drawing.Point(0, 44);
            this.MenuButtonSettings.Name = "MenuButtonSettings";
            this.MenuButtonSettings.Size = new System.Drawing.Size(141, 43);
            this.MenuButtonSettings.TabIndex = 5;
            this.MenuButtonSettings.Text = "Settings";
            this.MenuButtonSettings.UseVisualStyleBackColor = true;
            this.MenuButtonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // LabelHorizontalLine
            // 
            this.LabelHorizontalLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LabelHorizontalLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelHorizontalLine.Location = new System.Drawing.Point(0, 43);
            this.LabelHorizontalLine.Margin = new System.Windows.Forms.Padding(0);
            this.LabelHorizontalLine.Name = "LabelHorizontalLine";
            this.LabelHorizontalLine.Size = new System.Drawing.Size(141, 1);
            this.LabelHorizontalLine.TabIndex = 3;
            // 
            // MenuButtonRefresh
            // 
            this.MenuButtonRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuButtonRefresh.FlatAppearance.BorderSize = 0;
            this.MenuButtonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButtonRefresh.Location = new System.Drawing.Point(0, 0);
            this.MenuButtonRefresh.Name = "MenuButtonRefresh";
            this.MenuButtonRefresh.Size = new System.Drawing.Size(141, 43);
            this.MenuButtonRefresh.TabIndex = 4;
            this.MenuButtonRefresh.Text = "Refresh";
            this.MenuButtonRefresh.UseVisualStyleBackColor = true;
            this.MenuButtonRefresh.Click += new System.EventHandler(this.MenuButtonRefresh_Click);
            // 
            // TreeViewDirectories
            // 
            this.TreeViewDirectories.BackColor = System.Drawing.Color.White;
            this.TreeViewDirectories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeViewDirectories.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TreeViewDirectories.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeViewDirectories.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TreeViewDirectories.Location = new System.Drawing.Point(0, 46);
            this.TreeViewDirectories.Margin = new System.Windows.Forms.Padding(0);
            this.TreeViewDirectories.Name = "TreeViewDirectories";
            this.TreeViewDirectories.ShowLines = false;
            this.TreeViewDirectories.ShowNodeToolTips = true;
            this.TreeViewDirectories.Size = new System.Drawing.Size(443, 515);
            this.TreeViewDirectories.TabIndex = 1;
            this.TreeViewDirectories.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewDirectories_NodeMouseClick);
            this.TreeViewDirectories.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewDirectories_NodeMouseDoubleClick);
            // 
            // PanelContent
            // 
            this.PanelContent.Controls.Add(this.PanelSearch);
            this.PanelContent.Controls.Add(this.TreeViewDirectories);
            this.PanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContent.Location = new System.Drawing.Point(141, 0);
            this.PanelContent.Margin = new System.Windows.Forms.Padding(0);
            this.PanelContent.Name = "PanelContent";
            this.PanelContent.Size = new System.Drawing.Size(443, 561);
            this.PanelContent.TabIndex = 2;
            // 
            // PanelSearch
            // 
            this.PanelSearch.Controls.Add(this.LabelSearch);
            this.PanelSearch.Controls.Add(this.TextBoxSearch);
            this.PanelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSearch.Location = new System.Drawing.Point(0, 0);
            this.PanelSearch.Margin = new System.Windows.Forms.Padding(0);
            this.PanelSearch.Name = "PanelSearch";
            this.PanelSearch.Size = new System.Drawing.Size(443, 44);
            this.PanelSearch.TabIndex = 3;
            // 
            // LabelSearch
            // 
            this.LabelSearch.AutoSize = true;
            this.LabelSearch.Location = new System.Drawing.Point(5, 16);
            this.LabelSearch.Name = "LabelSearch";
            this.LabelSearch.Size = new System.Drawing.Size(41, 13);
            this.LabelSearch.TabIndex = 3;
            this.LabelSearch.Text = "Search";
            this.LabelSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.Location = new System.Drawing.Point(61, 13);
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(262, 20);
            this.TextBoxSearch.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.PanelContent);
            this.Controls.Add(this.PanelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 39);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.PanelMenu.ResumeLayout(false);
            this.PanelContent.ResumeLayout(false);
            this.PanelSearch.ResumeLayout(false);
            this.PanelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMenu;
        private System.Windows.Forms.Label LabelHorizontalLine;
        private System.Windows.Forms.TreeView TreeViewDirectories;
        private UI.MenuButton MenuButtonRefresh;
        private UI.MenuButton MenuButtonSettings;
        private System.Windows.Forms.Panel PanelContent;
        private System.Windows.Forms.TextBox TextBoxSearch;
        private System.Windows.Forms.Panel PanelSearch;
        private System.Windows.Forms.Label LabelSearch;
    }
}