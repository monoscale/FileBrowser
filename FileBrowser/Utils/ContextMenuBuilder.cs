using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser.Utils
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
        /// <param name="name">The text on the ToolStrip</param>
        /// <param name="handler">The event that occurs when clicking the ToolStripMenuItem</param>
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



        /// <summary>
        /// Shows the ContextMenuStrip at the location given as a parameter
        /// </summary>
        /// <param name="location">The location</param>
        public void Show( Point location ) {
            menu.Show(location);
        }
    }
}
