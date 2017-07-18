using FileBrowser.Models;
using System.Drawing;
using System.Windows.Forms;

namespace FileBrowser.FormControls.TreeNodes {
    public class DirectoryNotFoundTreeNode : TreeNode {

        public DirectoryNotFoundTreeNode(string path, string message) {
            Text= "(!)" + path;
            ToolTipText = message;
            Tag = NODE_STAT.INVALID;
            ForeColor = Color.Red;
        }
    }
}
