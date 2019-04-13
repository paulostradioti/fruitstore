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

            return receipt;
        }
    }
}
