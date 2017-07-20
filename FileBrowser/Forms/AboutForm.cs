using FileBrowser.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser.Forms {
    public partial class AboutForm : Form {


        public AboutForm() {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e ) {

            TitleBuilder titleBuilder = new TitleBuilder();
            Text = titleBuilder.BuildSecondaryTitle(Resources.Strings.MenuAbout);
            Icon = Properties.Resources.Icon;
            base.OnLoad(e);
        }
    }
}
