using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;
using Service.Interface;

namespace Service.Implementation
{
    public class DoubleParser : IDoubleParser
    {
        private const string FileToRead = "doubles-to-parse.txt";

        public Result<List<double>> GetDoubles()
        {
            try
            {
                var parsedIntegers = GetReader()
                    .GetAllLines(FileToRead)
                    .Select(x => double.TryParse((string) x, out var i) ? i : (double?)null)
                    .Where(x => x.HasValue)
                    .Select(x => x.Value)
                    .ToList();

                return !parsedIntegers.Any()
                    ? Result.Failure<List<double>>($"There's no valid doubles in file: {FileToRead}")
                    : Result.Ok(parsedIntegers);
            }
            catch (Exception e)
            {
                return Result.Failure<List<double>>($"Failed to get & parse list of numbers. Reason: {e.Message}");
            }
        }

        protected virtual IFileReader GetReader() => new FileReader();
    }
}