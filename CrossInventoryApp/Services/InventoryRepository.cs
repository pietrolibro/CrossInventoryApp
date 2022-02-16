using CrossInventoryApp.Models;
using CrossInventoryApp.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Text;

namespace CrossInventoryApp.Services
{
    public interface IInventoryRepository
    {
        IList<InventoryItem> Items { get; }

        void Add(InventoryItem item);
        void Update(InventoryItem item);
        void Delete(InventoryItem item);

    }

    public class InventoryRepository : IInventoryRepository
    {
        /*
         * Implementation of a "real" repository is out of scope of this meetup\talk, so i just returning a list of inventoried items
         * without using any kind of database service.
         */

        private readonly List<InventoryItem> _items;

        public InventoryRepository()
        {
            this._items = new List<InventoryItem>
            {
                new InventoryItem()
                {
                    Code="Item#001",
                    Description="Orange Juice, sugar free",
                    ActualQuantity=10,
                    LastInventoryUpdate=new DateTime(2021,10,13)
                },
                new InventoryItem()
                {
                    Code="Item#002",
                    Description="Mobile Phone of a good brand",
                    ActualQuantity=8,
                    LastInventoryUpdate=new DateTime(2021,12,31)
                },
                new InventoryItem()
                {
                    Code="Item#003",
                    Description="Chocolate in box",
                    ActualQuantity=-10,
                    LastInventoryUpdate=new DateTime(2021,11,23)
                },
            };
        }

        public IList<InventoryItem> Items { get { return _items; } }

        public void Add(InventoryItem item)
        {
            if (item != null) _items.Add(item);
        }

        public void Delete(InventoryItem item)
        {
            var itemToRemove = _items.Where(i => i.Code.Equals(item.Code)).FirstOrDefault();
            if (itemToRemove != null) _items.Remove(itemToRemove);
        }

        public void Update(InventoryItem item)
        {
            var itemToUpdate = _items.Where(i => i.Code.Equals(item.Code)).FirstOrDefault();
            if (itemToUpdate != null)
            {
                itemToUpdate.Deleted = item.Deleted;
                itemToUpdate.Description = item.Description;
                itemToUpdate.ActualQuantity = item.ActualQuantity;
                itemToUpdate.LastInventoryUpdate =item.LastInventoryUpdate;
            }
        }
    }
}