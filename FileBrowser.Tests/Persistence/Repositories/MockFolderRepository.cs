using FileBrowser.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBrowser.Models;

namespace FileBrowser.Tests.Persistence.Repositories {
    public class MockFolderRepository : IFolderRepository {

        private ICollection<Folder> folders;

        public MockFolderRepository(DummyData dummyData) {
            folders = dummyData.Folders;

        }

        public ICollection<Folder> GetFolders() {
            return folders;
        }

        public void AddFolder( string path ) {
            folders.Add(new Folder(path));
        }

        public void EditFolder( string oldPath, string newPath ) {
            foreach(Folder f in folders) {
                if(f.Path.Equals(oldPath)) {
                    f.Path = newPath;
                    break;
                }
            }
        }

        public void RemoveFolder( string path ) {
            foreach(Folder f in folders) {
                if(f.Path.Equals(path)) {
                    folders.Remove(f);
                    break;
                }
            }
        }
    }
}
