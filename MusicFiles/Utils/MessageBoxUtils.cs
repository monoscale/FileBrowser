using System.Windows.Forms;

namespace MusicFiles.Utils
{
    /// <summary>
    /// Easy handling of MessageBox instances
    /// </summary>
    public class MessageBoxUtils
    {

        public static void ShowError(string title, string text)
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowExclamation(string title, string text)
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
