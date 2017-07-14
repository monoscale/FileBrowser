
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MusicFiles.UI
{
    public partial class MenuButton : Button
    {
        public MenuButton()
        {
            InitializeComponent();
        }

        public MenuButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }



        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.AntiqueWhite;
            Cursor = Cursors.Hand;
        }

        private void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.Transparent;
            Cursor.Current = Cursors.Default;
        }
    }
}
