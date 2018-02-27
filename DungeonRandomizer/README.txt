Documentation for JSON data files:

File: dungeon_data.json
Description: This contains the types of adventure locations and their information.
Format:
[
    {
        "Name": string //the type of location
        "Scale": string //this indicates the overall size of the adventure location--
                        //"large" sites have areas scaled in tens of miles
                        //"medium" sites have areas scaled in miles or thousands of feet
                        //"small" sites have room-size areas (tens or hundreds of feet)
        "Sizes": [int] //this indicates how many discrete areas are present.
                       //I'd recommend not going above about 5 (a 5-room dungeon)
                       //bigger ones should have multiple locations.
        "Subtypes": [string] //a list of subtypes that share a common location theme 
                            //(wilderness has forests and mountains, for example)
        "Ages": [string] //how old the adventure location (or the interesting parts anyway)
                         //can be. I recommend using "ancient", "old", and "recent"
        "HasBoss": float //the decimal percent chance that there's a "boss" monster present (0 < x < 1)
        "LairChance": {string : float} // keys are the tier of adventure (I use half-integers to represent marginal cases)
                                       // values are the decimal percent chance that the entrance to a lair is present.
        "HasSublocations": bool // can this site have smaller sites embedded in it (usually for large-scale sites)
    }
]

File: region_data.json
Description: Contains the map regions and information about monsters and adventure location types present.
Format: 
[
    {
        "Name": string //the region name. Will be used to create adventures.
        "Tier": string //the level range of the area:
                       // "1"  : 1-4
                       // "1.5": 3-7
                       // "2": 5-10
                       // "2.5": 8-13
                       // "3": 11-16
                       // "3.5": 14-18
                       // "4": 17-20
        "Monsters": [NamedRange] // see NamedRange; this has the main hostile groups that are the "owners" of the adventuring sites
        "AdventuresPerHex": float //currently unused, how many sites are expected per macrohex (~30 miles across)
        "AdventureTypes": [string] //these must match values found in dungeon_data.json *exactly*
    }
]

NamedRange: Represents a range of random results (like a percentile table row)
{
    "Name": string //the row name
    "Start": 0.0 <= float < "Stop"
    "Stop": "Start" < float <= 1.0 //Stop - Start = probabilty of occurence.
}