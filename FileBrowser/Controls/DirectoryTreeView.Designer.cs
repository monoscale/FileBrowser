namespace FileBrowser.FormControls {
    partial class DirectoryTreeView {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.treeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // TreeViewDirectories
            // 
            this.treeView.LineColor = System.Drawing.Color.Empty;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "TreeViewDirectories";
            this.treeView.Size = new System.Drawing.Size(121, 97);
            this.treeView.TabIndex = 0;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
    }
}
