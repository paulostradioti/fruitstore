using System.Collections.Generic;

namespace Asaitec.FruitShop.Core.Entities
{
    public class Order
    {
        public Dictionary<string, int> OrderItems { get; private set; }
    }
}
