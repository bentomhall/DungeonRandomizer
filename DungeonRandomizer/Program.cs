using System;

namespace DungeonRandomizer
{
    class Program
    {
        static int Main(string[] args)
        {
            /*
            if (args.Length != 3) {
                Console.WriteLine("Please give the file name for the region data file.");
                Console.WriteLine("Please supply the name of a region.");
                Console.WriteLine("Please specify the number of locations to generate.");
                return 1;
            }*/
            var filename = "region_data.json";//args[0];
            var region = "Frozen Coast";//args[1];
            //var success = int.TryParse(args[2], out int adventures);
            var success = true;
            var adventures = 1;
            if (!success || adventures < 1) 
            {
                Console.WriteLine("Last parameter is not an integer; must specify at least one adventure");
                return 1;
            }
            var generator = new Generator(filename, region, adventures);
            generator.Create();
            return 0;
        }

    }
}
