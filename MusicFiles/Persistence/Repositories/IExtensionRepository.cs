using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.Persistence.Repositories {
    public interface IExtensionRepository {

        ICollection<string> GetExtensions();
        void AddExtension( string extension );
        void RemoveExtension( string extension );

    }
}
