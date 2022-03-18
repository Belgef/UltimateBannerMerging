using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace UltimateBannerMerging
{
    internal class BannerConfig : ModConfig
    {
        [Range(1, 100)]
        [DefaultValue(18)]
        [Label("Banner Cap")]
        [Tooltip("Minimal number of simple banners needed to reach maximal effects")]
        public int InvulnerabilityCap;
        [Range(1f, 100f)]
        [DefaultValue("4")]
        [Label("Max Damage Multiplier")]
        public int MaxDamageIncrease;
        [Range(1f, 100f)]
        [DefaultValue("5")]
        [Label("Max Drop Multiplier")]
        public int DropMaxMultiplier;
        [Range(1, 100)]
        [DefaultValue(18)]
        [Label("Trophy Cap")]
        [Tooltip("Minimal number of simple trophies needed to reach maximal effects")]
        public int BossInvulnerabilityCap;
        [Range(1f, 100f)]
        [DefaultValue("4")]
        [Label("Max Boss Damage Multiplier")]
        public int MaxBossDamageIncrease;
        [Range(1f, 100f)]
        [DefaultValue("5")]
        [Label("Max Boss Drop Multiplier")]
        public int DropMaxBossMultiplier;

        [JsonIgnore]
        public Dictionary<string, ItemInfo> BannerStats => new Dictionary<string, ItemInfo>()
        {
            { "Forest",                 new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Rain",                   new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Desert",                 new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Snow",                   new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Basic",                  new ItemInfo(){ Price =  10000, Multiplyer = 2.0f } },//6
            { "Ocean",                  new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Jungle",                 new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Corrupted",              new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Crimson",                new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Moderate",               new ItemInfo(){ Price =  30000, Multiplyer = 2.0f } },//12 6
            { "Underground Jungle",     new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Underground Desert",     new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Glowing Mushroom",       new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Cavern",                 new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Underground",            new ItemInfo(){ Price =  20000, Multiplyer = 1.5f } },//4.5
            { "Blood Moon",             new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Advanced",               new ItemInfo(){ Price =  50000, Multiplyer = 2.0f } },//24 12 9 6
            { "Dungeon",                new ItemInfo(){ Price =  20000, Multiplyer = 3.0f } },
            { "Goblin Army",            new ItemInfo(){ Price =  20000, Multiplyer = 3.0f } },
            { "Underworld",             new ItemInfo(){ Price =  20000, Multiplyer = 3.0f } },
            { "Professional",           new ItemInfo(){ Price =  80000, Multiplyer = 1.5f } },//36 18 13.5 9 4.5
            { "Hardmode Surface",       new ItemInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Hardmode Cavern",        new ItemInfo(){ Price =  30000, Multiplyer = 1.0f } },
            { "Hardmode Underground",   new ItemInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Hardmode Corrupted",     new ItemInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Hardmode Crimson",       new ItemInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Hallow",                 new ItemInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Master",                 new ItemInfo(){ Price = 100000, Multiplyer = 2.0f } },//72 36 27 18 9 6
            { "Pirate",                 new ItemInfo(){ Price =  50000, Multiplyer = 3.0f } },
            { "Ultra",                  new ItemInfo(){ Price = 120000, Multiplyer = 2.0f } },//144 72 54 36 18 12 6
            { "Temple",                 new ItemInfo(){ Price =  50000, Multiplyer = 3.0f } },
            { "Hardmode Dungeon",       new ItemInfo(){ Price =  50000, Multiplyer = 3.0f } },
            { "Solar Eclipse",          new ItemInfo(){ Price =  50000, Multiplyer = 3.0f } },
            { "Exceptional",            new ItemInfo(){ Price = 200000, Multiplyer = 1.5f } },//216 108 81 54 27 18 9 4.5
            { "Martian",                new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Pumpkin Moon",           new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Frost Moon",             new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Vortex",                 new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Stardust",               new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Nebula",                 new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Solar",                  new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Lunar",                  new ItemInfo(){ Price = 400000, Multiplyer = 3.0f } },
            { "The",                    new ItemInfo(){ Price =1000000, Multiplyer = InvulnerabilityCap/3 } }
        };
        [JsonIgnore]
        public Dictionary<string, ItemInfo> TrophyStats => new Dictionary<string, ItemInfo>()
        {
            { "Horror",                 new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Pre Hardmode",           new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Mechanics",              new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Ancient",                new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Moon",                   new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Events",                 new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "The",                    new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
        };

        public override ConfigScope Mode => ConfigScope.ClientSide;
    }
    internal struct ItemInfo
    {
        public int Price { get; set; }
        public float Multiplyer { get; set; }
    }
}
