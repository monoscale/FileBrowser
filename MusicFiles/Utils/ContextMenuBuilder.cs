using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicFiles.Utils
{
    /// <summary>
    /// Class that allows for easy ContextMenu creation
    /// </summary>
    public class ContextMenuBuilder
    {

        private ContextMenuStrip menu;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ContextMenuBuilder()
        {
            menu = new ContextMenuStrip();
        }

        /// <summary>
        /// Adds a ToolStripMenuItem to the ContextMenuStrip
        /// </summary>
        /// <param name="name">The text that has to show</param>
        /// <param name="handler">The handler that occurs when clicking the ToolStripMenuItem</param>
        public void Add(string text, EventHandler handler)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(text);
            item.Click += handler;
            menu.Items.Add(item);
        }

        /// <summary>
        /// Shows the ContextMenuStrip at the location of the Cursor
        /// </summary>
        public void Show()
        {
            menu.Show(Cursor.Position);
        }
    }
}
