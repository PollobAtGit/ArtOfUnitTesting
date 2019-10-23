using System.Collections.Generic;

namespace Service.Interface
{
    public interface IFileReader
    {
        List<string> GetAllLines(string fileWithOutPath);
    }
}