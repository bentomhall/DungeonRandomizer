namespace DungeonRandomizer
{
    public class NamedRange
    {
        public string Name { get; set; }
        public double Start { get; set; }
        public double Stop { get; set; }

        public bool Matches(double x) 
        {
            return (x >= Start && x < Stop);    
        }
    }
}