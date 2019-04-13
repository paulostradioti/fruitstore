using System;
using System.Collections.Generic;

namespace Asaitec.FruitShop.Core.Entities
{
    public class OrderSummary
    {
        public List<OrderEntry> Items { get; private set; }


        //TODO move to extension method
        public string ToReceipt()
        {
            throw new NotImplementedException();
        }

        public void AddItem(string productName, int quantity, decimal productPrice)
        {
            Items.Add(new OrderEntry(productName, quantity, productPrice));
        }
    }
}
