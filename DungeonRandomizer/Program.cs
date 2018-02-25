using System;

namespace DungeonRandomizer
{
    class Program
    {
        static int Main(string[] args)
        {
            var f = GetDataFile();
            var filename = f != "" ? f : "region_data.json";
            var region = GetRegionName();
            var adventures = GetNumber();
            var generator = new Generator(filename, region, adventures);
            var status = generator.Create();
            InsertPause();
            return status;
        }

        static void InsertPause()
        {
            Console.Write("Press Any Key to Continue...");
            Console.ReadLine();
            return;
        }

        static string GetDataFile()
        {
            Console.Write("Filename (.json) that contains the region data: ");
            return Console.ReadLine();
        }

        static string GetRegionName()
        {
            Console.Write("Region to generate locations for: ");
            return Console.ReadLine();
        }

        static int GetNumber()
        {
            Console.Write("Number of adventures to generate: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            } else
            {
                return 1;
            }
        }
    }
}
