using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFiles.Models.Language
{
    /// <summary>
    /// The class that knows which languages are available on this system
    /// </summary>
    public class LanguageCollection
    {

        /// <summary>
        /// The key is the language code, the value is the full name of the language
        /// </summary>
        public IDictionary<string, string> Languages { get; }

        /// <summary>
        /// Initializes the Dictionary of languages
        /// </summary>
        public LanguageCollection()
        {
            Languages = new Dictionary<string, string>
            {
                { "en", "English" },
                { "nl", "Nederlands" }
            };

        }

        /// <summary>
        /// Only returns the full name of each language
        /// </summary>
        /// <returns></returns>
        public ICollection<string> GetReadableLanguages()
        {
            return Languages.Values.ToList();
        }
    }
}
