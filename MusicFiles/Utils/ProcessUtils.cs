using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFiles.Utils
{
    public class ProcessUtils
    {

        /// <summary>
        /// Starts a process for the given path
        /// </summary>
        /// <param name="filepath">The path to start a process for</param>
        public static void StartProcess(string filepath)
        {
            Process.Start(filepath);
        }
    }
}
