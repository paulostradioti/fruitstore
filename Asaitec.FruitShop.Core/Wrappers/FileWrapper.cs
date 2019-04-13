using System;
using System.Collections.Generic;
using System.Text;

namespace Asaitec.FruitShop.Core.Wrappers
{

    /// <summary>
    /// This is a Wrapper to the File class in the namespace System.IO.
    /// This can be used as an abstraction to facilitate Unit Testing. 
    /// </summary>
    public class FileWrapper : IFileWrapper
    {
        public bool Exists(string path)
        {
            return System.IO.File.Exists(path);
        }

        public string[] ReadAllLines(string path)
        {
            return System.IO.File.ReadAllLines(path);
        }
    }
}
