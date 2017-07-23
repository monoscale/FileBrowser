using FileBrowser.Models;
using FileBrowser.Models.Themes;
using System.Drawing;
using System.Windows.Forms;

namespace FileBrowser.Controls.CustomControls.TreeNodes {


    /// <summary>
    /// TreeNode that represents a directory that does not exists anymore
    /// </summary>
    public class DirectoryNotFoundTreeNode : TreeNode, IThemeable {

        private ThemeManager themeManager;

        public DirectoryNotFoundTreeNode(string path, string message, ThemeManager themeManager) {
            this.themeManager = themeManager;
            Text= "(!) " + path;
            ToolTipText = message;
            Tag = NODE_STAT.INVALID;
            ForeColor = themeManager.ColorTheme.ErrorText;
        }

        public void UpdateTheme() {
            ForeColor = themeManager.ColorTheme.ErrorText;
        }
    }
}
