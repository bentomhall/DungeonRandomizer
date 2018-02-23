using System.Collections.Generic;
using System.Linq;

namespace DungeonRandomizer
{
    public class RegionData
    {
        public string Name { get; set; }
        public string Tier { get; set; }
        public IList<NamedRange> Monsters { get; set; }
        public IList<CityData> Cities { get; set; }
        public float AdventuresPerHex { get; set; }
        public IList<string> LocationTypes { get; set; }

        public string GetRandomMonster(double r)
        {
            return Monsters.First(x => x.Matches(r)).Name;
        }




    }
}