using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Service.Interface
{
    public interface IIntegerParser
    {
        Result<List<int>> GetIntegers();
    }
}