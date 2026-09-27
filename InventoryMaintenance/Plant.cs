using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMaintenance
{
    public class Plant : InvItem
    {
        // Anton Chepelev
        public Plant() { }

        // Anton Chepelev
        public Plant(int itemNo, string description, decimal price, string size) :
            base(itemNo, description, price)
        {
            Size = size;
        }

        public string Size { get; set; }

        // Anton Chepelev
        public override string GetDisplayText() => 
            $"{ItemNo}    {Size} {Description} ({Price:c})";
    }
}
