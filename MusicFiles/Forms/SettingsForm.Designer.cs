namespace MusicFiles.Forms
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
            this.ButtonBackMenuColor = new System.Windows.Forms.Button();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.LabelBackMenuColor = new System.Windows.Forms.Label();
            this.TableLayoutPanelColors = new System.Windows.Forms.TableLayoutPanel();
            this.LabelBackTreeViewColor = new System.Windows.Forms.Label();
            this.ButtonBackTreeViewColor = new System.Windows.Forms.Button();
            this.LabelForeMenuColor = new System.Windows.Forms.Label();
            this.LabelForeTreeViewColor = new System.Windows.Forms.Label();
            this.ButtonForeMenuColor = new System.Windows.Forms.Button();
            this.ButtonForeTreeViewColor = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.GroupBoxColors = new System.Windows.Forms.GroupBox();
            this.GroupBoxSettings = new System.Windows.Forms.GroupBox();
            this.LabelLanguage = new System.Windows.Forms.Label();
            this.ComboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.CheckBoxExpand = new System.Windows.Forms.CheckBox();
            this.GroupBoxDirectories.SuspendLayout();
            this.GroupBoxExtensions.SuspendLayout();
            this.PanelAddExtension.SuspendLayout();
            this.PanelAdd.SuspendLayout();
            this.TableLayoutPanelColors.SuspendLayout();
            this.GroupBoxColors.SuspendLayout();
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
            this.GroupBoxDirectories.Name = "GroupBoxDirectories";
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
            this.GroupBoxExtensions.Name = "GroupBoxExtensions";
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
            this.PanelAdd.Controls.Add(this.GroupBoxDirectories);
            this.PanelAdd.Controls.Add(this.GroupBoxExtensions);
            this.PanelAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelAdd.Location = new System.Drawing.Point(10, 10);
            this.PanelAdd.Name = "PanelAdd";
            this.PanelAdd.Size = new System.Drawing.Size(664, 211);
            this.PanelAdd.TabIndex = 4;
            // 
            // ButtonBackMenuColor
            // 
            this.ButtonBackMenuColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ButtonBackMenuColor.Location = new System.Drawing.Point(107, 6);
            this.ButtonBackMenuColor.Name = "ButtonBackMenuColor";
            this.ButtonBackMenuColor.Size = new System.Drawing.Size(24, 25);
            this.ButtonBackMenuColor.TabIndex = 0;
            this.ButtonBackMenuColor.UseVisualStyleBackColor = true;
            this.ButtonBackMenuColor.Click += new System.EventHandler(this.ButtonBackMenuColor_Click);
            // 
            // LabelBackMenuColor
            // 
            this.LabelBackMenuColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelBackMenuColor.AutoSize = true;
            this.LabelBackMenuColor.Location = new System.Drawing.Point(3, 12);
            this.LabelBackMenuColor.Margin = new System.Windows.Forms.Padding(3);
            this.LabelBackMenuColor.Name = "LabelBackMenuColor";
            this.LabelBackMenuColor.Size = new System.Drawing.Size(98, 13);
            this.LabelBackMenuColor.TabIndex = 1;
            this.LabelBackMenuColor.Text = "Menu Background ";
            this.LabelBackMenuColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TableLayoutPanelColors
            // 
            this.TableLayoutPanelColors.ColumnCount = 4;
            this.TableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.TableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableLayoutPanelColors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 451F));
            this.TableLayoutPanelColors.Controls.Add(this.LabelBackTreeViewColor, 0, 1);
            this.TableLayoutPanelColors.Controls.Add(this.LabelBackMenuColor, 0, 0);
            this.TableLayoutPanelColors.Controls.Add(this.ButtonBackMenuColor, 1, 0);
            this.TableLayoutPanelColors.Controls.Add(this.ButtonBackTreeViewColor, 1, 1);
            this.TableLayoutPanelColors.Controls.Add(this.LabelForeMenuColor, 2, 0);
            this.TableLayoutPanelColors.Controls.Add(this.LabelForeTreeViewColor, 2, 1);
            this.TableLayoutPanelColors.Controls.Add(this.ButtonForeMenuColor, 3, 0);
            this.TableLayoutPanelColors.Controls.Add(this.ButtonForeTreeViewColor, 3, 1);
            this.TableLayoutPanelColors.Controls.Add(this.ButtonReset, 0, 2);
            this.TableLayoutPanelColors.Location = new System.Drawing.Point(6, 19);
            this.TableLayoutPanelColors.Name = "TableLayoutPanelColors";
            this.TableLayoutPanelColors.RowCount = 3;
            this.TableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanelColors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanelColors.Size = new System.Drawing.Size(649, 111);
            this.TableLayoutPanelColors.TabIndex = 2;
            // 
            // LabelBackTreeViewColor
            // 
            this.LabelBackTreeViewColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelBackTreeViewColor.AutoSize = true;
            this.LabelBackTreeViewColor.Location = new System.Drawing.Point(3, 49);
            this.LabelBackTreeViewColor.Name = "LabelBackTreeViewColor";
            this.LabelBackTreeViewColor.Size = new System.Drawing.Size(84, 13);
            this.LabelBackTreeViewColor.TabIndex = 5;
            this.LabelBackTreeViewColor.Text = "List Background";
            this.LabelBackTreeViewColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonBackTreeViewColor
            // 
            this.ButtonBackTreeViewColor.Location = new System.Drawing.Point(107, 40);
            this.ButtonBackTreeViewColor.Name = "ButtonBackTreeViewColor";
            this.ButtonBackTreeViewColor.Size = new System.Drawing.Size(24, 25);
            this.ButtonBackTreeViewColor.TabIndex = 3;
            this.ButtonBackTreeViewColor.UseVisualStyleBackColor = true;
            this.ButtonBackTreeViewColor.Click += new System.EventHandler(this.ButtonBackTreeViewColor_Click);
            // 
            // LabelForeMenuColor
            // 
            this.LabelForeMenuColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelForeMenuColor.AutoSize = true;
            this.LabelForeMenuColor.Location = new System.Drawing.Point(137, 12);
            this.LabelForeMenuColor.Margin = new System.Windows.Forms.Padding(3);
            this.LabelForeMenuColor.Name = "LabelForeMenuColor";
            this.LabelForeMenuColor.Size = new System.Drawing.Size(58, 13);
            this.LabelForeMenuColor.TabIndex = 4;
            this.LabelForeMenuColor.Text = "Menu Text";
            this.LabelForeMenuColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelForeTreeViewColor
            // 
            this.LabelForeTreeViewColor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LabelForeTreeViewColor.AutoSize = true;
            this.LabelForeTreeViewColor.Location = new System.Drawing.Point(148, 49);
            this.LabelForeTreeViewColor.Name = "LabelForeTreeViewColor";
            this.LabelForeTreeViewColor.Size = new System.Drawing.Size(47, 13);
            this.LabelForeTreeViewColor.TabIndex = 2;
            this.LabelForeTreeViewColor.Text = "List Text";
            this.LabelForeTreeViewColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonForeMenuColor
            // 
            this.ButtonForeMenuColor.Location = new System.Drawing.Point(201, 3);
            this.ButtonForeMenuColor.Name = "ButtonForeMenuColor";
            this.ButtonForeMenuColor.Size = new System.Drawing.Size(25, 25);
            this.ButtonForeMenuColor.TabIndex = 6;
            this.ButtonForeMenuColor.UseVisualStyleBackColor = true;
            this.ButtonForeMenuColor.Click += new System.EventHandler(this.ButtonForeMenuColor_Click);
            // 
            // ButtonForeTreeViewColor
            // 
            this.ButtonForeTreeViewColor.Location = new System.Drawing.Point(201, 40);
            this.ButtonForeTreeViewColor.Name = "ButtonForeTreeViewColor";
            this.ButtonForeTreeViewColor.Size = new System.Drawing.Size(25, 25);
            this.ButtonForeTreeViewColor.TabIndex = 7;
            this.ButtonForeTreeViewColor.UseVisualStyleBackColor = true;
            this.ButtonForeTreeViewColor.Click += new System.EventHandler(this.ButtonForeTreeViewColor_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ButtonReset.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonReset.Location = new System.Drawing.Point(3, 81);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 8;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = false;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // GroupBoxColors
            // 
            this.GroupBoxColors.Controls.Add(this.TableLayoutPanelColors);
            this.GroupBoxColors.Location = new System.Drawing.Point(10, 302);
            this.GroupBoxColors.Name = "GroupBoxColors";
            this.GroupBoxColors.Size = new System.Drawing.Size(664, 143);
            this.GroupBoxColors.TabIndex = 5;
            this.GroupBoxColors.TabStop = false;
            this.GroupBoxColors.Text = "Colors (*requires restart)";
            // 
            // GroupBoxSettings
            // 
            this.GroupBoxSettings.Controls.Add(this.LabelLanguage);
            this.GroupBoxSettings.Controls.Add(this.ComboBoxLanguage);
            this.GroupBoxSettings.Controls.Add(this.CheckBoxExpand);
            this.GroupBoxSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBoxSettings.Location = new System.Drawing.Point(10, 221);
            this.GroupBoxSettings.Name = "GroupBoxSettings";
            this.GroupBoxSettings.Size = new System.Drawing.Size(664, 81);
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
            this.ComboBoxLanguage.Location = new System.Drawing.Point(103, 43);
            this.ComboBoxLanguage.Name = "ComboBoxLanguage";
            this.ComboBoxLanguage.Size = new System.Drawing.Size(148, 21);
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
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 451);
            this.Controls.Add(this.GroupBoxColors);
            this.Controls.Add(this.GroupBoxSettings);
            this.Controls.Add(this.PanelAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
            this.TableLayoutPanelColors.ResumeLayout(false);
            this.TableLayoutPanelColors.PerformLayout();
            this.GroupBoxColors.ResumeLayout(false);
            this.GroupBoxSettings.ResumeLayout(false);
            this.GroupBoxSettings.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button ButtonBackMenuColor;
        private System.Windows.Forms.Label LabelBackMenuColor;
        private System.Windows.Forms.TableLayoutPanel TableLayoutPanelColors;
        private System.Windows.Forms.Label LabelForeTreeViewColor;
        private System.Windows.Forms.Button ButtonBackTreeViewColor;
        private System.Windows.Forms.Label LabelForeMenuColor;
        private System.Windows.Forms.Label LabelBackTreeViewColor;
        private System.Windows.Forms.Button ButtonForeMenuColor;
        private System.Windows.Forms.Button ButtonForeTreeViewColor;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.GroupBox GroupBoxColors;
        private System.Windows.Forms.GroupBox GroupBoxSettings;
        private System.Windows.Forms.CheckBox CheckBoxExpand;
        private System.Windows.Forms.ComboBox ComboBoxLanguage;
        private System.Windows.Forms.Label LabelLanguage;
    }
}