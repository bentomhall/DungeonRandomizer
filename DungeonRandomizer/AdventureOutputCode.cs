using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRandomizer
{
    partial class AdventureOutput
    {
        private List<AdventureData> data;
        private string region;

        public AdventureOutput(List<AdventureData> adventures)
        {
            data = adventures;
            region = data[0].Region;
        }
    }
}
