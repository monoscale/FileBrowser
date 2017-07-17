using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser.FormControls
{
    public partial class HelpLabel : Label
    {
        public HelpLabel()
        {
            Padding = new Padding(5);
            InitializeComponent();
        }

        public HelpLabel(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
    }
}
