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

#pragma warning disable 649

namespace UltimateBannerMerging
{
    internal class BannerConfig : ModConfig
    {
        [Range(1, 100)]
        [DefaultValue(18)]
        [Label("Banner Cap")]
        [Tooltip("Minimal number of simple banners needed to reach maximal effects")]
        public int InvulnerabilityCap;
        [Range(1, 100)]
        [DefaultValue(18)]
        [Label("Trophy Cap")]
        [Tooltip("Minimal number of simple trophies needed to reach maximal effects")]
        public int BossInvulnerabilityCap;
        [Range(1f, 100f)]
        [DefaultValue("4")]
        [Label("Max Damage Multiplier")]
        public int MaxDamageIncrease;
        [Range(1f, 100f)]
        [DefaultValue("4")]
        [Label("Max Boss Damage Multiplier")]
        public int MaxBossDamageIncrease;
        [Range(1f, 100f)]
        [DefaultValue("5")]
        [Label("Max Drop Multiplier")]
        public int MaxLootMultiplier;
        [Range(1f, 100f)]
        [DefaultValue("5")]
        [Label("Max Boss Drop Multiplier")]
        public int MaxBossLootMultiplier;

        [JsonIgnore]
        public Dictionary<string, ItemInfo> BannerStats => new()
        {
            { "Forest Banner",                 new() { Price =   5000, Multiplyer = 3.0f } },
            { "Rain Banner",                   new() { Price =   5000, Multiplyer = 3.0f } },
            { "Desert Banner",                 new() { Price =   5000, Multiplyer = 3.0f } },
            { "Snow Banner",                   new() { Price =   5000, Multiplyer = 3.0f } },
            { "Basic Banner",                  new() { Price =  10000, Multiplyer = 2.0f } },//6
            { "Ocean Banner",                  new() { Price =   5000, Multiplyer = 3.0f } },
            { "Jungle Banner",                 new() { Price =  10000, Multiplyer = 3.0f } },
            { "Corrupted Banner",              new() { Price =  10000, Multiplyer = 3.0f } },
            { "Crimson Banner",                new() { Price =  10000, Multiplyer = 3.0f } },
            { "Moderate Banner",               new() { Price =  30000, Multiplyer = 2.0f } },//12 6
            { "Underground Jungle Banner",     new() { Price =  10000, Multiplyer = 3.0f } },
            { "Underground Desert Banner",     new() { Price =  10000, Multiplyer = 3.0f } },
            { "Glowing Mushroom Banner",       new() { Price =  10000, Multiplyer = 3.0f } },
            { "Cavern Banner",                 new() { Price =  10000, Multiplyer = 3.0f } },
            { "Underground Banner",            new() { Price =  20000, Multiplyer = 1.5f } },//4.5
            { "Blood Moon Banner",             new() { Price =  10000, Multiplyer = 3.0f } },
            { "Advanced Banner",               new() { Price =  50000, Multiplyer = 2.0f } },//24 12 9 6
            { "Dungeon Banner",                new() { Price =  20000, Multiplyer = 3.0f } },
            { "Goblin Army Banner",            new() { Price =  20000, Multiplyer = 3.0f } },
            { "Old One's Army Banner",         new() { Price =  20000, Multiplyer = 3.0f } },
            { "Underworld Banner",             new() { Price =  20000, Multiplyer = 3.0f } },
            { "Professional Banner",           new() { Price =  80000, Multiplyer = 1.5f } },//36 18 13.5 9 4.5
            { "Hardmode Surface Banner",       new() { Price =  30000, Multiplyer = 3.0f } },
            { "Hardmode Cavern Banner",        new() { Price =  30000, Multiplyer = 1.0f } },
            { "Hardmode Underground Banner",   new() { Price =  30000, Multiplyer = 3.0f } },
            { "Hardmode Corrupted Banner",     new() { Price =  30000, Multiplyer = 3.0f } },
            { "Hardmode Crimson Banner",       new() { Price =  30000, Multiplyer = 3.0f } },
            { "Hallow Banner",                 new() { Price =  30000, Multiplyer = 3.0f } },
            { "Master Banner",                 new() { Price = 100000, Multiplyer = 2.0f } },//72 36 27 18 9 6
            { "Pirate Banner",                 new() { Price =  50000, Multiplyer = 3.0f } },
            { "Ultra Banner",                  new() { Price = 120000, Multiplyer = 2.0f } },//144 72 54 36 18 12 6
            { "Temple Banner",                 new() { Price =  50000, Multiplyer = 3.0f } },
            { "Hardmode Dungeon Banner",       new() { Price =  50000, Multiplyer = 3.0f } },
            { "Solar Eclipse Banner",          new() { Price =  50000, Multiplyer = 3.0f } },
            { "Exceptional Banner",            new() { Price = 200000, Multiplyer = 1.5f } },//216 108 81 54 27 18 9 4.5
            { "Martian Banner",                new() { Price = 100000, Multiplyer = 3.0f } },
            { "Old One's Army Hardmode Banner",new() { Price = 100000, Multiplyer = 3.0f } },
            { "Pumpkin Moon Banner",           new() { Price = 100000, Multiplyer = 3.0f } },
            { "Frost Moon Banner",             new() { Price = 100000, Multiplyer = 3.0f } },
            { "Vortex Banner",                 new() { Price = 100000, Multiplyer = 3.0f } },
            { "Stardust Banner",               new() { Price = 100000, Multiplyer = 3.0f } },
            { "Nebula Banner",                 new() { Price = 100000, Multiplyer = 3.0f } },
            { "Solar Banner",                  new() { Price = 100000, Multiplyer = 3.0f } },
            { "Lunar Banner",                  new() { Price = 400000, Multiplyer = 3.0f } },
            { "The Banner",                    new() { Price =1000000, Multiplyer = 18.0f} },

            { "Horror Trophy",                 new() { Price =   5000, Multiplyer = 3.0f } }, // 3
            { "Pre Hardmode Trophy",           new() { Price =  10000, Multiplyer = 3.0f } }, // 9 3
            { "Mechanics Trophy",              new() { Price =  25000, Multiplyer = 3.0f } }, // 3
            { "Ancient Trophy",                new() { Price =  50000, Multiplyer = 3.0f } }, // 3
            { "Moon Trophy",                   new() { Price = 100000, Multiplyer = 3.0f } }, // 3
            { "Events Trophy",                 new() { Price = 250000, Multiplyer = 6.0f } }, // 18 6
            { "The Trophy",                    new() { Price =1000000, Multiplyer = 18.0f } }, // 18 9
            
            { "Wulfrum Banner",                new() { Price =    5000, Multiplyer = 3.0f } },
            { "Crawler Banner",                new() { Price =   10000, Multiplyer = 3.0f } },
            { "Sulphurous Banner",             new() { Price =   10000, Multiplyer = 3.0f } },
            { "Sunken Banner",                 new() { Price =   20000, Multiplyer = 3.0f } },
            { "Calamity Beginner Banner",      new() { Price =   50000, Multiplyer = 3.0f } },
            { "Small Abyss Banner",            new() { Price =   30000, Multiplyer = 3.0f } },
            { "Brimstone Banner",              new() { Price =   20000, Multiplyer = 3.0f } },
            { "Calamity Prehardmode Banner",   new() { Price =  100000, Multiplyer = 6.0f } },
            { "Astral Banner",                 new() { Price =   70000, Multiplyer = 3.0f } },
            { "Plague Banner",                 new() { Price =   60000, Multiplyer = 3.0f } },
            { "Medium Abyss Banner",           new() { Price =  100000, Multiplyer = 6.0f } },
            { "Full Sulphurous Banner",        new() { Price =   90000, Multiplyer = 3.0f } },
            { "Cryo Banner",                   new() { Price =   60000, Multiplyer = 3.0f } },
            { "Acid Rain Banner",              new() { Price =   60000, Multiplyer = 3.0f } },
            { "Calamity Hardmode Banner",      new() { Price =  200000, Multiplyer = 3.0f } },
            { "Calamity Super Hardmode Banner",new() { Price = 1000000, Multiplyer = 3.0f } },
            { "Large Abyss Banner",            new() { Price =  500000, Multiplyer = 6.0f } },
            { "Full Acid Rain Banner",         new() { Price =   80000, Multiplyer = 3.0f } },
            { "The Calamity Banner",           new() { Price = 5000000, Multiplyer = 18.0f } },

            { "Calamity Prehardmode Trophy",   new() { Price =   10000, Multiplyer = 3.0f } },
            { "Calamity Hardmode Trophy",      new() { Price =    1000, Multiplyer = 3.0f } },
            { "Calamity Super Hardmode Trophy",new() { Price =10000000, Multiplyer = 3.0f } },
            { "Calamity Profaned Trophy",      new() { Price = 5000000, Multiplyer = 3.0f } },
            { "Calamity Devouring Trophy",     new() { Price =40000000, Multiplyer = 3.0f } },
            { "Calamity Immaculate Trophy",    new() { Price =80000000, Multiplyer = 6.0f } },
            { "The Calamity Trophy",           new() { Price =100000000, Multiplyer = 18.0f } },

        };

        public override ConfigScope Mode => ConfigScope.ClientSide;
    }
    internal struct ItemInfo
    {
        public int Price { get; set; }
        public float Multiplyer { get; set; }
    }
}
#pragma warning restore 649
