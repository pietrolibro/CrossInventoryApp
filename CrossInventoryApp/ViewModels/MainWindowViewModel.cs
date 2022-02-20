using ReactiveUI;
using Microsoft.Extensions.DependencyInjection;

namespace CrossInventoryApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _content = null;

        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public MainWindowViewModel()
        {
            Content = new MainViewModel();
        }

        public MainWindowViewModel(IServiceCollection collection)
        {
            Content = new MainViewModel(collection);
        }
    }
}
