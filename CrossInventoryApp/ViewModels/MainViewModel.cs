using System;
using System.Reactive;
using System.Reactive.Linq;

using CrossInventoryApp.Services;

using ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Globalization;
using Avalonia.Threading;
using CrossInventoryApp.Properties;
using System.Threading.Tasks;

namespace CrossInventoryApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _content = null;

        private readonly MenuViewModel _menuViewModel = null;
        private readonly ServiceProvider _serviceProvider = null;
        private readonly IInventoryRepository _inventoryRepository = null;

        public ReactiveCommand<Unit, Unit> ListItemsCommand { get; }
        public ReactiveCommand<Unit, Unit> AddNewItemCommand { get; }
        public ReactiveCommand<Unit, Unit> SearchItemCommand { get; }
        public ReactiveCommand<Unit, Unit> OpenCloseAppWindowCommand { get; }

        public ReactiveCommand<string, string> ChangeCultureCommand { get; }

        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public MainViewModel()
        {
            Content = _menuViewModel = new MenuViewModel(this);
        }

        public MainViewModel(IServiceCollection collection)
        {
            this._serviceProvider = (App.Current as CrossInventoryApp.App).ServiceProvider; // collection.BuildServiceProvider();
            this._inventoryRepository = this._serviceProvider.GetService<IInventoryRepository>();

            OpenCloseAppWindowCommand = ReactiveCommand.Create(this.OpenCloseAppWindow);
            AddNewItemCommand = ReactiveCommand.Create(this.AddNewItem);
            ListItemsCommand = ReactiveCommand.Create(this.ListItems);
            ChangeCultureCommand = ReactiveCommand.Create<string,string>(this.ChangeCulture);

            //Search = ReactiveCommand.CreateAsyncTask(canSearch, async _ => { return await GetSearchResultFromBing(this.SearchTerm); });
            Content = _menuViewModel = new MenuViewModel(this);
        }

        public void OpenCloseAppWindow()
        {
            var vm = new CloseAppViewModel();

            vm.CloseCommand.Subscribe(o => { Environment.Exit(0); });
            vm.CancelCommand.Subscribe(o => { Content = _menuViewModel; });

            Content = vm;
        }

        public void SearchItem()
        {

        }

        public void ListItems()
        {
            var vm = new ListItemsViewModel(_inventoryRepository?.Items);

            vm.SaveUpdatesCommand.Subscribe(updatedItems =>
            {
                if (_inventoryRepository != null)
                {
                    foreach (var updatedItem in updatedItems)
                    {

                        if (updatedItem.Deleted)
                            _inventoryRepository.Delete(updatedItem);
                        else
                            _inventoryRepository.Update(updatedItem);
                    }
                }

                Content = _menuViewModel;
            });

            vm.CancelUpdateCommand.Subscribe(o => { Content = _menuViewModel; });

            Content = vm;
        }

        public void AddNewItem()
        {
            var vm = new AddNewItemViewModel();

            vm.SaveNewItemCommand.Subscribe(newItem =>
            {
                // Add the item
                _inventoryRepository?.Add(newItem);

                // Back to the Main content
                Content = _menuViewModel;
            });

            vm.CancelNewItemCommand.Subscribe(_ => { Content = _menuViewModel; });

            Content = vm;
        }


        public string ChangeCulture(string languageCode)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(languageCode);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(languageCode);

            Resources.Culture = new CultureInfo(languageCode);

            return languageCode;
        }
    }
}
