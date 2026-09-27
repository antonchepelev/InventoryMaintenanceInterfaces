using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMaintenance
{
    public class InvItemList
    {
        private List<InvItem> invItems;

        public delegate void ChangeHandler(InvItemList invItems);
        public event ChangeHandler Changed;

        // Anton Chepelev
        public InvItemList()
        {
            invItems = new List<InvItem>();
        }

        public int Count => invItems.Count;

        public InvItem this[int i]
        {
            get
            {
                if (i < 0)
                {
                    throw new ArgumentOutOfRangeException(i.ToString());
                }
                else if (i > invItems.Count)
                {
                    throw new ArgumentOutOfRangeException(i.ToString());
                }
                return invItems[i];
            }
            set
            {
                invItems[i] = value;
                Changed(this);
            }
        }

        // Anton Chepelev
        public void Add(InvItem invItem)
        {
            invItems.Add(invItem);
            Changed(this);
        }

        // Anton Chepelev
        public void Add(int itemNo, string description, decimal price)
        {
            InvItem i = new InvItem(itemNo, description, price);
            invItems.Add(i);
            Changed(this);
        }

        // Anton Chepelev
        public void Remove(InvItem invItem)
        {
            invItems.Remove(invItem);
            Changed(this);
        }

        public static InvItemList operator +(InvItemList il, InvItem i)
        {
            il.Add(i);
            return il;
        }

        public static InvItemList operator -(InvItemList il, InvItem i)
        {
            il.Remove(i);
            return il;
        }

        // Anton Chepelev
        public void Fill() => invItems = InvItemDB.GetItems();

        // Anton Chepelev
        public void Save() => InvItemDB.SaveItems(invItems);
    }
}
