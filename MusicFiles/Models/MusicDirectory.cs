using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace MusicFiles.Models
{
    /// <summary>
    /// This class represents a directory that is dedicated to storing music related files
    /// </summary>
    public class MusicDirectory
    {
        /// <summary>
        /// Path of the directory
        /// </summary>
        private string path;

        /// <summary>
        /// Gets or Sets the path of the directory
        /// </summary>
        public string Path
        {
            get => path;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Path of the directory cannot be empty.");
                }
                path = value;
            }
        }

        /// <summary>
        /// Default construct
        /// </summary>
        /// <param name="path">The path of the directory</param>
        public MusicDirectory(string path)
        {
            Path = path;
        }

        /// <summary>
        /// Gets all the files that match the extensions
        /// </summary>
        /// <param name="extensions">A collection of extensions</param>
        /// <returns></returns>
        public ICollection<FileInfo> GetFiles(ICollection<string> extensions)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            List<FileInfo> files = new List<FileInfo>();
            foreach (string ext in extensions)
            {
                string regex = "*" + ext;
                files.AddRange(directory.GetFiles(regex, SearchOption.AllDirectories));
            }
            files.Sort(new FileInfoComparer());
            return files;
        }



        /// <summary>
        /// Special File Comparer that treats digits as numerical rather than text
        /// </summary>
        private class FileInfoComparer : IComparer<FileInfo>
        {
          
            [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
            public static extern int StrCmpLogicalW(string x, string y);


            /// <summary>
            /// Compares two Unicode strings. Digits in the strings are considered as numerical content rather than text. this test is not case-sensitive.
            /// </summary>
            /// <param name="x">First FileInfo instance</param>
            /// <param name="y">Second FileInfo instance</param>
            /// <returns></returns>

            public int Compare(FileInfo x, FileInfo y)
            {
                return StrCmpLogicalW(x.Name, y.Name);
            }
        }
    }

}