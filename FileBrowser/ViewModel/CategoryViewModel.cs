using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FileBrowser.Model;
using FileBrowser.Model.Repositories;

namespace FileBrowser.ViewModel {

    public class CategoryViewModel : ViewModel {

        private Category selectedCategory;

        public Category SelectedCategory {
            get => selectedCategory;
            set {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }

        public IEnumerable<Category> Categories { get; set; } 

        private ICategoryRepository repository;

        public CategoryViewModel(ICategoryRepository repository) {
            this.repository = repository;

            Categories = repository.FindAll();
            SelectedCategory = Categories.First();
        }

    }
}
