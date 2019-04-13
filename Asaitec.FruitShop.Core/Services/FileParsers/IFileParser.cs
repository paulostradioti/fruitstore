using System;
using System.Collections.Generic;

namespace Asaitec.FruitShop.Core.Services.FileParsers
{
    public interface IFileParser
    {
        IEnumerable<Tuple<string, string>> Parse(string path);
    }
}