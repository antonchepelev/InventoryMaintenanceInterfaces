using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMaintenance
{
    public class Supply : InvItem
    {
        // Anton Chepelev
        public Supply() { }

        // Anton Chepelev
        public Supply(int itemNo, string description, decimal price, string manufacturer) :
            base(itemNo, description, price)
        {
            Manufacturer = manufacturer;
        }

        public string Manufacturer { get; set; }

        // Anton Chepelev
        public override string GetDisplayText() =>
            $"{ItemNo}    {Manufacturer} {Description} ({Price:c})";
    }
}
