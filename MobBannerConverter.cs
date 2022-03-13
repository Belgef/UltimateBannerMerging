using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateBannerMerging
{
    internal static class MobBannerConverter
    {
        private static Dictionary<string, string> bannerToMobMaps = new Dictionary<string, string>
        {
            { "WyvernBanner", "WyvernHead" },
            { "LavaBatBanner", "Lavabat" },
            { "SlimeBanner", "BlueSlime" },
            { "RaincoatZombieBanner", "ZombieRaincoat" },
            { "DevourerBanner", "DevourerHead" },
            { "BatBanner", "CaveBat" },
            { "JellyfishBanner", "BlueJellyfish" },
            { "SpiderBanner", "WallCreeper" },
            { "NypmhBanner", "Nymph" },
            { "SporeZombieBanner", "ZombieMushroom" },
            { "TombCrawlerBanner", "TombCrawlerHead" },
            { "SkeletonMageBanner", "DarkCaster" },
            { "BoneSerpentBanner", "BoneSerpentHead" },
            { "SandsharkBanner", "SandShark" },
            { "TortoiseBanner", "GiantTortoise" },
            { "DesertBasiliskBanner", "DesertBeast" },
            { "DuneSplicerBanner", "DuneSplicerHead" },
            { "DesertLamiaBanner", "DesertLamiaLight" },
            { "RavagerScorpionBanner", "DesertScorpionWalk" },
            { "PigronBanner", "PigronCorruption" },
            { "WorldFeederBanner", "SeekerHead" },
            { "SandsharkHallowedBanner", "SandsharkHallow" },
            { "MartianBrainscramblerBanner", "BrainScrambler" },
            { "MartianGigazapperBanner", "GigaZapper" },
            { "MartianGreyGruntBanner", "GrayGrunt" },
            { "MartianRaygunnerBanner", "RayGunner" },
            { "MartianScutlixGunnerBanner", "ScutlixRider" },
            { "MartianTeslaTurretBanner", "MartianTurret" },
            { "ScarecrowBanner", "Scarecrow1" },
            { "SolarCrawltipedeBanner", "SolarCrawltipedeHead" },
            { "StardustJellyfishBanner", "StardustJellyfishBig" },
            { "StardustLargeCellBanner", "StardustCellBig" },
            { "StardustSpiderBanner", "StardustSpiderBig" },
            { "StardustWormBanner", "StardustWormHead" },
        };


        public static bool IsVanillaBanner(int bannerID)
        {
            return ItemID.Search.TryGetName(bannerID, out var bannerName) && bannerName.Contains("Banner");
        }
        public static int GetMobID(int bannerID, Mod mod)
        {
            if(ItemID.Search.TryGetName(bannerID, out var name) && name.Contains("Banner"))
            {
                if (NPCID.Search.TryGetId(BannerToMobName(name), out var mobID))
                {
                    return mobID;
                }
                else
                    throw new ArgumentException("Failed to find banner mob");
            }
            else
                throw new ArgumentException("Invalid item");
        }
        public static string BannerToMobName(string bannerName)
        {
            if(bannerToMobMaps.ContainsKey(bannerName))
                return bannerToMobMaps[bannerName];
            else
                return bannerName.Replace("Banner", "");
        }
        public static int GetMobID(NPC mob)
        {
            return NPCID.FromLegacyName(mob.FullName);
        }
        public static int GetMobID(Projectile proj)
        {
            return GetMobID(Main.npc[proj.owner]);
        }
    }
}
