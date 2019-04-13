namespace Asaitec.FruitShop.Core.Wrappers
{
    public interface IFileWrapper
    {
        bool Exists(string path);
        string[] ReadAllLines(string path);
    }
}