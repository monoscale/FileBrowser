using MusicFiles.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFiles.Models.Language
{
    /// <summary>
    /// Class that controls the Language flow
    /// </summary>
    public class LanguageManager
    {
        private LanguageMapper languageMapper;
        private LanguageCollection languages;

        public LanguageManager()
        {
            languages = new LanguageCollection();
            languageMapper = new LanguageMapper(languages.Languages);
        }

        public ICollection<string> GetReadableLanguages()
        {
            return languages.GetReadableLanguages();
        }

        /// <summary>
        /// Stores the language in the User preferences
        /// </summary>
        /// <param>The language code</param>
        public void SavePreferredLanguageCode(string code)
        {
            Settings.Default.Language = code;
        }

        /// <summary>
        /// Gets the language code
        /// </summary>
        /// <returns></returns>
        public string GetPreferredLanguageCode()
        {
            return Settings.Default.Language;
        }

        public string CodeToLanguage(string code)
        {
            return languageMapper.CodeToLanguage(code);
        }

        public string LanguageToCode(string language)
        {
            return languageMapper.LanguageToCode(language);
        }
    }
}
