namespace Service.Interface
{
    public interface IMemoryCalculator
    {
        int Value { get; }

        void Add(int num);
    }
}