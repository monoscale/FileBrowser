using FileBrowser.Models.Language;
using FileBrowser.Models.Themes;

namespace FileBrowser.Models {
    public class DependencyController {


        public ThemeManager ThemeManager { get; set; }
        public LanguageManager LanguageManager { get; set; }
    }
}
