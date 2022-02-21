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

namespace CrossInventoryApp.UITests
{
    public class AddNewInventoryItem : IDisposable
    {

        [Fact(DisplayName = "Add New Inventory Item")]
        public async Task TestAddNewInventoryItem()
        {
            int actualQuantity = 10;
            string itemCode = "00001";
            string itemDescription = "Description of item 00001";

            var window = AvaloniaApp.GetMainWindow();

            window.Activate();
            await Task.Delay(500);

            Common.Keyboard.PressKey(window, Key.Tab);
            await Task.Delay(500);

            Common.Keyboard.PressKey(window, Key.Tab);
            await Task.Delay(500);

            Common.Keyboard.PressKey(window, Key.Space);
            await Task.Delay(500);

            // Get the mainViewModel instance.
            var mainViewModel = window.Content as ViewModels.MainViewModel;
            Assert.NotNull(mainViewModel);

            // Get the addNewItemViewModel instance
            var addNewItemViewModel = mainViewModel.Content as ViewModels.AddNewItemViewModel;
            Assert.NotNull(addNewItemViewModel);

            var codeTextBox = window.GetVisualDescendants()
                .OfType<TextBox>()
                .Where(x => x.Name == "codeTextBox")
                .Single();

            var descriptionTextBox = window.GetVisualDescendants()
                .OfType<TextBox>()
                .Where(x => x.Name == "descriptionTextBox")
                .Single();

            var actualQuantityNumericUpDown = window.GetVisualDescendants()
                .OfType<NumericUpDown>()
                .Where(x => x.Name == "actualQuantityNumericUpDown")
                .Single();

            codeTextBox.Text = itemCode;
            descriptionTextBox.Text = itemDescription;
            actualQuantityNumericUpDown.Value = actualQuantity;

            Common.Keyboard.PressKey(window, Key.LeftAlt & Key.S);

            //addNewItemViewModel.SaveNewItemCommand.Execute();

            //await Task.Delay(500);

            //var serviceProvider = (App.Current as CrossInventoryApp.App).ServiceProvider;
            //Assert.NotNull(serviceProvider);

            //var inventoryRepository = serviceProvider.GetService<Services.IInventoryRepository>();

            //var addedItem = inventoryRepository.Items
            //    .Where(i => i.Code.Equals(itemCode))
            //    .SingleOrDefault();

            //Assert.NotNull(addedItem);
            //Assert.Equal(itemDescription, addedItem.Description);
            //Assert.Equal(actualQuantity, addedItem.ActualQuantity);
        }

        public void Dispose()
        {
            var window = AvaloniaApp.GetMainWindow();

            window.Close();

            AvaloniaApp.Stop();
        }
    }


}