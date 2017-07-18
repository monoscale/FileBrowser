using FileBrowser.Models.Language;
using System.Drawing;
using System.Windows.Forms;

namespace FileBrowser.FormControls.TreeNodes {



    /// <summary>
    /// TreeNode that represents a message when the user has not selected a single directory yet.
    /// </summary>
    public class NoDirectoriesTreeNode : TreeNode, Localizable {

        public NoDirectoriesTreeNode() {
            Text = Resources.Strings.ErrorNoDirectories;
            ForeColor = Color.OrangeRed;
        }


        public void UpdateText() {
            Text = Resources.Strings.ErrorNoDirectories;
        }
    }
}
