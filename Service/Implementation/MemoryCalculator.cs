using Service.Interface;

namespace Service.Implementation
{
    public class MemoryCalculator : IMemoryCalculator
    {
        public int Value { get; private set; }

        public void Add(int num)
        {
            Value += num;
        }
    }
}
