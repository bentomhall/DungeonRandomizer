using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonRandomizer
{
    class Program
    {
        static int Main(string[] args)
        {
            var filename = "region_data.json";
            var regionData = ConfigurationLoader.ParseRegions(filename);
            var region = GetRegionName(regionData);
            var adventures = GetNumber();
            var generator = new Generator(regionData);
            InsertLine();
            Console.WriteLine($"Now generating {adventures} adventure locations for region: {region}");
            var status = generator.Create(region, adventures);
            InsertPause();
            return status;
        }

        static void InsertPause()
        {
            Console.Write("Press Any Key to Continue...");
            Console.ReadLine();
            return;
        }

        static void InsertLine() => Console.WriteLine(new string('-', 30));

        static string GetRegionName(IEnumerable<RegionData> regions)
        {
            var validRegions = regions.Select(x => x.Name);
            Console.WriteLine("Valid regions are:");
            Console.WriteLine(String.Join(Environment.NewLine, validRegions));
            InsertLine();
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
