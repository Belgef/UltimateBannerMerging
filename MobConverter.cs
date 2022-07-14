using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateBannerMerging
{
    internal static class MobConverter
    {
        private static readonly Dictionary<string, string> bannerToMobMaps = new()
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
            { "RustyArmoredBonesBanner", "RustyArmoredBonesAxe" },
            { "DiablolistBanner", "DiabolistRed" },
            { "DD2GoblinBanner", "DD2GoblinT1" },
            { "DD2GoblinBomberBanner", "DD2GoblinBomberT1" },
            { "DD2JavelinThrowerBanner", "DD2JavelinstT1" },
            { "DD2WyvernBanner", "DD2WyvernT1" },
            { "DD2LightningBugBanner", "DD2LightningBugT3" },
            { "DD2KoboldBanner", "DD2KoboldWalkerT2" },
            { "DD2KoboldFlyerBanner", "DD2KoboldFlyerT2" },
            { "DD2DrakinBanner", "DD2DrakinT2" },
            { "DD2SkeletonBanner", "DD2SkeletonT1" },
            { "DD2WitherBeastBanner", "DD2WitherBeastT2" },
            { "EaterofWorldsTrophy", "EaterofWorldsHead" },
            { "DestroyerTrophy", "TheDestroyer" },
            { "SkeletronTrophy", "SkeletronHead" },
            { "AncientCultistTrophy", "CultistBoss" },
            { "MoonLordTrophy", "MoonLordHead" },
            { "FlyingDutchmanTrophy", "PirateShip" },
            { "BossTrophyDarkmage", "DD2DarkMageT1" },
            { "BossTrophyOgre", "DD2OgreT2" },
            { "BossTrophyBetsy", "DD2Betsy" }
        };
        public static readonly Dictionary<int, int> NPCProjectileOwners = new()
        {
            { 25, 24 },
            { 30, 29 },
            { 33, 32 },
            { 261, 260 },
            { 371, 370 },
            { 516, 415 },
            { 519, 517 },
            { 522, 439 },
            { NPCID.GolemHead, NPCID.Golem  },
            { NPCID.GolemHeadFree, NPCID.Golem },
            { NPCID.GolemFistLeft, NPCID.Golem },
            { NPCID.GolemFistRight, NPCID.Golem },
            { NPCID.PlanterasHook, NPCID.Plantera },
            { NPCID.PlanterasTentacle, NPCID.Plantera },
            { NPCID.Spore, NPCID.Plantera },
            { NPCID.PrimeVice, NPCID.SkeletronPrime },
            { NPCID.PrimeSaw, NPCID.SkeletronPrime },
            { NPCID.PrimeLaser, NPCID.SkeletronPrime },
            { NPCID.PrimeCannon, NPCID.SkeletronPrime },
            { NPCID.MartianSaucerCannon, NPCID.MartianSaucer },
            { NPCID.MartianSaucerCore, NPCID.MartianSaucer },
            { NPCID.Creeper, NPCID.BrainofCthulhu },
            { NPCID.TheHungry, NPCID.WallofFlesh },
            { NPCID.Probe, NPCID.TheDestroyer },
            { NPCID.MartianSaucerTurret, NPCID.MartianSaucer },
            { NPCID.ServantofCthulhu, NPCID.EyeofCthulhu },
            { NPCID.VileSpit, NPCID.EaterofWorldsHead },
            { NPCID.WallofFleshEye, NPCID.WallofFlesh },
            { NPCID.Sharkron, NPCID.DukeFishron},
            { NPCID.MoonLordFreeEye, NPCID.MoonLordHead },
            { NPCID.MoonLordHand, NPCID.MoonLordHead },
            { NPCID.MoonLordCore, NPCID.MoonLordHead },
            { NPCID.SlimeSpiked, NPCID.KingSlime }
        };
        public static readonly Dictionary<int, int[]> ProjectileOwners = new()
        {
            { ProjectileID.HarpyFeather, new int[]{ NPCID.Harpy } },
            { ProjectileID.DemonSickle, new int[]{ NPCID.Demon } },
            { ProjectileID.Stinger, new int[]{ NPCID.Hornet } },
            { ProjectileID.HappyBomb, new int[]{ NPCID.Clown } },
            { ProjectileID.WoodenArrowHostile, new int[]{ NPCID.GoblinArcher } },
            { ProjectileID.FlamingArrow, new int[]{ NPCID.SkeletonArcher } },
            { ProjectileID.EyeLaser, new int[]{ NPCID.Retinazer } },
            { ProjectileID.PinkLaser, new int[]{ NPCID.Gastropod, NPCID.Probe } },
            { ProjectileID.CursedFlameHostile, new int[]{ NPCID.Clinger, NPCID.Spazmatism } },
            { ProjectileID.DeathLaser, new int[]{ NPCID.Retinazer, NPCID.TheDestroyer, NPCID.SkeletronPrime } },
            { ProjectileID.EyeFire, new int[]{ NPCID.Spazmatism } },
            { ProjectileID.BombSkeletronPrime, new int[]{ NPCID.SkeletronPrime } },
            { ProjectileID.UnholyTridentHostile, new int[]{ NPCID.RedDevil } },
            { ProjectileID.FrostBlastHostile, new int[]{ NPCID.IceElemental } },
            { ProjectileID.RuneBlast, new int[]{ NPCID.RuneWizard } },
            { ProjectileID.IceSpike, new int[]{ NPCID.SpikedIceSlime } },
            { ProjectileID.JungleSpike, new int[]{ NPCID.SpikedJungleSlime } },
            { ProjectileID.IcewaterSpit, new int[]{ NPCID.IcyMerman } },
            { ProjectileID.BulletDeadeye, new int[]{ NPCID.PirateDeadeye, NPCID.TacticalSkeleton, NPCID.PirateCaptain } },
            { ProjectileID.CannonballHostile, new int[]{ NPCID.PirateCaptain } },
            { ProjectileID.FrostBeam, new int[]{ NPCID.IceGolem } },
            { ProjectileID.Fireball, new int[]{ NPCID.Golem } },
            { ProjectileID.EyeBeam, new int[]{ NPCID.Golem } },
            { ProjectileID.GolemFist, new int[]{ NPCID.Golem } },
            { ProjectileID.RainNimbus, new int[]{ NPCID.AngryNimbus } },
            { ProjectileID.SeedPlantera, new int[]{ NPCID.Plantera } },
            { ProjectileID.PoisonSeedPlantera, new int[]{ NPCID.Plantera } },
            { ProjectileID.ThornBall, new int[]{ NPCID.Plantera } },
            { ProjectileID.GoldenShowerHostile, new int[]{ NPCID.IchorSticker } },
            { ProjectileID.ShadowBeamHostile, new int[]{ NPCID.Necromancer } },
            { ProjectileID.InfernoHostileBolt, new int[]{ NPCID.DiabolistRed } },
            { ProjectileID.InfernoHostileBlast, new int[]{ NPCID.DiabolistRed } },
            { ProjectileID.LostSoulHostile, new int[]{ NPCID.RaggedCaster } },
            { ProjectileID.Shadowflames, new int[]{ NPCID.GiantCursedSkull } },
            { ProjectileID.PaladinsHammerHostile, new int[]{ NPCID.Paladin } },
            { ProjectileID.SniperBullet, new int[]{ NPCID.SkeletonSniper } },
            { ProjectileID.RocketSkeleton, new int[]{ NPCID.SkeletonCommando } },
            { ProjectileID.FlamingWood, new int[]{ NPCID.MourningWood } },
            { ProjectileID.GreekFire1, new int[]{ NPCID.MourningWood } },
            { ProjectileID.GreekFire2, new int[]{ NPCID.MourningWood } },
            { ProjectileID.GreekFire3, new int[]{ NPCID.MourningWood } },
            { ProjectileID.FlamingScythe, new int[]{ NPCID.Pumpking } },
            { ProjectileID.PineNeedleHostile, new int[]{ NPCID.Everscream } },
            { ProjectileID.OrnamentHostile, new int[]{ NPCID.Everscream } },
            { ProjectileID.OrnamentHostileShrapnel, new int[]{ NPCID.Everscream } },
            { ProjectileID.FrostWave, new int[]{ NPCID.IceQueen } },
            { ProjectileID.FrostShard, new int[]{ NPCID.IceQueen } },
            { ProjectileID.Missile, new int[]{ NPCID.SantaNK1 } },
            { ProjectileID.Present, new int[]{ NPCID.SantaNK1 } },
            { ProjectileID.Spike, new int[]{ NPCID.SantaNK1 } },
            { ProjectileID.Sharknado, new int[]{ NPCID.DukeFishron } },
            { ProjectileID.SharknadoBolt, new int[]{ NPCID.DukeFishron } },
            { ProjectileID.Cthulunado, new int[]{ NPCID.DukeFishron } },
            { ProjectileID.MartianTurretBolt, new int[]{ NPCID.MartianTurret } },
            { ProjectileID.BrainScramblerBolt, new int[]{ NPCID.BrainScrambler } },
            { ProjectileID.GigaZapperSpear, new int[]{ NPCID.GigaZapper } },
            { ProjectileID.RayGunnerLaser, new int[]{ NPCID.RayGunner } },
            { ProjectileID.UFOLaser, new int[]{ NPCID.MartianSaucer } },
            { ProjectileID.SaucerDeathray, new int[]{ NPCID.MartianSaucer } },
            { ProjectileID.SaucerLaser, new int[]{ NPCID.MartianSaucer } },
            { ProjectileID.SaucerMissile, new int[]{ NPCID.MartianSaucer } },
            { ProjectileID.SaucerScrap, new int[]{ NPCID.MartianSaucer } },
            { ProjectileID.PhantasmalEye, new int[]{ NPCID.MoonLordHead } },
            { ProjectileID.PhantasmalSphere, new int[]{ NPCID.MoonLordHead } },
            { ProjectileID.PhantasmalDeathray, new int[]{ NPCID.MoonLordHead } },
            { ProjectileID.MoonLeech, new int[]{ NPCID.MoonLordHead } },
            { ProjectileID.PhantasmalBolt, new int[]{ NPCID.MoonLordHead } },
            { ProjectileID.CultistBossFireBallClone, new int[]{ NPCID.CultistBoss } },
            { ProjectileID.CultistBossIceMist, new int[]{ NPCID.CultistBoss } },
            { ProjectileID.CultistBossLightningOrb, new int[]{ NPCID.CultistBoss } },
            { ProjectileID.CultistBossFireBall, new int[]{ NPCID.CultistBoss } },
            { ProjectileID.CultistBossLightningOrbArc, new int[]{ NPCID.CultistBoss } },
            { ProjectileID.CultistRitual, new int[]{ NPCID.CultistBoss } },
            { ProjectileID.WebSpit, new int[]{ NPCID.BlackRecluse } },
            { ProjectileID.Nail, new int[]{ NPCID.Nailhead } },
            { ProjectileID.DrManFlyFlask, new int[]{ NPCID.DrManFly } },
            { ProjectileID.JavelinHostile, new int[]{ NPCID.GreekSkeleton } },
            { ProjectileID.StardustSoldierLaser, new int[]{ NPCID.StardustSoldier } },
            { ProjectileID.Twinkle, new int[]{ NPCID.StardustSpiderBig } },
            { ProjectileID.StardustJellyfishSmall, new int[]{ NPCID.StardustJellyfishBig } },
            { ProjectileID.SalamanderSpit, new int[]{ NPCID.Salamander } },
            { ProjectileID.NebulaBolt, new int[]{ NPCID.NebulaSoldier } },
            { ProjectileID.NebulaEye, new int[]{ NPCID.NebulaBrain } },
            { ProjectileID.NebulaSphere, new int[]{ NPCID.NebulaBeast } },
            { ProjectileID.NebulaLaser, new int[]{ NPCID.NebulaBrain } },
            { ProjectileID.VortexLaser, new int[]{ NPCID.VortexRifleman } },
            { ProjectileID.VortexAcid, new int[]{ NPCID.VortexHornetQueen } },
            { ProjectileID.MartianWalkerLaser, new int[]{ NPCID.MartianWalker } },
            { ProjectileID.AncientDoomProjectile, new int[]{ NPCID.CultistBoss } },
            { ProjectileID.DesertDjinnCurse, new int[]{ NPCID.DesertDjinn } },
            { ProjectileID.SpikedSlimeSpike, new int[]{ NPCID.SlimeSpiked } },
            { ProjectileID.SolarFlareRay, new int[]{ NPCID.SolarDrakomire } },
            { ProjectileID.SandnadoHostile, new int[]{ NPCID.SandElemental } },
            { ProjectileID.SandnadoHostileMark, new int[]{ NPCID.SandElemental } },
            { ProjectileID.Skull, new int[] { NPCID.SkeletronHead } },
            { ProjectileID.DD2GoblinBomb, new int[] { NPCID.DD2GoblinBomberT1 } },
            { ProjectileID.DD2LightningBugZap, new int[] { NPCID.DD2LightningBugT3 } },
            { ProjectileID.DD2OgreStomp, new int[] { NPCID.DD2OgreT2 } },
            { ProjectileID.DD2OgreSpit, new int[] { NPCID.DD2OgreT2 } },
            { ProjectileID.DD2OgreSmash, new int[] { NPCID.DD2OgreT2 } },
            { ProjectileID.DD2DarkMageRaise, new int[] { NPCID.DD2DarkMageT1 } },
            { ProjectileID.DD2DarkMageHeal, new int[] { NPCID.DD2DarkMageT1 } },
            { ProjectileID.DD2DarkMageBolt, new int[] { NPCID.DD2DarkMageT1 } },
            { ProjectileID.DD2DrakinShot, new int[] { NPCID.DD2DrakinT2 } },
            { ProjectileID.DD2JavelinHostileT3, new int[] { NPCID.DD2JavelinstT1 } },
            { ProjectileID.DD2BetsyFireball, new int[] { NPCID.DD2Betsy } },
            { ProjectileID.DD2BetsyFlameBreath, new int[] { NPCID.DD2Betsy } }
        };
        public static readonly Dictionary<string,ModBannersData> ModBannersData = new()
        {
            {
                "CalamityMod", 
                new ModBannersData{
                    ModName = "CalamityMod",
                    UniqueBanners = new(){
                        { "AmberCrawlerBanner", "CrawlerAmber" },
                        { "AmethystCrawlerBanner", "CrawlerAmethyst" },
                        { "ArmoredDiggerBanner", "ArmoredDiggerBody" },
                        { "AstralachneaBanner", "AstralachneaGround" },
                        { "BobbitWormBanner", "BobbitWormHead" },
                        { "CloudElementalBanner", "ThiccWaifu" },
                        { "CrystalCrawlerBanner", "CrawlerCrystal" },
                        { "DiamondCrawlerBanner", "CrawlerDiamond" },
                        { "EarthElementalBanner", "Horse" },
                        { "EidolonWyrmJuvenileBanner", "EidolonWyrmBody" },
                        { "EmeraldCrawlerBanner", "CrawlerEmerald" },
                        { "GulperEelBanner", "GulperEelBody" },
                        { "OarfishBanner", "OarfishBody" },
                        { "PlaguebringerBanner", "PlaguebringerMiniboss" },
                        { "ProfanedEnergyBanner", "ProfanedEnergyBody" },
                        { "RubyCrawlerBanner", "CrawlerRuby" },
                        { "SapphireCrawlerBanner", "CrawlerSapphire" },
                        { "SeaSerpentBanner", "SeaSerpent1" },
                        { "TopazCrawlerBanner", "CrawlerTopaz" }
                    },
                    Multiparts = new(){
                        { "BobbitWormHead", "BobbitWormHead" },
                        { "BobbitWormSegment", "BobbitWormHead" },
                        { "DevilFish", "DevilFish" },
                        { "DevilFishAlt", "DevilFish" },
                        { "EidolonWyrmBody", "EidolonWyrmBody" },
                        { "EidolonWyrmBodyAlt", "EidolonWyrmBody" },
                        { "EidolonWyrmHead", "EidolonWyrmBody" },
                        { "EidolonWyrmTail", "EidolonWyrmBody" },
                        { "GulperEelBody", "GulperEelBody" },
                        { "GulperEelBodyAlt", "GulperEelBody" },
                        { "GulperEelHead", "GulperEelBody" },
                        { "GulperEelTail", "GulperEelBody" },
                        { "OarfishBody", "OarfishBody" },
                        { "OarfishHead", "OarfishBody" },
                        { "OarfishTail", "OarfishBody" },
                        { "AstralachneaGround", "AstralachneaGround" },
                        { "AstralachneaWall", "AstralachneaGround" },
                        { "Hive", "Hive" },{ "Hiveling", "Hive" },
                        { "Scryllar", "Scryllar" },
                        { "ScryllarRage", "Scryllar" },
                        { "ArmoredDiggerBody", "ArmoredDiggerBody" },
                        { "ArmoredDiggerHead", "ArmoredDiggerBody" },
                        { "ArmoredDiggerTail", "ArmoredDiggerBody" },
                        { "PhantomSpirit", "PhantomSpirit" },
                        { "PhantomSpiritL", "PhantomSpirit" },
                        { "PhantomSpiritM", "PhantomSpirit" },
                        { "PhantomSpiritS", "PhantomSpirit" },
                        { "ProfanedEnergyBody", "ProfanedEnergyBody" },
                        { "ProfanedEnergyLantern", "ProfanedEnergyBody" },
                        { "PlagueCharger", "PlagueCharger" },
                        { "PlagueChargerLarge", "PlagueCharger" },
                        { "SeaSerpent1", "SeaSerpent1" },
                        { "SeaSerpent2", "SeaSerpent1" },
                        { "SeaSerpent3", "SeaSerpent1" },
                        { "SeaSerpent4", "SeaSerpent1" },
                        { "SeaSerpent5", "SeaSerpent1" },
                    }
                } 
            }
        };

        public static bool IsVanillaBanner(int bannerID)
        {
            return ItemID.Search.TryGetName(bannerID, out var bannerName) && bannerName.Contains("Banner") && TryGetMobID(bannerID, out int mobID);
        }
        public static bool IsVanillaTrophy(int trophyID)
        {
            return ItemID.Search.TryGetName(trophyID, out var bannerName) && bannerName.Contains("Trophy") && TryGetBossID(trophyID, out int mobID);
        }
        public static bool IsModdedBanner(Item item)
        {
            return (item.ModItem?.Name.Contains("Banner") ?? default) && ModBannersData.ContainsKey(item.ModItem.Mod.Name);
        }
        public static int GetMobID(int bannerID)
        {
            if (ItemID.Search.TryGetName(bannerID, out var name) && name.Contains("Banner"))
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
        public static bool TryGetMobID(int bannerID, out int mobID)
        {
            if (ItemID.Search.TryGetName(bannerID, out var name) && name.Contains("Banner"))
            {
                if (NPCID.Search.TryGetId(BannerToMobName(name), out mobID))
                {
                    return true;
                }
                else
                    return false;
            }
            mobID = 0;
            return false;
        }
        public static int GetBossID(int trophyID)
        {
            if (ItemID.Search.TryGetName(trophyID, out var name) && name.Contains("Trophy"))
            {
                if (NPCID.Search.TryGetId(TrophyToBossName(name), out var mobID))
                {
                    return mobID;
                }
                else
                    throw new ArgumentException("Failed to find trophy boss");
            }
            else
                throw new ArgumentException("Invalid item");
        }
        public static bool TryGetBossID(int trophyID, out int bossID)
        {
            if (ItemID.Search.TryGetName(trophyID, out var name) && name.Contains("Trophy"))
            {
                if (NPCID.Search.TryGetId(TrophyToBossName(name), out bossID))
                {
                    return true;
                }
                else
                    return false;
            }
            bossID = 0;
            return false;
        }
        public static string BannerToMobName(string bannerName)
        {
            if (bannerToMobMaps.ContainsKey(bannerName))
                return bannerToMobMaps[bannerName];
            else
                return bannerName.Replace("Banner", "");
        }
        public static string TrophyToBossName(string bannerName)
        {
            if (bannerToMobMaps.ContainsKey(bannerName))
                return bannerToMobMaps[bannerName];
            else
                return bannerName.Replace("Trophy", "");
        }

        public static int GetMobID(Terraria.NPC mob)
        {
            var name = mob.FullName;
            if (name == "True Eye of Cthulhu")
                return 400;
            return NPCID.FromLegacyName(name);
        }
        public static int[] GetMobID(Projectile proj)
        {
            if (ProjectileOwners.ContainsKey(proj.type))
                return ProjectileOwners[proj.type];
            return null;
        }
    }
}
