using System.Collections.Generic;


namespace FileBrowser.Model.Repositories {
    public interface ICategoryRepository {

        void Add(Category category);
        IEnumerable<Category> FindAll();

        void SaveChanges();
    }
}
