using MusicFiles.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFiles.Utils
{
    public class TitleBuilder
    {

        private StringBuilder stringBuilder;

        public TitleBuilder()
        {
            stringBuilder = new StringBuilder();
        }

        public string BuildPrimaryTitle()
        {
            stringBuilder.Clear();
            stringBuilder.Append(Settings.Default.Title);
            return stringBuilder.ToString();
        }

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
