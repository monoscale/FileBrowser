using System.Drawing;

namespace FileBrowser.Domain.Themes {
    public class LightColorTheme : ColorTheme {

        public override Color DefaultText => Color.Black;

        public override Color ErrorText => Color.Red;

        public override Color BackGroundMenu => Color.WhiteSmoke;

        public override Color BackGroundTree => Color.White;

        public override Color ForeGroundMenu => Color.Black;

        public override Color ForeGroundTree => SystemColors.Highlight;

        

    }
}
