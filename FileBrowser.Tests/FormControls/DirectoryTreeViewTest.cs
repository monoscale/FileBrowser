using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileBrowser.FormControls;
using FileBrowser.Tests.Persistence.Repositories;
using FileBrowser.Tests.Persistence;
using System.Windows.Forms;
using System.Collections.Generic;
using FileBrowser.Models.Themes;

namespace FileBrowser.Tests.FormControls {
    [TestClass]
    public class DirectoryTreeViewTest {

        private DirectoryTreeView directoryTreeView;
        private DummyData dummyData;

        [TestInitialize]
        public void Before() {
            dummyData = new DummyData();
            directoryTreeView = new DirectoryTreeView(new MockFolderRepository(dummyData), new MockExtensionRepository(dummyData));
            directoryTreeView.SetDependencies(new ThemeManager());
        }

        [TestMethod]
        public void GenerateDoesNotExpandByDefault() {
            bool isExpanded = false;
            directoryTreeView.Generate();
            foreach(TreeNode node in directoryTreeView.Nodes) {
                if(node.Nodes.Count > 0) {
                    if(node.IsExpanded) {
                        isExpanded = true;
                        break;
                    }
                }
            }

            Assert.IsFalse(isExpanded);
        }

        [TestMethod]
        public void GenerateExpandsAllFoldersWhenParamIsTrue() {
            bool isExpanded = true;
            directoryTreeView.Generate(true);
            foreach(TreeNode node in directoryTreeView.Nodes) {
                if(node.Nodes.Count > 0) {
                    if(!(node.IsExpanded)) {
                        isExpanded = false;
                        break;
                    }
                }
            }
            Assert.IsTrue(isExpanded);
        }

        [TestMethod]
        public void GenerateSortsAlphabetically() {
            directoryTreeView.Generate();
            Assert.AreEqual("File1.txt", directoryTreeView.Nodes[0].Nodes[0].Text);
            Assert.AreEqual("file3.mp3", directoryTreeView.Nodes[0].Nodes[1].Text);
            Assert.AreEqual("FILE4.txt", directoryTreeView.Nodes[0].Nodes[2].Text);
        }



        // Keep in mind that our extensions are only "mp3" and "txt". The docx file will never be shown.
        // The maximum amount of childnodes that the first directory can have is 3.
        // The directory that contains nothing should always have 1 childnode (the node that says nothing was found)
        // The invalid folder should contain 0 childnodesnodes

        /* SEARCHING */
        [TestMethod]
        public void EmptySearchShowsEverything() {
            directoryTreeView.Search("");
            Assert.AreEqual(3, directoryTreeView.Nodes[0].Nodes.Count); //File1.txt, FILE4.txt and file3.mp3
        }

        [TestMethod]
        public void DirectoryWithoutMatchesHasOneTreeNodeWithInformationAboutNoMatches() {
            directoryTreeView.Search("");
            Assert.AreEqual(1, directoryTreeView.Nodes[1].Nodes.Count); //node that says there are no files
        }

        [TestMethod]
        public void InvalidDirectoryHasNoChildNodesWhenSearching() {
            directoryTreeView.Search("");
            Assert.AreEqual(0, directoryTreeView.Nodes[2].Nodes.Count); //no childnodes
        }

        [TestMethod]
        public void SearchRemovesNodesThatDontMatch() {
            directoryTreeView.Search("file1");
            Assert.AreEqual(1, directoryTreeView.Nodes[0].Nodes.Count); //file1.txt
            Assert.AreEqual("File1.txt", directoryTreeView.Nodes[0].Nodes[0].Text);
        }

        [TestMethod]
        public void EmptySearchShowsEverythingAfterAlreadySearchedSomething() {
            directoryTreeView.Search("File1");
            directoryTreeView.Search("");
            Assert.AreEqual(3, directoryTreeView.Nodes[0].Nodes.Count); //File1.txt, FILE4.txt and file3.mp3
            Assert.AreEqual("File1.txt", directoryTreeView.Nodes[0].Nodes[0].Text);
            Assert.AreEqual("file3.mp3", directoryTreeView.Nodes[0].Nodes[1].Text);
            Assert.AreEqual("FILE4.txt", directoryTreeView.Nodes[0].Nodes[2].Text);
           
        }

        [TestMethod]
        public void SearchIsCaseInsensitive() {
            directoryTreeView.Search("FiLE");
            Assert.AreEqual(3, directoryTreeView.Nodes[0].Nodes.Count); //File1.txt, FILE4.txt and file3.mp3
            Assert.AreEqual("File1.txt", directoryTreeView.Nodes[0].Nodes[0].Text);
            Assert.AreEqual("file3.mp3", directoryTreeView.Nodes[0].Nodes[1].Text);
            Assert.AreEqual("FILE4.txt", directoryTreeView.Nodes[0].Nodes[2].Text);
        }

        /* EXTENSION FILTERING */
        [TestMethod]
        public void NoFiltersShowsEverything() {
            directoryTreeView.FilterExtensions(new List<string>());
            Assert.AreEqual(3, directoryTreeView.Nodes[0].Nodes.Count); //File1.txt, FILE4.txt and file3.mp3
            Assert.AreEqual("File1.txt", directoryTreeView.Nodes[0].Nodes[0].Text);
            Assert.AreEqual("file3.mp3", directoryTreeView.Nodes[0].Nodes[1].Text);
            Assert.AreEqual("FILE4.txt", directoryTreeView.Nodes[0].Nodes[2].Text);
        }

        [TestMethod]
        public void FilterOnlyShowsMatchingFiles() {
            directoryTreeView.FilterExtensions(new List<string> { dummyData.TxtExtension });
            Assert.AreEqual(2, directoryTreeView.Nodes[0].Nodes.Count); //File1.txt, FILE4.txt
            Assert.AreEqual("File1.txt", directoryTreeView.Nodes[0].Nodes[0].Text);
            Assert.AreEqual("FILE4.txt", directoryTreeView.Nodes[0].Nodes[1].Text);
        }

    }
}
