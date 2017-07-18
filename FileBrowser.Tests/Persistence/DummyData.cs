using FileBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Tests.Persistence {
    public class DummyData {

        /// <summary>
        /// Contains 3 files ( 2 txt and 1 docx) and one folder which contains 1 file (mp3)
        /// </summary>
        public string MainValidFolder => "C:/Users/Bert/Documents/visual studio 2017/Projects/FileBrowser/FileBrowser.Tests/TestFolder";
        /// <summary>
        /// Contains nothing
        /// </summary>
        public string SecondaryValidFolder => "C:/Users/Bert/Documents/visual studio 2017/Projects/FileBrowser/FileBrowser.Tests/TestFolderCopy";
        /// <summary>
        /// A folder that does not exist on the filesystem
        /// </summary>
        public string FolderThatDoesNotExist => "C:/Users/Bert/Documents/visual studio 2017/Projects/FileBrowser/FileBrowser.Tests/TestFolderInvalid";



        public string TxtExtension = ".txt";
        public string Mp3Extension = ".mp3";
            

        public ICollection<string> Extensions => new List<string> {
                  TxtExtension,
                  Mp3Extension
        };

        public ICollection<Folder> Folders => new List<Folder> {
            new Folder(MainValidFolder),
            new Folder(SecondaryValidFolder),
            new Folder(FolderThatDoesNotExist)
        };
    }
}
