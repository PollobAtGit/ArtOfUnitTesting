namespace Service.Interface
{
    public interface ILogFileAnalyzer
    {
        void ValidateFile(string file);

        bool WasLastFileValid { get; set; }
    }
}