using System.Windows.Forms;
using FileBrowser.Domain;

namespace FileBrowser.FormControls.TreeNodes {


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
