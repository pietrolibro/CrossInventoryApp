using CrossInventoryApp.Services;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;

namespace CrossInventoryApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _content;
        private readonly ServiceProvider _serviceProvider = null;
        private readonly IInventoryRepository _inventoryRepository = null;

        public ReactiveCommand<Unit, Unit> OpenCloseAppWindowCommand { get; }
        public ReactiveCommand<Unit, Unit> SearchItemCommand { get; }
        public ReactiveCommand<Unit, Unit> ListItemsCommand { get; }
        public ReactiveCommand<Unit, Unit> AddNewItemCommand { get; }

        public MainMenuViewModel MainMenu { get; }

        public MainWindowViewModel()
        {
        }

        public MainWindowViewModel(IServiceCollection serviceCollection)
        {
            _serviceProvider = serviceCollection.BuildServiceProvider();
            _inventoryRepository = _serviceProvider.GetService<IInventoryRepository>();

            Content = MainMenu = new MainMenuViewModel();

            OpenCloseAppWindowCommand = ReactiveCommand.Create(this.OpenCloseAppWindow);
            AddNewItemCommand = ReactiveCommand.Create(this.AddNewItem);
            ListItemsCommand = ReactiveCommand.Create(this.ListItems);
        }

        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public void OpenCloseAppWindow()
        {
            var vm = new CloseAppViewModel();

            vm.CloseCommand.Subscribe(o => { Environment.Exit(0); });
            vm.CancelCommand.Subscribe(o => { Content = MainMenu; });

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

                Content = MainMenu;
            });

            vm.CancelUpdateCommand.Subscribe(o => { Content = MainMenu; });

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
                Content = MainMenu;
            });

            vm.CancelNewItemCommand.Subscribe(_ => { Content = MainMenu; });

            Content = vm;
        }
    }
}
