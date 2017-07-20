using FileBrowser.Utils;
using System;
using System.Windows.Forms;

namespace FileBrowser.Forms
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            TitleBuilder titleBuilder = new TitleBuilder();
            Text = titleBuilder.BuildSecondaryTitle(Resources.Strings.MenuHelp);
            Icon = Properties.Resources.Icon;
            HelpLabel1.Text = "1. " + Resources.Strings.HelpOne;
            HelpLabel2.Text = "2. " + Resources.Strings.HelpTwo;
            HelpLabel3.Text = "3. " + Resources.Strings.HelpThree;
            HelpLabel4.Text = "4. " + Resources.Strings.HelpFour;
            base.OnLoad(e);
        }
    }
}
