using FileBrowser.Models.Language;
using System.Drawing;
using System.Windows.Forms;

namespace FileBrowser.FormControls.TreeNodes {
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
