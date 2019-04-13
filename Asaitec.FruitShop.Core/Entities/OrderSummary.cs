using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asaitec.FruitShop.Core.Entities
{
    public class OrderSummary
    {
        public List<OrderEntry> Items { get; private set; }

        public OrderSummary()
        {
            Items = new List<OrderEntry>();
        }
        //TODO move to extension method
        public string ToReceipt()
        {
            var receiptText = new StringBuilder();

            AddHeader(receiptText);

            Items.ToList().ForEach(item =>
            {
                var line =
                    $"{item.ProductName.PadRight(10)}{item.Quantity.ToString().PadLeft(10)}{(item.Quantity * item.Price).ToString().PadLeft(10)}";

                receiptText.AppendLine(line);
            });

            return receiptText.ToString();
        }

        private void AddHeader(StringBuilder receiptText)
        {
            var header = string.Empty.PadLeft(30, '-');
            receiptText.AppendLine(header);
            receiptText.AppendLine("Fruit Store"); //TODO padright
            receiptText.AppendLine(header);
        }

        public void AddItem(string productName, int quantity, decimal productPrice)
        {
            Items.Add(new OrderEntry(productName, quantity, productPrice));
        }
    }
}
