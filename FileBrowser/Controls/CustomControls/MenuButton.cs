using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser.Controls.CustomControls {
    public partial class MenuButton : Button {
        public MenuButton() {
            InitializeComponent();
            Dock = DockStyle.Top;
            FlatStyle = FlatStyle.Flat;
            
        }

        protected override void OnPaint(PaintEventArgs pe) {
            base.OnPaint(pe);
        }


        protected override void OnMouseEnter(EventArgs e) {
            Cursor = Cursors.Default;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e) {
            Cursor = Cursors.Default;
            base.OnMouseLeave(e);
        }
    }
}
