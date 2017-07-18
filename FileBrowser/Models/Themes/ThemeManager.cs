using FileBrowser.Properties;

namespace FileBrowser.Models.Themes {
    public class ThemeManager {

        /// <summary>
        /// Gets the active color theme
        /// </summary>
        public ColorTheme ColorTheme { get; private set; }

        public ThemeManager() {
            SetColorTheme();
        }

        public void SetTheme( Theme theme ) {
            Settings.Default.Theme = (int)theme;
            SetColorTheme();
        }

        private void SetColorTheme() {
            Theme theme = GetTheme();
            switch(theme) {
                case Theme.LIGHT:
                    ColorTheme = new LightColorTheme();
                    break;
                case Theme.DARK:
                    ColorTheme = new DarkColorTheme();
                    break;
            }
        }

        public Theme GetTheme() {
            int value = Settings.Default.Theme;
            return (Theme)value;
        }
    }
}
