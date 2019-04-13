using System;
using System.Collections.Generic;
using System.Text;

namespace Asaitec.FruitShop.Core.Entities
{
    public class OrderEntry
    {
        public OrderEntry(string productName, int quantity, decimal productPrice)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = productPrice;
        }

        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
