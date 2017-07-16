using MusicFiles.Properties;
using MusicFiles.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicFiles.Forms
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
            HelpLabel1.Text = "1. " + Resources.Strings.HelpOne;
            HelpLabel2.Text = "2. " + Resources.Strings.HelpTwo;
            HelpLabel3.Text = "3. " + Resources.Strings.HelpThree;
            HelpLabel4.Text = "4. " + Resources.Strings.HelpFour;
            base.OnLoad(e);
        }
    }
}
