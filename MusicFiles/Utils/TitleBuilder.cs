using FileBrowser.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Utils
{
    /// <summary>
    /// Class to handle form titles
    /// </summary>
    public class TitleBuilder
    {

        private StringBuilder stringBuilder;

        /// <summary>
        /// Default constructor
        /// </summary>
        public TitleBuilder()
        {
            stringBuilder = new StringBuilder();
        }


        /// <summary>
        /// Builds a title fit for the applications entry point
        /// </summary>
        /// <returns>The title</returns>
        public string BuildPrimaryTitle()
        {
            stringBuilder.Clear();
            stringBuilder.Append(Settings.Default.Title);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Builds a title fit for any secondary forms
        /// </summary>
        /// <param name="secondary">The name of the form</param>
        /// <returns>The title</returns>
        public string BuildSecondaryTitle(string secondary)
        {
            stringBuilder.Clear();
            stringBuilder.Append(Settings.Default.Title);
            stringBuilder.Append(" - ");
            stringBuilder.Append(secondary);
            return stringBuilder.ToString();

        }
    }
}
