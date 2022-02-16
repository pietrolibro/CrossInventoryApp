using System;
using System.Collections.Generic;
using System.Text;

namespace CrossInventoryApp.Models
{
    public  class InventoryItem
    {
        public bool Deleted { get; set; }
        public string Code { get; set; } = "";
        public string Description { get; set; } = "";
        public int ActualQuantity { get; set; } = 0;        
        public DateTime? LastInventoryUpdate { get; set; }= DateTime.Now;
    }
}
