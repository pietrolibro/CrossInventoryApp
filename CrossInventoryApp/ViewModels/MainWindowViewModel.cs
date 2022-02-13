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
        ViewModelBase _content;

        public ReactiveCommand<Unit, Unit> OpenCloseAppWindowCommand { get; }
        public ReactiveCommand<Unit, Unit> SearchItemCommand { get; }
        public ReactiveCommand<Unit, Unit> ListItemsCommand { get; }
        public ReactiveCommand<Unit, Unit> AddNewItemCommand { get; }

        public MainMenuViewModel MainMenu { get; }

        public MainWindowViewModel()
        {
            Content = MainMenu = new MainMenuViewModel();

            OpenCloseAppWindowCommand = ReactiveCommand.Create(this.OpenCloseAppWindow);
        }

        public ViewModelBase Content
        {
            get => _content;
            private set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public void OpenCloseAppWindow()
        {
            var vm = new CloseAppViewModel();


            vm.CloseCommand.Subscribe(o =>
            {
                Environment.Exit(0);
            });
            
            vm.CancelCommand.Subscribe(o =>
            {
                Content = MainMenu;
            });


            Content = vm;
        }

        public void SearchItem()
        {

        }

        public void ListItems()
        {

        }

        public void AddNewItem()
        {

        }
    }
}
