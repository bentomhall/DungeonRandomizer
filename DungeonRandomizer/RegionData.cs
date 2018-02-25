using System.Collections.Generic;
using System.Linq;
using System;

namespace DungeonRandomizer
{
    public class RegionData
    {
        public string Name { get; set; }
        public string Tier { get; set; }
        public List<NamedRange> Monsters { get; set; }
        public float AdventuresPerHex { get; set; }
        public List<string> AdventureTypes { get; set; }

        public string GetRandomMonster(double r)
        {
            return Monsters.First(x => x.Matches(r)).Name;
        }

        public string GetRandomLocationType()
        {
            var index = r.Next(0, AdventureTypes.Count);
            return AdventureTypes[index];
        }

        private readonly Random r = new Random();


    }
}