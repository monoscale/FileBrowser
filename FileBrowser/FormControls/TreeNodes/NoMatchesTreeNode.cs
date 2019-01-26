using System.Drawing;
using System.Windows.Forms;
using FileBrowser.Domain;
using FileBrowser.Domain.Language;
using FileBrowser.Domain.Themes;

namespace FileBrowser.FormControls.TreeNodes {


    /// <summary>
    /// TreeNode that represents no matching result for a directory.
    /// </summary>
    public class NoMatchesTreeNode : TreeNode, ILocalizable, IThemeable
        {

        private ThemeManager themeManager;

        public NoMatchesTreeNode(ThemeManager themeManager) {
            this.themeManager = themeManager;
            Text = Resources.Strings.ErrorNoMatches;
            ForeColor = themeManager.ColorTheme.ErrorText;
            Tag = NODE_STAT.INVALID;
        }

        public void UpdateText() {
            Text = Resources.Strings.ErrorNoMatches;
        }

        public void UpdateTheme() {
            ForeColor = themeManager.ColorTheme.ErrorText;
        }

    }
}
