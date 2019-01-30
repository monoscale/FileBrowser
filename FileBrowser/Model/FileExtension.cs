namespace FileBrowser.Model {

    public class FileExtension {
        
   
        public int FileExtensionId { get; set; }
        public string Extension { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public FileExtension() { }

        public FileExtension(string extension) {
            Extension = extension;
        }
    }
}
