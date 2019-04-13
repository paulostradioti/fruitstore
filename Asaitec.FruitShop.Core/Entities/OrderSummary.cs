using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asaitec.FruitShop.Core.Entities
{
    public class OrderSummary
    {
        public List<OrderEntry> Items { get; private set; }
        
        //TODO move to extension method
        public string ToReceipt()
        {
            var receiptText = new StringBuilder();

            AddHeader(receiptText);

            Items.ToList().ForEach(item =>
            {
                var line =
                    $"{item.ProductName.PadRight(10)}{item.Quantity.ToString().PadLeft(5)}{(item.Quantity * item.Price).ToString().PadLeft(5)}";

                receiptText.AppendLine(line);
            });

            return receiptText.ToString();
        }

        private void AddHeader(StringBuilder receiptText)
        {
            var header = string.Empty.PadLeft(20, '-');
            receiptText.AppendLine(header);
            receiptText.AppendLine("Fruit Store");
            receiptText.AppendLine(header);
        }

        public void AddItem(string productName, int quantity, decimal productPrice)
        {
            Items.Add(new OrderEntry(productName, quantity, productPrice));
        }
    }
}
