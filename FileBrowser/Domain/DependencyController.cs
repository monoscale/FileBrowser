using FileBrowser.Domain.Language;
using FileBrowser.Domain.Themes;

namespace FileBrowser.Domain {
    public class DependencyController {


        public ThemeManager ThemeManager { get; set; }
        public LanguageManager LanguageManager { get; set; }
    }
}
