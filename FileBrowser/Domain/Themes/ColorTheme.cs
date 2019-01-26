using System.Configuration;
using System.Drawing;

namespace FileBrowser.Domain.Themes {

    [SettingsSerializeAs(SettingsSerializeAs.Xml)]
    public abstract class ColorTheme {

        public abstract Color DefaultText { get; }

        public abstract Color ErrorText { get; }

        public abstract Color BackGroundMenu { get; }

        public abstract Color ForeGroundMenu { get; }

        public abstract Color BackGroundTree { get; }

        public abstract Color ForeGroundTree { get; }

    }
}
