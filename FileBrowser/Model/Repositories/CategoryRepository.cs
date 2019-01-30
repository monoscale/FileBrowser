using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FileBrowser.Model.DAL;

namespace FileBrowser.Model.Repositories {
    public class CategoryRepository : ICategoryRepository {

        private readonly FileBrowserContext context;

        public CategoryRepository(FileBrowserContext context) {
            this.context = context;
        }

        public void Add(Category category) {
            context.Categories.Add(category);
        }

        public IEnumerable<Category> FindAll() {
            return context.Categories.Include(c => c.Folders).Include(c => c.Extensions).ToList();
        }

        public void SaveChanges() {
            context.SaveChanges();
        }
    }
}
