using System.Collections.Generic;
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
            return context.Categories;
        }

        public void SaveChanges() {
            context.SaveChanges();
        }
    }
}
