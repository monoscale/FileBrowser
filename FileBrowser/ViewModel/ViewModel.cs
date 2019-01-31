using System.ComponentModel;
using System.Runtime.CompilerServices;
using FileBrowser.Annotations;

namespace FileBrowser.ViewModel {
    public class ViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
