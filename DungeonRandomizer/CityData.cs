using System.Collections.Generic;

namespace DungeonRandomizer
{
    public class CityData
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public Dictionary<string, float> Races { get; set; }
        public int Tech { get; set; }
    }
}