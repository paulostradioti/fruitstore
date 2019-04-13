using System;
using System.Collections.Generic;
using Asaitec.FruitShop.Core.Services.FileParsers;
using Asaitec.FruitShop.Core.Services.Loaders.Interfaces;

namespace Asaitec.FruitShop.Core.Services.Loaders
{
    public class ProductLoader : IProductLoader
    {
        private readonly IFileParser _fileParser;

        public ProductLoader()
        {
            _fileParser = new FileParser(); //TODO replace with dependency injection
        }

        public IEnumerable<KeyValuePair<string, decimal>> LoadFromFile(string productsFile)
        {
            var products = new Dictionary<string, decimal>();
            var fileEntries = _fileParser.Parse(productsFile);

            foreach (var entry in fileEntries)
            {
                if (decimal.TryParse(entry.Item2, out var price))
                {
                    if (products.ContainsKey(entry.Item1)) // product is already in the list?
                        products[entry.Item1] = Math.Min(price, products[entry.Item1]); // consider the lowest price in the product list.
                    else
                        products.Add(entry.Item1, price);
                }
            }

            return products;
        }
    }
}
