using System.Data.Entity;
using FileBrowser.Model.DAL.Mappings;

namespace FileBrowser.Model.DAL {


    /// <summary>
    /// !!!! SQLite requires you to create your own .sqlite file which matches the domain. Entity Framework will NOT generate a .sqlite file itself.
    /// </summary>
    public class FileBrowserContext : DbContext {

        public virtual DbSet<Category> Categories { get; set; }

        public FileBrowserContext() : base("name=FileBrowserDbConnectionString") {
            Database.SetInitializer<FileBrowserContext>(new CreateDatabaseIfNotExists<FileBrowserContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Configurations.Add(new CategoryMapping());
     
        }
    }
}
