using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateBannerMerging
{
    internal static class BannerConfig
    {
        public const float DamageIncrease = 0.2f;
        public const float DamageReduction = 40;
        public const int InvulnerabilityCap = 100;

        public static Dictionary<string, BannerInfo> Stats => new Dictionary<string, BannerInfo>()
        {
            { "Forest",                 new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Rain",                   new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Desert",                 new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Snow",                   new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Basic",                  new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Ocean",                  new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Jungle",                 new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Corrupted",              new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Crimson",                new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Moderate",               new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Underground Jungle",     new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Underground Desert",     new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Glowing Mushroom",       new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Cavern",                 new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Underground",            new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Blood Moon",             new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Advanced",               new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Dungeon",                new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Goblin Army",            new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Underworld",             new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Professional",           new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Hardmode Surface",       new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Hardmode Cavern",        new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Hardmode Underground",   new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Hardmode Corrupted",     new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Hardmode Crimson",       new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Hallow",                 new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Master",                 new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Pirate",                 new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Ultra",                  new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Temple",                 new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Hardmode Dungeon",       new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Solar Eclipse",          new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Exceptional",            new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Martian",                new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Pumpkin Moon",           new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Frost Moon",             new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Vortex",                 new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Stardust",               new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Nebula",                 new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Solar",                  new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "Lunar",                  new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } },
            { "The",                    new BannerInfo(){ Price = 100000, Multiplyer = 1.0f } }
        };
    }
    internal struct BannerInfo
    {
        public int Price { get; set; }
        public float Multiplyer { get; set; }
    }
}
