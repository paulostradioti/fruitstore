using System;
using System.Text;
using Asaitec.FruitShop.Core;

namespace Asaitec.FruitShop.App
{
    class Program
    {

        static void Main(string[] args)
        {
            // The app expects 2 parameters, first is the path to the file containing products and prices list.
            // The second parameter is the path to the order file.
            bool validParameters = true;

            if (args.Length != 2) validParameters = false;

            if (validParameters &&  (string.IsNullOrWhiteSpace(args[0]) ||
                                     string.IsNullOrWhiteSpace(args[1])))
                validParameters = false;

            if (!System.IO.File.Exists(args[0]) || !System.IO.File.Exists(args[0]))
                validParameters = false;

            if (!validParameters)
            {
                Console.WriteLine("Syntax: {0} {1} {2}", $"{AppDomain.CurrentDomain.FriendlyName}.exe",
                    "<path to an existing products file>", "<path to an existing order file>");

                return;
            }

            var productsFile = args[0];
            var orderFile = args[1];

            var shop = new Shop();

            shop.LoadProducts(productsFile);

            var receipt = shop.ProcessOrder(orderFile);

        }
    }
}
