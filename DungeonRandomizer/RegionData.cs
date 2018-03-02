using System.Collections.Generic;
using System.Linq;
using System;

namespace DungeonRandomizer
{
    public class RegionData
    {
        public string Name { get; set; }
        public string Tier { get; set; }
        public Dictionary<string, double> Monsters { get; set; }
        public float AdventuresPerHex { get; set; }
        public List<string> AdventureTypes { get; set; }

        private WeightedChoiceSet monsters;

        public string GetRandomMonster(double r)
        {
            if (monsters == null)
            {
                monsters = new WeightedChoiceSet(Monsters);
            }
            return monsters.Match(r);
        }

        public string GetRandomLocationType()
        {
            var index = r.Next(0, AdventureTypes.Count);
            return AdventureTypes[index];
        }

        private readonly Random r = new Random();


    }
}