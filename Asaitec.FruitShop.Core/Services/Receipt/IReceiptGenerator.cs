using System.Collections.Generic;

namespace Asaitec.FruitShop.Core.Services.Receipt
{
    internal interface IReceiptGenerator
    {
        string GenerateFromOrder(IEnumerable<KeyValuePair<string, int>> order, IEnumerable<KeyValuePair<string, decimal>> products);
    }
}