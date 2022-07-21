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
        //[JsonIgnore]
        //[Range(1f, 100f)]
        //[DefaultValue("5")]
        //[Label("Max Boss Drop Multiplier")]
        //public int DropMaxBossMultiplier;

        [JsonIgnore]
        public Dictionary<string, ItemInfo> BannerStats => new()
        {
            { "Forest Banner",                 new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Rain Banner",                   new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Desert Banner",                 new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Snow Banner",                   new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Basic Banner",                  new ItemInfo(){ Price =  10000, Multiplyer = 2.0f } },//6
            { "Ocean Banner",                  new ItemInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Jungle Banner",                 new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Corrupted Banner",              new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Crimson Banner",                new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Moderate Banner",               new ItemInfo(){ Price =  30000, Multiplyer = 2.0f } },//12 6
            { "Underground Jungle Banner",     new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Underground Desert Banner",     new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Glowing Mushroom Banner",       new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Cavern Banner",                 new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Underground Banner",            new ItemInfo(){ Price =  20000, Multiplyer = 1.5f } },//4.5
            { "Blood Moon Banner",             new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Advanced Banner",               new ItemInfo(){ Price =  50000, Multiplyer = 2.0f } },//24 12 9 6
            { "Dungeon Banner",                new ItemInfo(){ Price =  20000, Multiplyer = 3.0f } },
            { "Goblin Army Banner",            new ItemInfo(){ Price =  20000, Multiplyer = 3.0f } },
            { "Old One's Army Banner",         new ItemInfo(){ Price =  20000, Multiplyer = 3.0f } },
            { "Underworld Banner",             new ItemInfo(){ Price =  20000, Multiplyer = 3.0f } },
            { "Professional Banner",           new ItemInfo(){ Price =  80000, Multiplyer = 1.5f } },//36 18 13.5 9 4.5
            { "Hardmode Surface Banner",       new ItemInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Hardmode Cavern Banner",        new ItemInfo(){ Price =  30000, Multiplyer = 1.0f } },
            { "Hardmode Underground Banner",   new ItemInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Hardmode Corrupted Banner",     new ItemInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Hardmode Crimson Banner",       new ItemInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Hallow Banner",                 new ItemInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Master Banner",                 new ItemInfo(){ Price = 100000, Multiplyer = 2.0f } },//72 36 27 18 9 6
            { "Pirate Banner",                 new ItemInfo(){ Price =  50000, Multiplyer = 3.0f } },
            { "Ultra Banner",                  new ItemInfo(){ Price = 120000, Multiplyer = 2.0f } },//144 72 54 36 18 12 6
            { "Temple Banner",                 new ItemInfo(){ Price =  50000, Multiplyer = 3.0f } },
            { "Hardmode Dungeon Banner",       new ItemInfo(){ Price =  50000, Multiplyer = 3.0f } },
            { "Solar Eclipse Banner",          new ItemInfo(){ Price =  50000, Multiplyer = 3.0f } },
            { "Exceptional Banner",            new ItemInfo(){ Price = 200000, Multiplyer = 1.5f } },//216 108 81 54 27 18 9 4.5
            { "Martian Banner",                new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Old One's Army Hardmode Banner",new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Pumpkin Moon Banner",           new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Frost Moon Banner",             new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Vortex Banner",                 new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Stardust Banner",               new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Nebula Banner",                 new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Solar Banner",                  new ItemInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Lunar Banner",                  new ItemInfo(){ Price = 400000, Multiplyer = 3.0f } },
            { "The Banner",                    new ItemInfo(){ Price =1000000, Multiplyer = InvulnerabilityCap/3 } },
            { "Horror Trophy",                 new ItemInfo(){ Price =   5000, Multiplyer = 6.0f } }, // 3
            { "Pre Hardmode Trophy",           new ItemInfo(){ Price =  10000, Multiplyer = 3.0f } }, // 9 3
            { "Mechanics Trophy",              new ItemInfo(){ Price =  25000, Multiplyer = 6.0f } }, // 3
            { "Ancient Trophy",                new ItemInfo(){ Price =  50000, Multiplyer = 6.0f } }, // 3
            { "Moon Trophy",                   new ItemInfo(){ Price = 100000, Multiplyer = 6.0f } }, // 3
            { "Events Trophy",                 new ItemInfo(){ Price = 250000, Multiplyer = 3.0f } }, // 9 3
            { "The Trophy",                    new ItemInfo(){ Price =1000000, Multiplyer = 6.0f } }, // 18 9 }
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
