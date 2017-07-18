using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser.Models.Themes {
    public class LightColorTheme : ColorTheme {

        public override Color DefaultText => Color.Black;

        public override Color ErrorText => Color.Red;

        public override Color BackGroundMenu => Color.WhiteSmoke;

        public override Color BackGroundTree => Color.White;

        public override Color ForeGroundMenu => Color.Black;

        public override Color ForeGroundTree => SystemColors.Highlight;

        

    }
}
