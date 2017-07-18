
using System;
using System.Drawing;

namespace FileBrowser.Models.Themes {
    class DarkColorTheme : ColorTheme {

        public override Color DefaultText => Color.White;

        public override Color ErrorText => Color.OrangeRed;

        public override Color BackGroundMenu => Color.FromArgb(62, 62, 66); // Dark gray

        public override Color ForeGroundMenu => Color.White;

        public override Color BackGroundTree => Color.FromArgb(30, 30, 30);

        public override Color ForeGroundTree => Color.FromArgb(78, 180, 120);

    }

}
