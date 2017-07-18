using FileBrowser.Models;
using System.Windows.Forms;

namespace FileBrowser.FormControls.TreeNodes {
    public class SearchResultTreeNode: TreeNode {
        public SearchResultTreeNode(string name, string fullName) {
            Text = name;
            ToolTipText = fullName;
            Tag = NODE_STAT.FILE;
        }
    }
}
