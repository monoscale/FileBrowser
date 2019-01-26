using System;
using System.Collections.Generic;

namespace FileBrowser.Domain.Language
{
    /// <summary>
    /// This class is able to map a language code to a specific language and vice versa
    /// </summary>
    public class LanguageMapper
    {
        private IDictionary<string, string> languages;

        public LanguageMapper(IDictionary<string, string> languages)
        {
            this.languages = languages;
        }

        public string CodeToLanguage(string code)
        {
            if (languages.ContainsKey(code))
            {
                return languages[code];
            }
            throw new ArgumentException($"The code {code} is not a valid country code.");
        }

        public string LanguageToCode(string language)
        {
            foreach (string key in languages.Keys)
            {
                string value = languages[key];
                if (value.Equals(language))
                {
                    return key;
                }
            }
            throw new ArgumentException($"The language {language} is not valid in this program.");
        }
    }
}
