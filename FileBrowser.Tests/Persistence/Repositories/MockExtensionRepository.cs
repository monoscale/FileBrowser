using System;
using System.Collections.Generic;
using FileBrowser.Persistence.Repositories;

namespace FileBrowser.Tests.Persistence.Repositories {
    public class MockExtensionRepository : IExtensionRepository {

        private ICollection<string> extensions;

        public MockExtensionRepository(DummyData dummyData) {
            extensions = dummyData.Extensions;
        }
        public void AddExtension( string extension ) {
            extensions.Add(extension);
        }

        public ICollection<string> GetExtensions() {
            return extensions;
        }

        public void RemoveExtension( string extension ) {
            extensions.Remove(extension);
        }


    }
}
