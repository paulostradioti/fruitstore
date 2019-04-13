using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Asaitec.FruitShop.Core.Entities;

namespace Asaitec.FruitShop.Core.Services.Receipt
{

    /// ---------------------
    ///      FRUIT SHOP 
    /// ---------------------
    /// PRODUCT   QTY     TTL
    /// ORANGE    5      5 EUR
    ///
    /// DISCOUNTS
    /// ORANGE    1     -1 EUR
    ///
    /// TOTAL            4 EUR

    class ReceiptGenerator : IReceiptGenerator
    {
        public string GenerateFromOrder(IEnumerable<KeyValuePair<string, int>> order,
            IEnumerable<KeyValuePair<string, decimal>> products)
        {
            var orderSummary = new OrderSummary();

            var productList = products.ToDictionary(v => v.Key, v => v.Value);

            var validItemsOnly = order.Where(listItem => products.Any(product => product.Key.Equals(listItem.Key)));

            foreach (var entry in validItemsOnly)
            {
                var productName = entry.Key;
                var quantity = entry.Value;
                var productPrice = productList[productName];

                orderSummary.AddItem(productName, quantity, productPrice);
            }

            return orderSummary.ToReceipt();
        }
    }
}
