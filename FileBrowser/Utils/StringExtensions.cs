using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Utils {
    public static class StringExtensions {

        public static string FirstLetterToUpperCase(this string s ) {
            return s.Take(1).ToString() + String.Join("", s.Skip(1).ToString().ToLower()); 
        }
    }
}