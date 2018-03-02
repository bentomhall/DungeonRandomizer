using System.Collections.Generic;
using System.Linq;
namespace DungeonRandomizer
{
    public class WeightedChoiceSet
    {
        public WeightedChoiceSet(Dictionary<string, double> input)
        {
            var currentSum = 0.0;
            foreach (var kvp in input)
            {
                currentSum += kvp.Value;
                table[kvp.Key] = currentSum;
            }
        }

        public int Count => table.Count();

        public string Match(double r)
        {

            return table.First(x => x.Value >= r).Key;
        }

        private Dictionary<string, double> table = new Dictionary<string, double>();
    }
}