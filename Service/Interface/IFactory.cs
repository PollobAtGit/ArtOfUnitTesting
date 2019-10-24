namespace Service.Interface
{
    public interface IFactory<out T>
    {
        T Instance { get; }
    }
}