using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Service.Interface;

namespace Service.Implementation
{
    public class FileReader : IFileReader
    {
        public List<string> GetAllLines(string fileWithOutPath)
        {
            var configurationFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileWithOutPath);
            return File.ReadAllLines(configurationFile).ToList();
        }
    }
}