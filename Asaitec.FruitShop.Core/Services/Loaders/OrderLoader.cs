using System.Collections.Generic;
using Asaitec.FruitShop.Core.Services.FileParsers;
using Asaitec.FruitShop.Core.Services.Loaders.Interfaces;

namespace Asaitec.FruitShop.Core.Services.Loaders
{
    public class OrderLoader : IOrderLoader
    {
        private readonly IFileParser _fileParser;

        public OrderLoader()
        {
            _fileParser = new FileParser(); //TODO replace with dependency injection
        }

        public IEnumerable<KeyValuePair<string, int>> LoadFromFile(string orderFile)
        {
            var orderItems = new Dictionary<string, int>();
            var fileEntries = _fileParser.Parse(orderFile);

            foreach (var entry in fileEntries)
            {
                if (int.TryParse(entry.Item2, out var quantity))
                {
                    if (orderItems.ContainsKey(entry.Item1))
                        orderItems[entry.Item1] += quantity; // consider the lowest price in the product list.
                    else
                        orderItems.Add(entry.Item1, quantity);
                }
            }

            return orderItems;
        }
    }
}
