﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBrowser.Domain;
using FileBrowser.Domain.Models;

namespace FileBrowser.Persistence.Repositories {
    public interface IFolderRepository {
        ICollection<Folder> GetFolders();
        void AddFolder( string path );
        void EditFolder( string oldPath, string newPath );
        void RemoveFolder( string path );

    }
}
