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

        public int Create() 
        {
            RegionData selectedRegion;
            try {
                selectedRegion = regions.Single(x => x.Name == region);   
            } catch (Exception) {
                Console.WriteLine($"Error: Input {region} matches no regions");
                return 1;
            }

            for (int i = 0; i < maxAdventures; i++)
            {
                adventures.Add(GenerateAdventure(selectedRegion));
            }
            SerializeAdventures(selectedRegion.Name);
            return 0;
        }

        private void SerializeAdventures(string region)
        {
            var outputTemplate = new AdventureOutput(adventures);
            var output = outputTemplate.TransformText();
            var filename = "dungeons_in_" + region + System.IO.Path.GetRandomFileName()+".html";
            System.IO.File.WriteAllText(filename, output);
        }

        private AdventureData GenerateAdventure(RegionData selectedRegion)
        {
            var adventure = new AdventureData
            {
                Region = selectedRegion.Name
            };
            var randomType = selectedRegion.GetRandomLocationType();
            LocationData type = new LocationData();
            try {
                type = locations.First(x => x.Name == randomType);
            } catch (InvalidOperationException)
            {
                Console.WriteLine($"Location Type {randomType} not found.");
                Environment.Exit(1);
            }
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
