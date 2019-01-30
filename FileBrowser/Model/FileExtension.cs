namespace FileBrowser.Model {

    public class FileExtension {
        
   
        public int FileExtensionId { get; set; }
        public string Extension { get; set; }

       
        public virtual Category Category { get; set; }

        public FileExtension(string extension) {
            Extension = extension;
        }
    }
}
