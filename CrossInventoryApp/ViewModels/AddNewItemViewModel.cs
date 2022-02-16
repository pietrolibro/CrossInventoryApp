using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Text;

using CrossInventoryApp.Models;

namespace CrossInventoryApp.ViewModels
{
    public class AddNewItemViewModel : ViewModelBase
    {
        public int _quantity = 1;
        public string _code = "";
        public string _description = "";
        public DateTime _inventoryDate = DateTime.Now;

        public ReactiveCommand<Unit, InventoryItem> SaveNewItemCommand { get; }
        public ReactiveCommand<Unit, InventoryItem> CancelNewItemCommand { get; }

        public AddNewItemViewModel()
        {
            SaveNewItemCommand = ReactiveCommand.Create(this.SaveNewItem);
            CancelNewItemCommand = ReactiveCommand.Create(this.CancelNewItem);
        }

        public string Code
        {
            get => _code;
            private set => this.RaiseAndSetIfChanged(ref _code, value);
        }

        public string Description
        {
            get => _description;
            private set => this.RaiseAndSetIfChanged(ref _description, value);
        }

        public int Quantity
        {
            get => _quantity;
            private set => this.RaiseAndSetIfChanged(ref _quantity, value);
        }

        public DateTime InventoryDate
        {
            get => _inventoryDate;
            private set => this.RaiseAndSetIfChanged(ref _inventoryDate, value);
        }

        public InventoryItem SaveNewItem()
        {
            return new InventoryItem()
            {
                Code = this.Code,
                Description = this.Description,
                ActualQuantity = this.Quantity,
                LastInventoryUpdate = this.InventoryDate
            };
        }

        public InventoryItem CancelNewItem()
        {
            /* nothing to do here */
            return null;
        }

    }
}
