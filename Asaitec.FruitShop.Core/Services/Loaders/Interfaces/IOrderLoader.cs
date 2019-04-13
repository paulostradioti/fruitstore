using System.Collections.Generic;

namespace Asaitec.FruitShop.Core.Services.Loaders.Interfaces
{
    public interface IOrderLoader
    {
        IEnumerable<KeyValuePair<string, int>> LoadFromFile(string orderFile);
    }
}