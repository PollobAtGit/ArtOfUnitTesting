namespace Explore.Model.Model
{
    public class Path
    {
        public Os Os { get; } = Os.FreeBsd | Os.Linux;

        public string Url { get; set; }
    }
}