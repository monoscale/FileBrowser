
using System.Data.Entity.ModelConfiguration;

namespace FileBrowser.Model.DAL.Mappings {
    public class FolderMapping : EntityTypeConfiguration<Folder> {
        public FolderMapping() {
            ToTable("Folders");

            HasKey<int>(f => f.FolderId);

            HasRequired(f => f.Category)
                .WithMany(c => c.Folders)
                .HasForeignKey(f => f.Category.CategoryId);
        }
    }
}
