using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace Service.Interface
{
    public interface IDoubleParser
    {
        Result<List<double>> GetDoubles();
    }
}