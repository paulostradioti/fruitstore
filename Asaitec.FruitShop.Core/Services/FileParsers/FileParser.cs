using Asaitec.FruitShop.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Asaitec.FruitShop.Core.Services.FileParsers
{
    public class FileParser : IFileParser
    {
        private readonly TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;
        private readonly IFileWrapper _fileWrapper;

        public FileParser()
        {
            _fileWrapper = new FileWrapper(); // replace with Dependency Injection
        }

        public IEnumerable<Tuple<string, string>> Parse(string path)
        {
            var returnValue = new List<Tuple<string, string>>();
            try
            {

                if (!_fileWrapper.Exists(path))
                {
                    Console.WriteLine($"The specified file [{path}] doesn't exist."); //TODO Replace with proper logging
                    return returnValue;
                }

                var fileContent = _fileWrapper.ReadAllLines(path); // Assuming that the files are not too big.

                foreach (var line in fileContent)
                {
                    var parsedLine = line?.Split(",");

                    if (parsedLine == null || parsedLine.Length != 2) continue; //Accepts only entries that contains ","
                    if (string.IsNullOrWhiteSpace(parsedLine[0]) || string.IsNullOrWhiteSpace(parsedLine[1])) continue; //If the entry contains an empty column, skip it.. May be log those skipped entries.

                    var tuple = new Tuple<string, string>(textInfo.ToUpper(parsedLine[0].Trim()), parsedLine[1].Trim());

                    returnValue.Add(tuple);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was a problem parsing the file [{path}]"); //TODO Convert to proper logging
                Console.WriteLine(e);
                throw;
            }

            returnValue.RemoveAll(x => x.Item1.Equals("PRODUCT", StringComparison.InvariantCultureIgnoreCase) ||
                                       x.Item2.Equals("PRICE", StringComparison.InvariantCultureIgnoreCase) ||
                                       x.Item2.Equals("QUANTITY", StringComparison.InvariantCultureIgnoreCase));

            return returnValue;
        }
    }
}
