namespace FileBrowser.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.ListViewDirectories = new System.Windows.Forms.ListView();
            this.ListViewExtensions = new System.Windows.Forms.ListView();
            this.GroupBoxDirectories = new System.Windows.Forms.GroupBox();
            this.ButtonAddDirectory = new System.Windows.Forms.Button();
            this.GroupBoxExtensions = new System.Windows.Forms.GroupBox();
            this.PanelAddExtension = new System.Windows.Forms.Panel();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSubmit = new System.Windows.Forms.Button();
            this.TextBoxExtensionInput = new System.Windows.Forms.TextBox();
            this.ButtonAddExtension = new System.Windows.Forms.Button();
            this.PanelAdd = new System.Windows.Forms.Panel();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.ComboBoxColorTheme = new System.Windows.Forms.ComboBox();
            this.LabelColorTheme = new System.Windows.Forms.Label();
            this.GroupBoxSettings = new System.Windows.Forms.GroupBox();
            this.LabelLanguage = new System.Windows.Forms.Label();
            this.ComboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.CheckBoxExpand = new System.Windows.Forms.CheckBox();
            this.GroupBoxDirectories.SuspendLayout();
            this.GroupBoxExtensions.SuspendLayout();
            this.PanelAddExtension.SuspendLayout();
            this.PanelAdd.SuspendLayout();
            this.GroupBoxSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListViewDirectories
            // 
            this.ListViewDirectories.Location = new System.Drawing.Point(6, 49);
            this.ListViewDirectories.MultiSelect = false;
            this.ListViewDirectories.Name = "ListViewDirectories";
            this.ListViewDirectories.Size = new System.Drawing.Size(313, 147);
            this.ListViewDirectories.TabIndex = 0;
            this.ListViewDirectories.UseCompatibleStateImageBehavior = false;
            this.ListViewDirectories.View = System.Windows.Forms.View.List;
            this.ListViewDirectories.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewDirectories_MouseClick);
            // 
            // ListViewExtensions
            // 
            this.ListViewExtensions.Location = new System.Drawing.Point(6, 49);
            this.ListViewExtensions.MultiSelect = false;
            this.ListViewExtensions.Name = "ListViewExtensions";
            this.ListViewExtensions.Size = new System.Drawing.Size(310, 147);
            this.ListViewExtensions.TabIndex = 1;
            this.ListViewExtensions.UseCompatibleStateImageBehavior = false;
            this.ListViewExtensions.View = System.Windows.Forms.View.List;
            this.ListViewExtensions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewExtensions_MouseClick);
            // 
            // GroupBoxDirectories
            // 
            this.GroupBoxDirectories.Controls.Add(this.ButtonAddDirectory);
            this.GroupBoxDirectories.Controls.Add(this.ListViewDirectories);
            this.GroupBoxDirectories.Location = new System.Drawing.Point(3, 3);
            this.GroupBoxDirectories.Margin = new System.Windows.Forms.Padding(0);
            this.GroupBoxDirectories.Name = "GroupBoxDirectories";
            this.GroupBoxDirectories.Padding = new System.Windows.Forms.Padding(0);
            this.GroupBoxDirectories.Size = new System.Drawing.Size(325, 202);
            this.GroupBoxDirectories.TabIndex = 2;
            this.GroupBoxDirectories.TabStop = false;
            this.GroupBoxDirectories.Text = "Directories";
            // 
            // ButtonAddDirectory
            // 
            this.ButtonAddDirectory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonAddDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAddDirectory.Location = new System.Drawing.Point(6, 20);
            this.ButtonAddDirectory.Name = "ButtonAddDirectory";
            this.ButtonAddDirectory.Size = new System.Drawing.Size(313, 23);
            this.ButtonAddDirectory.TabIndex = 1;
            this.ButtonAddDirectory.Text = "Add Directory";
            this.ButtonAddDirectory.UseVisualStyleBackColor = false;
            this.ButtonAddDirectory.Click += new System.EventHandler(this.ButtonAddDirectory_Click);
            // 
            // GroupBoxExtensions
            // 
            this.GroupBoxExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxExtensions.Controls.Add(this.PanelAddExtension);
            this.GroupBoxExtensions.Controls.Add(this.ButtonAddExtension);
            this.GroupBoxExtensions.Controls.Add(this.ListViewExtensions);
            this.GroupBoxExtensions.Location = new System.Drawing.Point(339, 3);
            this.GroupBoxExtensions.Margin = new System.Windows.Forms.Padding(0);
            this.GroupBoxExtensions.Name = "GroupBoxExtensions";
            this.GroupBoxExtensions.Padding = new System.Windows.Forms.Padding(0);
            this.GroupBoxExtensions.Size = new System.Drawing.Size(322, 202);
            this.GroupBoxExtensions.TabIndex = 3;
            this.GroupBoxExtensions.TabStop = false;
            this.GroupBoxExtensions.Text = "Extensions";
            // 
            // PanelAddExtension
            // 
            this.PanelAddExtension.Controls.Add(this.ButtonCancel);
            this.PanelAddExtension.Controls.Add(this.ButtonSubmit);
            this.PanelAddExtension.Controls.Add(this.TextBoxExtensionInput);
            this.PanelAddExtension.Location = new System.Drawing.Point(6, 16);
            this.PanelAddExtension.Name = "PanelAddExtension";
            this.PanelAddExtension.Size = new System.Drawing.Size(310, 27);
            this.PanelAddExtension.TabIndex = 4;
            this.PanelAddExtension.Visible = false;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonCancel.Location = new System.Drawing.Point(235, 3);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 21);
            this.ButtonCancel.TabIndex = 5;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = false;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSubmit
            // 
            this.ButtonSubmit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonSubmit.Location = new System.Drawing.Point(154, 3);
            this.ButtonSubmit.Name = "ButtonSubmit";
            this.ButtonSubmit.Size = new System.Drawing.Size(75, 21);
            this.ButtonSubmit.TabIndex = 4;
            this.ButtonSubmit.Text = "Submit";
            this.ButtonSubmit.UseVisualStyleBackColor = false;
            this.ButtonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // TextBoxExtensionInput
            // 
            this.TextBoxExtensionInput.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TextBoxExtensionInput.Location = new System.Drawing.Point(0, 3);
            this.TextBoxExtensionInput.Name = "TextBoxExtensionInput";
            this.TextBoxExtensionInput.Size = new System.Drawing.Size(148, 20);
            this.TextBoxExtensionInput.TabIndex = 3;
            this.TextBoxExtensionInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxExtensionInput_KeyDown);
            // 
            // ButtonAddExtension
            // 
            this.ButtonAddExtension.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonAddExtension.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonAddExtension.Location = new System.Drawing.Point(6, 20);
            this.ButtonAddExtension.Name = "ButtonAddExtension";
            this.ButtonAddExtension.Size = new System.Drawing.Size(310, 23);
            this.ButtonAddExtension.TabIndex = 2;
            this.ButtonAddExtension.Text = "Add Extension";
            this.ButtonAddExtension.UseVisualStyleBackColor = false;
            this.ButtonAddExtension.Click += new System.EventHandler(this.ButtonAddExtension_Click);
            // 
            // PanelAdd
            // 
            this.PanelAdd.AutoSize = true;
            this.PanelAdd.Controls.Add(this.GroupBoxDirectories);
            this.PanelAdd.Controls.Add(this.GroupBoxExtensions);
            this.PanelAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelAdd.Location = new System.Drawing.Point(10, 10);
            this.PanelAdd.Margin = new System.Windows.Forms.Padding(0);
            this.PanelAdd.Name = "PanelAdd";
            this.PanelAdd.Size = new System.Drawing.Size(664, 205);
            this.PanelAdd.TabIndex = 4;
            // 
            // ComboBoxColorTheme
            // 
            this.ComboBoxColorTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxColorTheme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboBoxColorTheme.FormattingEnabled = true;
            this.ComboBoxColorTheme.Location = new System.Drawing.Point(115, 72);
            this.ComboBoxColorTheme.Name = "ComboBoxColorTheme";
            this.ComboBoxColorTheme.Size = new System.Drawing.Size(136, 21);
            this.ComboBoxColorTheme.TabIndex = 1;
            this.ComboBoxColorTheme.SelectedIndexChanged += new System.EventHandler(this.ComboBoxColorTheme_SelectedIndexChanged);
            // 
            // LabelColorTheme
            // 
            this.LabelColorTheme.AutoSize = true;
            this.LabelColorTheme.Location = new System.Drawing.Point(9, 75);
            this.LabelColorTheme.Name = "LabelColorTheme";
            this.LabelColorTheme.Size = new System.Drawing.Size(100, 13);
            this.LabelColorTheme.TabIndex = 0;
            this.LabelColorTheme.Text = "Select Color Theme";
            // 
            // GroupBoxSettings
            // 
            this.GroupBoxSettings.AutoSize = true;
            this.GroupBoxSettings.Controls.Add(this.ComboBoxColorTheme);
            this.GroupBoxSettings.Controls.Add(this.LabelColorTheme);
            this.GroupBoxSettings.Controls.Add(this.LabelLanguage);
            this.GroupBoxSettings.Controls.Add(this.ComboBoxLanguage);
            this.GroupBoxSettings.Controls.Add(this.CheckBoxExpand);
            this.GroupBoxSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBoxSettings.Location = new System.Drawing.Point(10, 215);
            this.GroupBoxSettings.Name = "GroupBoxSettings";
            this.GroupBoxSettings.Size = new System.Drawing.Size(664, 112);
            this.GroupBoxSettings.TabIndex = 6;
            this.GroupBoxSettings.TabStop = false;
            this.GroupBoxSettings.Text = "Settings";
            // 
            // LabelLanguage
            // 
            this.LabelLanguage.AutoSize = true;
            this.LabelLanguage.Location = new System.Drawing.Point(9, 46);
            this.LabelLanguage.Name = "LabelLanguage";
            this.LabelLanguage.Size = new System.Drawing.Size(88, 13);
            this.LabelLanguage.TabIndex = 2;
            this.LabelLanguage.Text = "Select Language";
            // 
            // ComboBoxLanguage
            // 
            this.ComboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboBoxLanguage.FormattingEnabled = true;
            this.ComboBoxLanguage.Location = new System.Drawing.Point(115, 43);
            this.ComboBoxLanguage.Name = "ComboBoxLanguage";
            this.ComboBoxLanguage.Size = new System.Drawing.Size(136, 21);
            this.ComboBoxLanguage.TabIndex = 1;
            this.ComboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLanguage_SelectedIndexChanged);
            // 
            // CheckBoxExpand
            // 
            this.CheckBoxExpand.AutoSize = true;
            this.CheckBoxExpand.Location = new System.Drawing.Point(12, 20);
            this.CheckBoxExpand.Name = "CheckBoxExpand";
            this.CheckBoxExpand.Size = new System.Drawing.Size(207, 17);
            this.CheckBoxExpand.TabIndex = 0;
            this.CheckBoxExpand.Text = "Expand directories on load and refresh";
            this.CheckBoxExpand.UseVisualStyleBackColor = true;
            this.CheckBoxExpand.CheckedChanged += new System.EventHandler(this.CheckBoxExpand_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 451);
            this.Controls.Add(this.GroupBoxSettings);
            this.Controls.Add(this.PanelAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Settings";
            this.GroupBoxDirectories.ResumeLayout(false);
            this.GroupBoxExtensions.ResumeLayout(false);
            this.PanelAddExtension.ResumeLayout(false);
            this.PanelAddExtension.PerformLayout();
            this.PanelAdd.ResumeLayout(false);
            this.GroupBoxSettings.ResumeLayout(false);
            this.GroupBoxSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListViewDirectories;
        private System.Windows.Forms.ListView ListViewExtensions;
        private System.Windows.Forms.GroupBox GroupBoxDirectories;
        private System.Windows.Forms.GroupBox GroupBoxExtensions;
        private System.Windows.Forms.Button ButtonAddDirectory;
        private System.Windows.Forms.Button ButtonAddExtension;
        private System.Windows.Forms.TextBox TextBoxExtensionInput;
        private System.Windows.Forms.Panel PanelAddExtension;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSubmit;
        private System.Windows.Forms.Panel PanelAdd;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.GroupBox GroupBoxSettings;
        private System.Windows.Forms.CheckBox CheckBoxExpand;
        private System.Windows.Forms.ComboBox ComboBoxLanguage;
        private System.Windows.Forms.Label LabelLanguage;
        private System.Windows.Forms.Label LabelColorTheme;
        private System.Windows.Forms.ComboBox ComboBoxColorTheme;
    }
}