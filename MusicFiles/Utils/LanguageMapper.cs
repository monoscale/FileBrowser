using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFiles.Utils
{
    public class LanguageMapper
    {
        private IDictionary<string, string> languages;

        public LanguageMapper()
        {
            languages = new Dictionary<string, string>();
            languages.Add("en", "English");
            languages.Add("nl", "Nederlands");
        }

        public ICollection<string> GetReadableLanguages()
        {
            IList<string> langs = new List<string>();
            foreach(string key in languages.Keys)
            {
                langs.Add(languages[key]);
            }

            return langs;
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
