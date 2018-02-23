using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace DungeonRandomizer
{

    public static class ConfigurationLoader
    {
        public static IEnumerable<RegionData> ParseRegions(string filename)
        {
            var data = System.IO.File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<IEnumerable<RegionData>>(data);
        }

        public static IEnumerable<LocationData> ParseLocations(string filename)
        {
            var data = System.IO.File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<IEnumerable<LocationData>>(data);
        }
    }
}
