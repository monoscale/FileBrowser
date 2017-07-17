using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser.Utils
{
    public class FormUtils
    {

        /// <summary>
        /// Sometimes the form can appear out of the screen (for example you disconnected your second monitor), thus being unable to bring the form back on your main screen.
        /// This method determines if the form is on any active monitor.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        public static bool IsOnScreen(Form form)
        {
            Screen[] screens = Screen.AllScreens;
            Rectangle formRectangle = new Rectangle(form.Left, form.Top, form.Width, form.Height);
            foreach (Screen screen in screens)
            {
                if (screen.WorkingArea.Contains(formRectangle))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Standard procedure of opening a new form. Creates a small offset to give a 3D illusion
        /// </summary>
        /// <param name="form"></param>
        /// <param name="parentLocation"></param>
        public static void OpenForm(Form form, Point parentLocation, int offset = 100)
        {
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(parentLocation.X + offset, parentLocation.Y + offset);
            form.Show();
        }
    }
}
