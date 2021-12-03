using System;
using System.IO;
using MenuPlanner.Console.DataTransferObject;
using Newtonsoft.Json;

namespace MenuPlanner.Console
{
    public class Runner
    {
        public static void Main(string[] args)
        {
            var content = File.ReadAllText("./Data/Modified/2627-mod.json");

            try
            {
                var root = JsonConvert.DeserializeObject<RootDto>(content);

                System.Console.WriteLine(JsonConvert.SerializeObject(root, Formatting.Indented));
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }

            System.Console.WriteLine();
        }
    }
}
