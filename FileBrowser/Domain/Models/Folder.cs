﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace FileBrowser.Domain.Models {
    /// <summary>
    /// This class represents a directory
    /// </summary>
    public class Folder : IEquatable<Folder> {
        /// <summary>
        /// Path of the directory
        /// </summary>
        private string path;

        /// <summary>
        /// Gets or sets the path of the directory
        /// </summary>
        public string Path {
            get => path;
            set {
                if (string.IsNullOrWhiteSpace(value)) {
                    throw new ArgumentException(Resources.Strings.ArgumentExceptionPathFolder);
                }
                path = value;
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="path">The path of the directory</param>
        public Folder(string path) {
            Path = path;
        }

        /// <summary>
        /// Gets all the files that match the extensions
        /// </summary>
        /// <param name="extensions">A collection of extensions</param>
        /// <returns>A collection of files that match the extensions</returns>
        public ICollection<FileInfo> GetFiles(ICollection<string> extensions) {
            DirectoryInfo directory = new DirectoryInfo(Path);
            List<FileInfo> files = new List<FileInfo>();
            foreach (string ext in extensions) {
                string regex = "*" + ext;
                files.AddRange(directory.GetFiles(regex, SearchOption.AllDirectories));
            }
            files.Sort(new FileInfoComparer());
            return files;
        }


        /// <summary>
        /// Overriden from IEquatable. Determines if an other Directory instance is equal to this one.
        /// </summary>
        /// <param name="other"></param>
        /// <returns>true if equal; else false</returns>
        public bool Equals(Folder other) {
            if (other == null) {
                return false;
            }
            return (Path.Equals(other.Path));
        }



        /// <summary>
        /// Special File Comparer that treats digits as numerical rather than text
        /// </summary>
        private class FileInfoComparer : IComparer<FileInfo> {

            [DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
            private static extern int StrCmpLogicalW(string x, string y);


            /// <summary>
            /// Compares two Unicode strings. Digits in the strings are considered as numerical content rather than text. this test is not case-sensitive.
            /// </summary>
            /// <param name="x">First FileInfo instance</param>
            /// <param name="y">Second FileInfo instance</param>
            /// <returns>0 if identical
            /// 1 if x > y
            /// -1 if x < y
            /// </returns>
            public int Compare(FileInfo x, FileInfo y) {
                return StrCmpLogicalW(x.Name, y.Name);
            }
        }
    }

}