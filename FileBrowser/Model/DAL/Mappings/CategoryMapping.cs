using System.Data.Entity.ModelConfiguration;

namespace FileBrowser.Model.DAL.Mappings {
    public class CategoryMapping : EntityTypeConfiguration<Category> {

        public CategoryMapping() {
            ToTable("Categories");

            HasKey<int>(c => c.CategoryId);

            HasMany<Folder>(c => c.Folders)
                .WithRequired(f =>  f.Category)
                .WillCascadeOnDelete(true);

            HasMany<FileExtension>(c => c.Extensions)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(true);
        }
    }
}
