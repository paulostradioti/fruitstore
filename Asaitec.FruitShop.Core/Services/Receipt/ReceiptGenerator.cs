using Asaitec.FruitShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
            LogUnknownItems(order, products);

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

        private void LogUnknownItems(IEnumerable<KeyValuePair<string, int>> order, IEnumerable<KeyValuePair<string, decimal>> products)
        {
            var itemsNotInShop = order.Where(listItem => !products.Any(product => product.Key.Equals(listItem.Key)))
                .Select(x => x.Key);

            Console.WriteLine(
                "The following Items were not found in our products catalog and, therefore, will bi disregarded: [{0}]",
                string.Join(", ", itemsNotInShop));
        }
    }
}
