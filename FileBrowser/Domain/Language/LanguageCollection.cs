﻿using System.Collections.Generic;
using System.Linq;

namespace FileBrowser.Domain.Language
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
        /// Initializes the Dictionary of languages. This is the only place where a new language can be added.
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
