using System.Collections.Generic;

namespace Asaitec.FruitShop.Core.Services.Loaders.Interfaces
{
    public interface IProductLoader
    {
        IEnumerable<KeyValuePair<string, decimal>> LoadFromFile(string productsFile);
    }
}