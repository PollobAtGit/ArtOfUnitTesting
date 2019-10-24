using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Service.Interface;

namespace Service.Implementation
{
    public class IntegerParser : IIntegerParser
    {
        private readonly IFactory<IFileReader> _factory;
        private const string FileToRead = "integers-to-parse.txt";

        public IntegerParser(IFactory<IFileReader> factory)
        {
            _factory = factory;
        }

        public Result<List<int>> GetIntegers()
        {
            try
            {
                var parsedIntegers = _factory.Instance
                    .GetAllLines(FileToRead)
                    .Select(x => int.TryParse(x, out var i) ? i : (int?)null)
                    .Where(x => x.HasValue)
                    .Select(x => x.Value)
                    .ToList();

                return !parsedIntegers.Any()
                    ? Result.Failure<List<int>>($"There's no valid integers in file: {FileToRead}")
                    : Result.Ok(parsedIntegers);
            }
            catch (Exception e)
            {
                return Result.Failure<List<int>>($"Failed to get & parse list of numbers. Reason: {e.Message}");
            }
        }
    }
}