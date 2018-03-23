using FileBrowser.Models;
using FileBrowser.Utils;
using System.Drawing;
using System.Windows.Forms;

namespace FileBrowser.FormControls.TreeNodes {


    /// <summary>
    /// TreeNode that represents a file 
    /// </summary>
    public class FileTreeNode: TreeNode {
        public FileTreeNode(string name, string fullPath) {
            Text = name;
            ToolTipText = fullPath;
            Tag = NODE_STAT.FILE;
        }
    }

    
}
