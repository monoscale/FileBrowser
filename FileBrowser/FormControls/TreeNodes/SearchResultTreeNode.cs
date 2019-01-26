using System.Windows.Forms;
using FileBrowser.Domain;

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
