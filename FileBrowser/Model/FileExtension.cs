using System.ComponentModel.DataAnnotations;

namespace FileBrowser.Model {
    public class FileExtension {

        [Key]
        public string Extension { get; set; }

        public FileExtension(string extension) {
            Extension = extension;
        }
    }
}
