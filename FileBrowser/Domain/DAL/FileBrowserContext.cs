using System.Data.Entity;
using FileBrowser.Domain.Models;

namespace FileBrowser.Domain.DAL {
    public class FileBrowserContext : DbContext {

        public FileBrowserContext() : base("FileBrowserDb") { }

        public virtual DbSet<Category> Categories { get; set; }


    }
}
