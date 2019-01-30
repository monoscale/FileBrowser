using System.Collections.Generic;
using System.Linq;
using FileBrowser.Model;
using FileBrowser.Model.Repositories;

namespace FileBrowser.ViewModel {
    public class CategoryViewModel{

 
        public Category SelectedCategory { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        private ICategoryRepository repository;

        public CategoryViewModel(ICategoryRepository repository) {
            this.repository = repository;

            Categories = repository.FindAll();
            SelectedCategory = Categories.First();
        }

    }
}
