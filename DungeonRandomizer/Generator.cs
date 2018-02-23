using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DungeonRandomizer
{
    public class Generator
    {
        public Generator(string filename, string region, int adventures)
        {
            regions = ConfigurationLoader.ParseRegions(filename).ToList();
            locations = ConfigurationLoader.ParseLocations("dungeon_data.json").ToList();
            this.region = region;
            maxAdventures = adventures;
        }

        public void Create() 
        {
            var selectedRegion = regions.Single(x => x.Name == region);
            for (int i = 0; i < maxAdventures; i++)
            {
                adventures.Add(GenerateAdventure(selectedRegion));
            }
            SerializeAdventures();
        }

        private void SerializeAdventures()
        {
            var json = JsonConvert.SerializeObject(adventures);
            System.IO.File.WriteAllText("dungeons.json", json);
        }

        private AdventureData GenerateAdventure(RegionData selectedRegion)
        {
            var adventure = new AdventureData();
            var randomType = selectedRegion.GetRandomLocationType();
            var type = locations.First(x => x.Name == randomType);
            adventure.AdventureType = type.Name;
            adventure.Level = GetRandomLevel(selectedRegion.Tier);
            adventure.PrimaryMonster = selectedRegion.GetRandomMonster(r.NextDouble());
            adventure.Scale = type.Scale;
            adventure.Size = type.GetSize();
            adventure.HasBoss = type.GetBoss();
            adventure.SubType = type.GetSubtype();
            return adventure;
        }

        private int GetRandomLevel(string tier)
        {
            var tierLevels = tierMap[tier];
            return r.Next(tierLevels[0], tierLevels[1]+1);
        }

        private string GetRandomFromList(List<string> list) 
        {
            var index = r.Next(list.Count());
            return list[index];
        }

        private List<RegionData> regions = new List<RegionData>();
        private string region;
        private int maxAdventures;
        private List<AdventureData> adventures = new List<AdventureData>();
        private List<LocationData> locations = new List<LocationData>();
        private Dictionary<string, List<int>> tierMap = new Dictionary<string, List<int>>()
        {
            {"1", new List<int>() {1, 4}},
            {"1.5", new List<int>(){3, 7}},
            {"2", new List<int>() {5, 11}},
            {"2.5", new List<int>() {8, 13}},
            {"3", new List<int>() {12, 16}},
            {"3.5", new List<int>() {14, 18}},
            {"4", new List<int>() {17,20}}
        };
        private Random r = new Random();
    }
}
