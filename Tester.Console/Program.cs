using System.Threading.Tasks;

namespace Tester.Console
{
    public class Program
    {
        public static void Main()
        {
            Do();
            System.Console.WriteLine("outside Do");
            System.Console.ReadLine();
        }

        private static async Task Do()
        {

            System.Console.WriteLine("inside Do: 1");
            await WaitAsync().ConfigureAwait(false);
            System.Console.WriteLine("done with Do: 2");
        }

        private static async Task WaitAsync() => await Task.Delay(5000);
    }
}
