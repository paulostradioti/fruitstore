using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Asaitec.FruitShop.Core.Services;
using Asaitec.FruitShop.Core.Services.Loaders;
using Asaitec.FruitShop.Core.Services.Loaders.Interfaces;
using Asaitec.FruitShop.Core.Services.Receipt;

namespace Asaitec.FruitShop.Core
{
    public class Shop
    {
        public IEnumerable<KeyValuePair<string, decimal>> Products { get; private set; }

        private readonly IProductLoader _productLoader;
        private readonly IOrderLoader _orderLoader;
        private readonly IReceiptGenerator _receiptGenerator;

        public Shop()
        {
            _productLoader = new ProductLoader(); //TODO replace with DI
            _orderLoader = new OrderLoader();
            _receiptGenerator = new ReceiptGenerator();
        }

        public void LoadProducts(string path)
        {
            Products = _productLoader.LoadFromFile(path);
        }

        public string ProcessOrder(string orderFile)
        {
            var orderEntries = _orderLoader.LoadFromFile(orderFile);
            var receipt = _receiptGenerator.GenerateFromOrder(orderEntries, Products);


            LogUnknownItems(orderEntries);

            return receipt;
        }

        private void LogUnknownItems(IEnumerable<KeyValuePair<string, int>> order)
        {
            var itemsNotInShop = order.Where(listItem => !Products.Any(product => product.Key.Equals(listItem.Key)))
                .Select(x => x.Key);

            Console.WriteLine(
                "The following Items were not found in our products catalog and, therefore, will bi disregarded: [{0}]",
                string.Join(", ", itemsNotInShop));
        }
    }
}
