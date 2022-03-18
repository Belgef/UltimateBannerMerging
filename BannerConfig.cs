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

        [JsonIgnore]
        public Dictionary<string, BannerInfo> Stats => new Dictionary<string, BannerInfo>()
        {
            { "Forest",                 new BannerInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Rain",                   new BannerInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Desert",                 new BannerInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Snow",                   new BannerInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Basic",                  new BannerInfo(){ Price =  10000, Multiplyer = 2.0f } },//6
            { "Ocean",                  new BannerInfo(){ Price =   5000, Multiplyer = 3.0f } },
            { "Jungle",                 new BannerInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Corrupted",              new BannerInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Crimson",                new BannerInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Moderate",               new BannerInfo(){ Price =  30000, Multiplyer = 2.0f } },//12 6
            { "Underground Jungle",     new BannerInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Underground Desert",     new BannerInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Glowing Mushroom",       new BannerInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Cavern",                 new BannerInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Underground",            new BannerInfo(){ Price =  20000, Multiplyer = 1.5f } },//4.5
            { "Blood Moon",             new BannerInfo(){ Price =  10000, Multiplyer = 3.0f } },
            { "Advanced",               new BannerInfo(){ Price =  50000, Multiplyer = 2.0f } },//24 12 9 6
            { "Dungeon",                new BannerInfo(){ Price =  20000, Multiplyer = 3.0f } },
            { "Goblin Army",            new BannerInfo(){ Price =  20000, Multiplyer = 3.0f } },
            { "Underworld",             new BannerInfo(){ Price =  20000, Multiplyer = 3.0f } },
            { "Professional",           new BannerInfo(){ Price =  80000, Multiplyer = 1.5f } },//36 18 13.5 9 4.5
            { "Hardmode Surface",       new BannerInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Hardmode Cavern",        new BannerInfo(){ Price =  30000, Multiplyer = 1.0f } },
            { "Hardmode Underground",   new BannerInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Hardmode Corrupted",     new BannerInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Hardmode Crimson",       new BannerInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Hallow",                 new BannerInfo(){ Price =  30000, Multiplyer = 3.0f } },
            { "Master",                 new BannerInfo(){ Price = 100000, Multiplyer = 2.0f } },//72 36 27 18 9 6
            { "Pirate",                 new BannerInfo(){ Price =  50000, Multiplyer = 3.0f } },
            { "Ultra",                  new BannerInfo(){ Price = 120000, Multiplyer = 2.0f } },//144 72 54 36 18 12 6
            { "Temple",                 new BannerInfo(){ Price =  50000, Multiplyer = 3.0f } },
            { "Hardmode Dungeon",       new BannerInfo(){ Price =  50000, Multiplyer = 3.0f } },
            { "Solar Eclipse",          new BannerInfo(){ Price =  50000, Multiplyer = 3.0f } },
            { "Exceptional",            new BannerInfo(){ Price = 200000, Multiplyer = 1.5f } },//216 108 81 54 27 18 9 4.5
            { "Martian",                new BannerInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Pumpkin Moon",           new BannerInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Frost Moon",             new BannerInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Vortex",                 new BannerInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Stardust",               new BannerInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Nebula",                 new BannerInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Solar",                  new BannerInfo(){ Price = 100000, Multiplyer = 3.0f } },
            { "Lunar",                  new BannerInfo(){ Price = 400000, Multiplyer = 3.0f } },
            { "The",                    new BannerInfo(){ Price =1000000, Multiplyer = InvulnerabilityCap/3 } }
        };

        public override ConfigScope Mode => ConfigScope.ClientSide;
    }
    internal struct BannerInfo
    {
        public int Price { get; set; }
        public float Multiplyer { get; set; }
    }
}
