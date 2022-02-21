using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Input;
using System.Linq;
using System.Collections;
using Avalonia.Controls;
using Avalonia.VisualTree;

using CrossInventoryApp.Services;

using Xunit;
using System.Collections.Generic;

using Microsoft.Extensions.DependencyInjection;

namespace CrossInventoryApp.UITests.UseCases
{
    public class DisplayInventoriedItems : IDisposable
    {
        [Fact(DisplayName = "Display Inventoried Items")]
        public async Task TestAddNewInventoryItem()
        {
            var window = AvaloniaApp.GetMainWindow();

            window.Activate();
            await Task.Delay(1000);

            Common.Keyboard.PressKey(window, Key.Tab);
            await Task.Delay(500);

            //Common.Keyboard.PressKey(window, Key.Tab);
            //await Task.Delay(500);

            Common.Keyboard.PressKey(window, Key.Space);
            await Task.Delay(1000);

            // Get the mainViewModel instance.
            var mainViewModel = window.Content as ViewModels.MainViewModel;
            Assert.NotNull(mainViewModel);

            // Get the ListItemsViewModel instance
            var listItemsViewModel = mainViewModel.Content as ViewModels.ListItemsViewModel;
            Assert.NotNull(listItemsViewModel);

            // ViewModel is tested.
            Assert.True(listItemsViewModel.GridCollectionFilteredItems.Count == 3);

            var inventoriedItemsDataGrid = window.GetVisualDescendants()
            .OfType<DataGrid>()
            .Single();

            // UI is tested.
            Assert.NotNull(inventoriedItemsDataGrid);
            Assert.Equal<int>(5, inventoriedItemsDataGrid.Columns.Count);

        }

        public void Dispose()
        {
            var window = AvaloniaApp.GetMainWindow();

            window.Close();

            AvaloniaApp.Stop();
        }
    }
}
