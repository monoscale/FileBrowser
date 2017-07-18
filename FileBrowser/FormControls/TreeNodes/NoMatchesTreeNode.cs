using FileBrowser.Models;
using System.Drawing;
using System.Windows.Forms;
using FileBrowser.Models.Language;

namespace FileBrowser.FormControls.TreeNodes {


    /// <summary>
    /// TreeNode that represents no matching result for a directory.
    /// </summary>
    public class NoMatchesTreeNode : TreeNode, Localizable {

        public NoMatchesTreeNode() {
            Text = Resources.Strings.ErrorNoMatches;
            ForeColor = Color.OrangeRed;
            Tag = NODE_STAT.INVALID;
        }

        public void UpdateText() {
            Text = Resources.Strings.ErrorNoMatches;
        }
    }
}
