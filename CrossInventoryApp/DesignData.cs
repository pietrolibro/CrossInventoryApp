using System;
using System.Collections.Generic;
using System.Text;

namespace CrossInventoryApp
{
    public static class DesignData
    {
        public static ViewModels.MainViewModel MainViewModel { get; } = new ViewModels.MainViewModel()
        {
            // View Model initialization here.
        };

        public static ViewModels.MenuViewModel MenuViewModel { get; } = new ViewModels.MenuViewModel()
        {
            // View Model initialization here.
            MainView = new ViewModels.MainViewModel()
        };

        public static ViewModels.ListItemsViewModel ListItemsViewModel { get; } = new ViewModels.ListItemsViewModel()
        {
            // View Model initialization here.
        };

        public static ViewModels.AddNewItemViewModel AddNewItemViewModel { get; } = new ViewModels.AddNewItemViewModel()
        {
            // View Model initialization here.
        };

        public static ViewModels.SearchItemViewModel SearchItemViewModel { get; } = new ViewModels.SearchItemViewModel()
        {
            // View Model initialization here.
        };

        public static ViewModels.CloseAppViewModel CloseAppViewModel { get; } = new ViewModels.CloseAppViewModel()
        {
            // View Model initialization here.
        };

        public static ViewModels.MainWindowViewModel MainWindowViewModel { get; } = new ViewModels.MainWindowViewModel()
        {
            // View Model initialization here.
        };

    }
}
