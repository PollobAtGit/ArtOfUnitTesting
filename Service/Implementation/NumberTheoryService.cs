using Service.Exceptions;
using Service.Interface;

namespace Service.Implementation
{
    public class NumberTheoryService : INumberTheoryService
    {
        public bool IsOdd(int num)
        {
            if (num < 0)
                throw new OutOfRangeException($"{num} is negative. Service can't process negative numbers");

            return num % 2 != 0;
        }
    }
}
