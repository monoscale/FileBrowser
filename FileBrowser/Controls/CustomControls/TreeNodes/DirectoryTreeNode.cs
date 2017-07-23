using FileBrowser.Models;
using System.Windows.Forms;

namespace FileBrowser.Controls.CustomControls.TreeNodes {


    /// <summary>
    /// TreeNode that represents a directory
    /// </summary>
    public class DirectoryTreeNode : TreeNode{

        public DirectoryTreeNode(string path) {
            Text = path;
            Tag = NODE_STAT.DIRECTORY;
        }
    }
}
