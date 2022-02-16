using System.Linq;
using System.Reactive;
using System.Collections.Generic;
using System.Collections.ObjectModel;


using CrossInventoryApp.Models;
using ReactiveUI;

using Avalonia.Collections;
using System;

namespace CrossInventoryApp.ViewModels
{
    public class ListItemsViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> CancelUpdateCommand { get; }
        public ReactiveCommand<InventoryItem, Unit> DeleteItemCommand { get; }
        public ReactiveCommand<Unit, IEnumerable<InventoryItem>> SaveUpdatesCommand { get; }

        public DataGridCollectionView GridCollectionFilteredItems { get; }
        public ObservableCollection<InventoryItem> ObservalbeItems { get; }

        public ListItemsViewModel(IList<InventoryItem> items)
        {
            // It's an example, we know that we are loading just a bunch of items.
            // In a real scenario is not a good practice.
            this.ObservalbeItems = new ObservableCollection<InventoryItem>(items.Clone());
            this.GridCollectionFilteredItems = new DataGridCollectionView(this.ObservalbeItems);
            this.GridCollectionFilteredItems.Filter = o => !((InventoryItem)o).Deleted;

            SaveUpdatesCommand = ReactiveCommand.Create(() => { return this.ObservalbeItems.Select(i => i); });

            DeleteItemCommand = ReactiveCommand.Create<InventoryItem>(this.DeleteItem);

            CancelUpdateCommand = ReactiveCommand.Create(() => { /* nothing to do here */ });
        }

        private void DeleteItem(InventoryItem item)
        {
            // Commit the changes before refresh the filtered view.
            if (GridCollectionFilteredItems.IsAddingNew) GridCollectionFilteredItems.CommitNew();
            if (GridCollectionFilteredItems.IsEditingItem) GridCollectionFilteredItems.CommitEdit();

            // Mark the original item as deleted
            item.Deleted = true;
            // Refresh the filtered collection to update the UI accordingly.
            this.GridCollectionFilteredItems.Refresh();

        }
    }

    public static class HelperExts
    {
        public static IEnumerable<InventoryItem> Clone(this IList<InventoryItem> items)
        {
            IList<InventoryItem> clonedItems = new List<InventoryItem>();

            if (items == null || items.Count() == 0) return clonedItems;

            foreach (var sourceItem in items)
            {
                clonedItems.Add(new InventoryItem()
                {
                    Code = sourceItem.Code,
                    Deleted = sourceItem.Deleted,
                    Description = sourceItem.Description,
                    ActualQuantity = sourceItem.ActualQuantity,
                    LastInventoryUpdate = sourceItem.LastInventoryUpdate
                });
            }

            return clonedItems;
        }
    }

}
