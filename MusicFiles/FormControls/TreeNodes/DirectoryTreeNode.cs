using FileBrowser.Models;
using System.Windows.Forms;

namespace FileBrowser.FormControls.TreeNodes {
    public class DirectoryTreeNode : TreeNode{

        public DirectoryTreeNode(string path) {
            Text = path;
            Tag = NODE_STAT.DIRECTORY;
        }
    }
}
