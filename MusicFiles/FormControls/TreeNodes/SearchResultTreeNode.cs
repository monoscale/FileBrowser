using FileBrowser.Models;
using System.Windows.Forms;

namespace FileBrowser.FormControls.TreeNodes {


    /// <summary>
    /// TreeNode that represents a file 
    /// </summary>
    public class FileTreeNode: TreeNode {
        public FileTreeNode(string name, string fullName) {
            Text = name;
            ToolTipText = fullName;
            Tag = NODE_STAT.FILE;
        }
    }
}
