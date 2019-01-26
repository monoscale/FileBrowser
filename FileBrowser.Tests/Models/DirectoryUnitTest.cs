using FileBrowser.Tests.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using FileBrowser.Domain;

namespace FileBrowser.Tests.Models {

    [TestClass]
    public class DirectoryUnitTest {


        private Folder folder;
        private DummyData dummyData;



        [TestInitialize]
        public void Before() {
            dummyData = new DummyData();
            folder = new Folder(dummyData.MainValidFolder);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EmptyFolderThrowsArgumentException() {
            new Folder("");
        }




        [TestMethod]
        public void GetFilesTest() {
            ICollection<FileInfo> files = folder.GetFiles(dummyData.Extensions);
            Assert.AreEqual(3, files.Count);
        }

        [TestMethod]
        public void OtherFolderIsEqualIfPathEqual() {
            Folder otherFolder = new Folder(dummyData.MainValidFolder);
            Assert.IsTrue(folder.Equals(otherFolder));
        }

        [TestMethod]
        public void OtherFolderIsNotEqualIfPathDifferent() {
            Folder otherFolder = new Folder(dummyData.SecondaryValidFolder);
            Assert.IsFalse(folder.Equals(otherFolder));
        }
    }
}
