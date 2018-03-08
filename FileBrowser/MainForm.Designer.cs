namespace FileBrowser
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
            this.PanelMainMenu = new System.Windows.Forms.Panel();
            this.PanelContent = new System.Windows.Forms.Panel();
            this.FlowLayoutPanelExtensions = new System.Windows.Forms.FlowLayoutPanel();
            this.FlowLayoutPanelMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelSearch = new System.Windows.Forms.Panel();
            this.LabelSearch = new System.Windows.Forms.Label();
            this.TextBoxSearch = new System.Windows.Forms.TextBox();
            this.MenuButtonCollapseAll = new FileBrowser.UI.MenuButton(this.components);
            this.MenuButtonShowAll = new FileBrowser.UI.MenuButton(this.components);
            this.ButtonClearSearch = new FileBrowser.UI.MenuButton(this.components);
            this.MenuButtonAbout = new FileBrowser.UI.MenuButton(this.components);
            this.MenuButtonGuide = new FileBrowser.UI.MenuButton(this.components);
            this.MenuButtonSettings = new FileBrowser.UI.MenuButton(this.components);
            this.MenuButtonRefresh = new FileBrowser.UI.MenuButton(this.components);
            this.PanelMainMenu.SuspendLayout();
            this.PanelContent.SuspendLayout();
            this.FlowLayoutPanelMenu.SuspendLayout();
            this.PanelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMainMenu
            // 
            this.PanelMainMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PanelMainMenu.Controls.Add(this.MenuButtonAbout);
            this.PanelMainMenu.Controls.Add(this.MenuButtonGuide);
            this.PanelMainMenu.Controls.Add(this.MenuButtonSettings);
            this.PanelMainMenu.Controls.Add(this.MenuButtonRefresh);
            this.PanelMainMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelMainMenu.Font = new System.Drawing.Font("Cambria", 12.25F);
            this.PanelMainMenu.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PanelMainMenu.Location = new System.Drawing.Point(0, 0);
            this.PanelMainMenu.Margin = new System.Windows.Forms.Padding(0);
            this.PanelMainMenu.Name = "PanelMainMenu";
            this.PanelMainMenu.Size = new System.Drawing.Size(141, 561);
            this.PanelMainMenu.TabIndex = 0;
            // 
            // PanelContent
            // 
            this.PanelContent.Controls.Add(this.FlowLayoutPanelExtensions);
            this.PanelContent.Controls.Add(this.FlowLayoutPanelMenu);
            this.PanelContent.Controls.Add(this.PanelSearch);
            this.PanelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelContent.Location = new System.Drawing.Point(141, 0);
            this.PanelContent.Margin = new System.Windows.Forms.Padding(0);
            this.PanelContent.Name = "PanelContent";
            this.PanelContent.Size = new System.Drawing.Size(468, 561);
            this.PanelContent.TabIndex = 2;
            // 
            // FlowLayoutPanelExtensions
            // 
            this.FlowLayoutPanelExtensions.Dock = System.Windows.Forms.DockStyle.Top;
            this.FlowLayoutPanelExtensions.Location = new System.Drawing.Point(0, 64);
            this.FlowLayoutPanelExtensions.Name = "FlowLayoutPanelExtensions";
            this.FlowLayoutPanelExtensions.Size = new System.Drawing.Size(468, 24);
            this.FlowLayoutPanelExtensions.TabIndex = 5;
            // 
            // FlowLayoutPanelMenu
            // 
            this.FlowLayoutPanelMenu.Controls.Add(this.MenuButtonCollapseAll);
            this.FlowLayoutPanelMenu.Controls.Add(this.MenuButtonShowAll);
            this.FlowLayoutPanelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.FlowLayoutPanelMenu.Location = new System.Drawing.Point(0, 40);
            this.FlowLayoutPanelMenu.Name = "FlowLayoutPanelMenu";
            this.FlowLayoutPanelMenu.Size = new System.Drawing.Size(468, 24);
            this.FlowLayoutPanelMenu.TabIndex = 4;
            // 
            // PanelSearch
            // 
            this.PanelSearch.Controls.Add(this.ButtonClearSearch);
            this.PanelSearch.Controls.Add(this.LabelSearch);
            this.PanelSearch.Controls.Add(this.TextBoxSearch);
            this.PanelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelSearch.Location = new System.Drawing.Point(0, 0);
            this.PanelSearch.Margin = new System.Windows.Forms.Padding(0);
            this.PanelSearch.Name = "PanelSearch";
            this.PanelSearch.Size = new System.Drawing.Size(468, 40);
            this.PanelSearch.TabIndex = 3;
            // 
            // LabelSearch
            // 
            this.LabelSearch.AutoSize = true;
            this.LabelSearch.Location = new System.Drawing.Point(6, 15);
            this.LabelSearch.Name = "LabelSearch";
            this.LabelSearch.Size = new System.Drawing.Size(47, 13);
            this.LabelSearch.TabIndex = 3;
            this.LabelSearch.Text = "Search: ";
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.Location = new System.Drawing.Point(59, 12);
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(372, 20);
            this.TextBoxSearch.TabIndex = 2;
            this.TextBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            this.TextBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSearch_KeyDown);
            // 
            // MenuButtonCollapseAll
            // 
            this.MenuButtonCollapseAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuButtonCollapseAll.FlatAppearance.BorderSize = 0;
            this.MenuButtonCollapseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButtonCollapseAll.Location = new System.Drawing.Point(0, 0);
            this.MenuButtonCollapseAll.Margin = new System.Windows.Forms.Padding(0);
            this.MenuButtonCollapseAll.Name = "MenuButtonCollapseAll";
            this.MenuButtonCollapseAll.Size = new System.Drawing.Size(75, 26);
            this.MenuButtonCollapseAll.TabIndex = 2;
            this.MenuButtonCollapseAll.Text = "Collapse All";
            this.MenuButtonCollapseAll.UseVisualStyleBackColor = true;
            this.MenuButtonCollapseAll.Click += new System.EventHandler(this.MenuButtonCollapseAll_Click);
            // 
            // MenuButtonShowAll
            // 
            this.MenuButtonShowAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuButtonShowAll.FlatAppearance.BorderSize = 0;
            this.MenuButtonShowAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButtonShowAll.Location = new System.Drawing.Point(75, 0);
            this.MenuButtonShowAll.Margin = new System.Windows.Forms.Padding(0);
            this.MenuButtonShowAll.Name = "MenuButtonShowAll";
            this.MenuButtonShowAll.Size = new System.Drawing.Size(75, 26);
            this.MenuButtonShowAll.TabIndex = 3;
            this.MenuButtonShowAll.Text = "Show All";
            this.MenuButtonShowAll.UseVisualStyleBackColor = true;
            this.MenuButtonShowAll.Click += new System.EventHandler(this.MenuButtonShowAll_Click);
            // 
            // ButtonClearSearch
            // 
            this.ButtonClearSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ButtonClearSearch.FlatAppearance.BorderSize = 0;
            this.ButtonClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonClearSearch.Location = new System.Drawing.Point(436, 12);
            this.ButtonClearSearch.Name = "ButtonClearSearch";
            this.ButtonClearSearch.Size = new System.Drawing.Size(20, 20);
            this.ButtonClearSearch.TabIndex = 4;
            this.ButtonClearSearch.Text = "X";
            this.ButtonClearSearch.UseVisualStyleBackColor = true;
            this.ButtonClearSearch.Click += new System.EventHandler(this.ButtonClearSearch_Click);
            // 
            // MenuButtonAbout
            // 
            this.MenuButtonAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuButtonAbout.FlatAppearance.BorderSize = 0;
            this.MenuButtonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButtonAbout.Location = new System.Drawing.Point(0, 129);
            this.MenuButtonAbout.Name = "MenuButtonAbout";
            this.MenuButtonAbout.Size = new System.Drawing.Size(141, 43);
            this.MenuButtonAbout.TabIndex = 7;
            this.MenuButtonAbout.Text = "About";
            this.MenuButtonAbout.UseVisualStyleBackColor = true;
            this.MenuButtonAbout.Click += new System.EventHandler(this.MenuButtonAbout_Click);
            // 
            // MenuButtonGuide
            // 
            this.MenuButtonGuide.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuButtonGuide.FlatAppearance.BorderSize = 0;
            this.MenuButtonGuide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButtonGuide.Location = new System.Drawing.Point(0, 86);
            this.MenuButtonGuide.Name = "MenuButtonGuide";
            this.MenuButtonGuide.Size = new System.Drawing.Size(141, 43);
            this.MenuButtonGuide.TabIndex = 6;
            this.MenuButtonGuide.Text = "Help";
            this.MenuButtonGuide.UseVisualStyleBackColor = true;
            this.MenuButtonGuide.Click += new System.EventHandler(this.MenuButtonGuide_Click);
            // 
            // MenuButtonSettings
            // 
            this.MenuButtonSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuButtonSettings.FlatAppearance.BorderSize = 0;
            this.MenuButtonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MenuButtonSettings.Location = new System.Drawing.Point(0, 43);
            this.MenuButtonSettings.Name = "MenuButtonSettings";
            this.MenuButtonSettings.Size = new System.Drawing.Size(141, 43);
            this.MenuButtonSettings.TabIndex = 5;
            this.MenuButtonSettings.Text = "Settings";
            this.MenuButtonSettings.UseVisualStyleBackColor = true;
            this.MenuButtonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(609, 561);
            this.Controls.Add(this.PanelContent);
            this.Controls.Add(this.PanelMainMenu);
            this.MaximumSize = new System.Drawing.Size(625, 600);
            this.MinimumSize = new System.Drawing.Size(625, 600);
            this.Name = "MainForm";
            this.PanelMainMenu.ResumeLayout(false);
            this.PanelContent.ResumeLayout(false);
            this.FlowLayoutPanelMenu.ResumeLayout(false);
            this.PanelSearch.ResumeLayout(false);
            this.PanelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMainMenu;
        private UI.MenuButton MenuButtonRefresh;
        private UI.MenuButton MenuButtonSettings;
        private System.Windows.Forms.Panel PanelContent;
        private System.Windows.Forms.TextBox TextBoxSearch;
        private System.Windows.Forms.Panel PanelSearch;
        private UI.MenuButton MenuButtonGuide;
        private System.Windows.Forms.Label LabelSearch;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelMenu;
        private UI.MenuButton MenuButtonCollapseAll;
        private UI.MenuButton MenuButtonShowAll;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanelExtensions;
        private UI.MenuButton MenuButtonAbout;
        private UI.MenuButton ButtonClearSearch;
    }
}