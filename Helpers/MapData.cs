using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateBannerMerging.Helpers
{
    internal static class MapData
    {
        private static readonly int[] MobToBannerMapping =
        {
            1661, 1661, 1661, 1661, 1661, 1661, 1661, 1661, 1661, 1661, 1701, 1701, 1681, 1681, 1681, 1681, 1681, 1681,
            1681, 1681, 1701, 1701, 1639, 1639, 1639, 1639, 1639, 1639, 1701, 1701, 1701, 1701, 1701, 1701, 1701, 1701,
            1701, 1701, 1701, 1701, 2910, 2910, 1635, 1635, 4976, 4976, 4976, 4976, 1661, 1661, 1620, 3451, 3451, 1641,
            1641, 2940, 2992, 2968, 2964, 2899, 2955, 2960, 2928, 2976, 2976, 0, 1683, 1639, 1701, 1360, 1360, 1641,
            2913, 2913, 2913, 1698, 1698, 1698, 1361, 1361, 1361, 2955, 0, 0, 0, 0, 1681, 0, 1669, 1664, 1664, 1654,
            1652, 1656, 1653, 1653, 3451, 1682, 1682, 2911, 1363, 1363, 0, 0, 1627, 1627, 1627, 1661, 1668, 2987, 2986,
            0, 1632, 1658, 1621, 2489, 2939, 2915, 2985, 0, 0, 2977, 1633, 1675, 2944, 1659, 1693, 1638, 1665, 3447,
            1680, 1638, 1634, 0, 1618, 0, 2916, 0, 1655, 0, 1677, 0, 1620, 1671, 3449, 3450, 2908, 1699, 1637, 1642,
            1630, 1691, 1700, 1700, 1700, 1700, 1700, 1700, 2923, 2909, 1698, 1698, 1698, 1697, 1697, 1697, 2905, 1615,
            3448, 1695, 0, 0, 0, 0, 1631, 2973, 2927, 2909, 1365, 1365, 1365, 1365, 1365, 1365, 1365, 1629, 2976, 1651,
            0, 0, 1368, 1369, 1367, 1367, 1367, 1367, 1367, 1701, 4977, 1366, 1366, 1366, 2937, 2938, 1366, 2962, 1689,
            0, 2979, 2954, 2978, 0, 2935, 0, 0, 2933, 2943, 2925, 1688, 3452, 1696, 3446, 1619, 1692, 1692, 0, 1643,
            1648, 1623, 1685, 1685, 1687, 2988, 2907, 1662, 1674, 1674, 2969, 1635, 1660, 2897, 4976, 1640, 0, 1636,
            1674, 1644, 1645, 2910, 2980, 1684, 1701, 1701, 1701, 1701, 1639, 1639, 1639, 1639, 1639, 1694, 1694, 2898,
            1667, 1667, 1701, 1681, 1681, 1681, 2981, 1670, 1663, 0, 0, 0, 0, 0, 1676, 3443, 3442, 3444, 3441, 2906,
            2912, 2942, 3594, 2983, 1364, 1678, 1646, 1690, 1647, 0, 0, 0, 0, 1661, 1661, 1661, 1661, 1661, 1666, 1666,
            1623, 1626, 1626, 1624, 1625, 2934, 2966, 1371, 1371, 1371, 1371, 1371, 1616, 2920, 1673, 1679, 1686, 1686,
            1650, 1617, 1672, 1649, 1649, 1649, 1370, 1370, 1370, 1370, 1362, 1362, 2936, 2970, 2970, 2970, 2970, 2900,
            2900, 2900, 2900, 2930, 2930, 2930, 2930, 2965, 2965, 2956, 2956, 2914, 2914, 2904, 2917, 2924, 2958, 2975,
            2984, 2974, 3451, 3451, 3451, 0, 0, 0, 0, 2967, 1683, 0, 2932, 2971, 2971, 2971, 2971, 2971, 2971, 2971,
            2971, 2971, 2971, 2929, 2922, 1639, 1639, 1701, 1701, 1701, 1681, 1681, 1681, 1855, 2982, 1856, 1856, 2931,
            2961, 1701, 1701, 1683, 1683, 1683, 1683, 0, 2994, 2994, 2994, 2963, 2926, 2993, 1962, 1960, 1961, 2919,
            2957, 2957, 2918, 2941, 2921, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2589, 2589, 2589, 2589, 0,
            0, 0, 0, 0, 2901, 0, 2945, 2951, 2950, 2950, 2949, 2947, 2953, 2946, 2948, 2952, 2972, 3358, 3358, 3358,
            3358, 3595, 3595, 3595, 3595, 3595, 3595, 3421, 3421, 3421, 3425, 3425, 3422, 3422, 3423, 3423, 3420, 3428,
            3428, 3428, 3430, 3429, 3427, 3426, 3431, 3434, 3433, 0, 3435, 3432, 3440, 3437, 3438, 3436, 3439, 1701,
            1643, 1701, 1701, 1701, 1701, 1701, 0, 2902, 3357, 3357, 0, 0, 0, 0, 0, 0, 0, 0, 1681, 1681, 1681, 1681, 0,
            3357, 3357, 3357, 3357, 3357, 3357, 3400, 3395, 3394, 3403, 4970, 4971, 3401, 3402, 3396, 3399, 4972, 3390,
            3390, 4973, 4974, 4975, 0, 3397, 3397, 3397, 3405, 3406, 3408, 3407, 0, 0, 0, 0, 0, 3409, 3410, 3359, 3359,
            0, 3393, 0, 3392, 3392, 3391, 3391, 3391, 3391, 3391, 3391, 3391, 3391, 3391, 0, 3414, 3413, 3412, 3412,
            3412, 3411, 3411, 3411, 3429, 0, 3429, 3429, 3445, 3357, 3357, 3357, 3415, 3415, 3415, 3415, 3416, 3416,
            3419, 3419, 3418, 3417, 0, 2489, 4541, 3593, 0, 0, 0, 3780, 3789, 3790, 3791, 3792, 3793, 0, 0, 0, 0, 3866,
            3838, 3838, 3838, 3837, 3837, 3837, 3844, 3844, 3844, 3845, 3845, 3845, 3867, 3867, 3839, 3839, 3843, 3843,
            3840, 3840, 3842, 3842, 3841, 3841, 3868, 3868, 3846, 0, 3414, 3413, 4969, 0, 0, 0, 4542, 4543, 0, 0, 1701,
            1701, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4602, 4544, 4546, 4545,
            4545, 4545, 4688, 0, 0, 0, 4687, 1630, 4966, 4965, 1701, 0, 4968, 4967, 4783, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4958, 4958, 4958, 4958, 0, 3441, 0, 0, 2986, 1361, 0, 5108, 5108
        };

        private const int MinIndex = -65;

        private static readonly Dictionary<int, int[]> ProjectileOwners = new()
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
            { ProjectileID.DD2JavelinHostile, new int[] { NPCID.DD2JavelinstT1 } },
            { ProjectileID.DD2JavelinHostileT3, new int[] { NPCID.DD2JavelinstT1 } },
            { ProjectileID.DD2BetsyFireball, new int[] { NPCID.DD2Betsy } },
            { ProjectileID.DD2BetsyFlameBreath, new int[] { NPCID.DD2Betsy } },
            { ProjectileID.HallowBossLastingRainbow, new int[] { NPCID.HallowBoss } },
            { ProjectileID.HallowBossDeathAurora, new int[] { NPCID.HallowBoss } },
            { ProjectileID.HallowBossRainbowStreak, new int[] { NPCID.HallowBoss } },
            { ProjectileID.RockGolemRock, new int[] { NPCID.RockGolem } },
            { ProjectileID.FairyQueenHymn, new int[] { NPCID.HallowBoss } },
            { ProjectileID.FairyQueenSunDance, new int[] { NPCID.HallowBoss } },
            { ProjectileID.FairyQueenLance, new int[] { NPCID.HallowBoss } },
            { ProjectileID.QueenSlimeGelAttack, new int[] { NPCID.QueenSlimeBoss } },
            { ProjectileID.DeerclopsIceSpike, new int[] { NPCID.Deerclops } },
            { ProjectileID.DeerclopsRangedProjectile, new int[] { NPCID.Deerclops } },
            { ProjectileID.InsanityShadowFriendly, new int[] { NPCID.Deerclops } },
            { ProjectileID.InsanityShadowHostile, new int[] { NPCID.Deerclops } },
            { ProjectileID.QueenBeeStinger, new int[] { NPCID.QueenBee } },
            { ProjectileID.SandBallFalling, new int[] { NPCID.Antlion } },
            { ProjectileID.BloodNautilusShot, new int[] { NPCID.BloodNautilus } },
            { ProjectileID.BloodNautilusTears, new int[] { NPCID.BloodNautilus } },
            { ProjectileID.BloodShot, new int[] { NPCID.BloodSquid, NPCID.GoblinShark } },
            { ProjectileID.DandelionSeed, new int[] { NPCID.Dandelion } },
            { ProjectileID.TorchGod, new int[] { NPCID.TorchGod } },
            { ProjectileID.QueenSlimeMinionBlueSpike, new int[] { NPCID.QueenSlimeBoss } },
            { ProjectileID.QueenSlimeMinionPinkBall, new int[] { NPCID.QueenSlimeBoss } },
        };

        private static readonly int[] Banners =
        {
            1615, 1616, 1617, 1618, 1619, 1620, 1621, 1623, 1624, 1625, 1626, 1627, 1629, 1630, 1631, 1632, 1633, 1634,
            1635, 1636, 1637, 1638, 1639, 1640, 1641, 1642, 1643, 1644, 1645, 1646, 1647, 1648, 1649, 1650, 1651, 1652,
            1653, 1654, 1655, 1656, 1658, 1659, 1660, 1661, 1662, 1663, 1664, 1665, 1666, 1667, 1668, 1669, 1670, 1671,
            1672, 1673, 1674, 1675, 1676, 1677, 1678, 1679, 1680, 1681, 1682, 1683, 1684, 1685, 1686, 1687, 1688, 1689,
            1690, 1691, 1692, 1693, 1694, 1695, 1696, 1697, 1698, 1699, 1700, 1701, 2897, 2898, 2899, 2900, 2901, 2902,
            2904, 2905, 2906, 2907, 2908, 2909, 2910, 2911, 2912, 2913, 2914, 2915, 2916, 2917, 2918, 2919, 2920, 2921,
            2922, 2923, 2924, 2925, 2926, 2927, 2928, 2929, 2930, 2931, 2932, 2933, 2934, 2935, 2936, 2937, 2938, 2939,
            2940, 2941, 2942, 2943, 2944, 2945, 2946, 2947, 2948, 2949, 2950, 2951, 2952, 2953, 2954, 2955, 2956, 2957,
            2958, 2960, 2961, 2962, 2963, 2964, 2965, 2966, 2967, 2968, 2969, 2970, 2971, 2972, 2973, 2974, 2975, 2976,
            2977, 2978, 2979, 2980, 2981, 2982, 2983, 2984, 2985, 2986, 2987, 2988, 2992, 2993, 2994, 3390, 3391, 3392,
            3393, 3394, 3395, 3396, 3397, 3399, 3400, 3401, 3402, 3403, 3405, 3406, 3407, 3408, 3409, 3410, 3411, 3412,
            3413, 3414, 3415, 3416, 3417, 3418, 3419, 3420, 3421, 3422, 3423, 3425, 3426, 3427, 3428, 3429, 3430, 3431,
            3432, 3433, 3434, 3435, 3436, 3437, 3438, 3439, 3440, 3441, 3442, 3443, 3444, 3445, 3446, 3447, 3448, 3449,
            3450, 3451, 3452, 3593, 3594, 3780, 3789, 3790, 3791, 3792, 3793, 3837, 3838, 3839, 3840, 3841, 3842, 3843,
            3844, 3845, 3846, 4541, 4542, 4543, 4544, 4545, 4546, 4602, 4687, 4688, 4965, 4966, 4967, 4968, 4969, 4970,
            4971, 4972, 4973, 4974, 4975, 4976, 4977
        };

        private static readonly int[] Trophies =
        {
            1360, 1361, 1362, 1363, 1364, 1365, 1366, 1367, 1368, 1369, 1370, 1371, 1855, 1856, 1960, 1961, 1962, 2489,
            2589, 3357, 3358, 3359, 3595, 3866, 3867, 3868, 4783, 4958, 5108
        };

        private static readonly int[] Bosses =
        {
            4, 13, 266, 35, 222, 113, 134, 127, 125, 126, 262, 245, 325, 327, 345, 346, 344, 50, 370, 439, 392, 491,
            396, 551, 564, 576, 636, 657, 668
        };

        private static readonly Dictionary<int, int> Normalizer = new()
        {
            { 4, 4 }, { 5, 4 }, { 13, 13 }, { 14, 13 }, { 15, 13 }, { 666, 13 }, { 266, 266 }, { 267, 266 }, { 35, 35 },
            { 36, 35 }, { 113, 113 }, { 114, 113 }, { 115, 113 }, { 116, 113 }, { 117, 113 }, { 118, 113 },
            { 119, 113 }, { 134, 134 }, { 135, 134 }, { 136, 134 }, { 139, 134 }, { 127, 127 }, { 128, 127 },
            { 129, 127 }, { 130, 127 }, { 131, 127 }, { 262, 262 }, { 263, 262 }, { 264, 262 }, { 265, 262 },
            { 246, 246 }, { 247, 246 }, { 249, 246 }, { -15, 77 }, { 77, 77 }, { 163, 163 }, { 238, 163 }, { 239, 239 },
            { 240, 239 }, { 39, 39 }, { 40, 39 }, { 41, 39 }, { 85, 85 }, { 629, 85 }, { -23, 173 }, { -22, 173 },
            { 173, 173 }, { 62, 62 }, { 66, 62 }, { -43, 2 }, { -42, 2 }, { -41, 2 }, { -40, 2 }, { -39, 2 },
            { -38, 2 }, { 2, 2 }, { 190, 2 }, { 191, 2 }, { 192, 2 }, { 193, 2 }, { 194, 2 }, { 317, 2 }, { 318, 2 },
            { -12, 6 }, { -11, 6 }, { 6, 6 }, { 161, 161 }, { 431, 161 }, { 259, 259 }, { 260, 259 }, { 261, 259 },
            { 29, 29 }, { 30, 29 }, { -65, 42 }, { -64, 42 }, { -63, 42 }, { -62, 42 }, { -61, 42 }, { -60, 42 },
            { -59, 42 }, { -58, 42 }, { -57, 42 }, { -56, 42 }, { -17, 42 }, { -16, 42 }, { 42, 42 }, { 231, 42 },
            { 232, 42 }, { 233, 42 }, { 234, 42 }, { 235, 42 }, { 24, 24 }, { 25, 24 }, { 236, 236 }, { 237, 236 },
            { 198, 198 }, { 199, 198 }, { 170, 170 }, { 171, 170 }, { 180, 170 }, { -53, 21 }, { -52, 21 }, { -51, 21 },
            { -50, 21 }, { -49, 21 }, { -48, 21 }, { -47, 21 }, { -46, 21 }, { 21, 21 }, { 201, 21 }, { 202, 21 },
            { 203, 21 }, { 322, 21 }, { 323, 21 }, { 324, 21 }, { 449, 21 }, { 450, 21 }, { 451, 21 }, { 452, 21 },
            { 32, 32 }, { 33, 32 }, { 1, 1 }, { 302, 1 }, { 333, 1 }, { 334, 1 }, { 335, 1 }, { 336, 1 }, { 164, 164 },
            { 165, 164 }, { 254, 254 }, { 255, 254 }, { 158, 158 }, { 159, 158 }, { 195, 195 }, { 196, 195 },
            { 98, 98 }, { 99, 98 }, { 100, 98 }, { 10, 10 }, { 11, 10 }, { 12, 10 }, { 95, 10 }, { 96, 10 }, { 97, 10 },
            { 87, 87 }, { 88, 87 }, { 89, 87 }, { 90, 87 }, { 91, 87 }, { 92, 87 }, { -55, 3 }, { -54, 3 }, { -45, 3 },
            { -44, 3 }, { -37, 3 }, { -36, 3 }, { -35, 3 }, { -34, 3 }, { -33, 3 }, { -32, 3 }, { -31, 3 }, { -30, 3 },
            { -29, 3 }, { -28, 3 }, { -27, 3 }, { -26, 3 }, { 3, 3 }, { 132, 3 }, { 186, 3 }, { 187, 3 }, { 188, 3 },
            { 189, 3 }, { 200, 3 }, { 319, 3 }, { 320, 3 }, { 321, 3 }, { 331, 3 }, { 332, 3 }, { 430, 3 }, { 432, 3 },
            { 433, 3 }, { 434, 3 }, { 435, 3 }, { 436, 3 }, { 590, 3 }, { 591, 3 }, { 632, 3 }, { 327, 327 },
            { 328, 327 }, { 50, 50 }, { 535, 50 }, { 370, 370 }, { 371, 370 }, { 372, 370 }, { 373, 370 }, { 273, 273 },
            { 274, 273 }, { 275, 273 }, { 276, 273 }, { 94, 94 }, { 112, 94 }, { -25, 183 }, { -24, 183 }, { 183, 183 },
            { 7, 7 }, { 8, 7 }, { 9, 7 }, { 285, 285 }, { 286, 285 }, { 277, 277 }, { 278, 277 }, { 279, 277 },
            { 280, 277 }, { 383, 383 }, { 384, 383 }, { -5, 16 }, { 16, 16 }, { 283, 283 }, { 284, 283 }, { 348, 348 },
            { 349, 348 }, { 281, 281 }, { 282, 281 }, { 269, 269 }, { 270, 269 }, { 271, 269 }, { 272, 269 },
            { 305, 305 }, { 306, 305 }, { 307, 305 }, { 308, 305 }, { 309, 305 }, { 310, 305 }, { 311, 305 },
            { 312, 305 }, { 313, 305 }, { 314, 305 }, { -2, 121 }, { -1, 121 }, { 121, 121 }, { 45, 45 }, { 665, 45 },
            { 338, 338 }, { 339, 338 }, { 340, 338 }, { 439, 439 }, { 440, 439 }, { 454, 439 }, { 455, 439 },
            { 456, 439 }, { 457, 439 }, { 458, 439 }, { 459, 439 }, { 521, 439 }, { 522, 439 }, { 523, 439 },
            { 392, 392 }, { 393, 392 }, { 394, 392 }, { 395, 392 }, { 491, 491 }, { 492, 491 }, { 471, 471 },
            { 472, 471 }, { 498, 498 }, { 499, 498 }, { 500, 498 }, { 501, 498 }, { 502, 498 }, { 503, 498 },
            { 504, 498 }, { 505, 498 }, { 506, 498 }, { 496, 496 }, { 497, 496 }, { 477, 477 }, { 478, 477 },
            { 479, 477 }, { 513, 513 }, { 514, 513 }, { 515, 513 }, { 510, 510 }, { 511, 510 }, { 512, 510 },
            { 509, 509 }, { 581, 509 }, { 508, 508 }, { 580, 508 }, { 524, 524 }, { 525, 524 }, { 526, 524 },
            { 527, 524 }, { 528, 528 }, { 529, 528 }, { 530, 530 }, { 531, 530 }, { 402, 402 }, { 403, 402 },
            { 404, 402 }, { 409, 409 }, { 410, 409 }, { 405, 405 }, { 406, 405 }, { 412, 412 }, { 413, 412 },
            { 414, 412 }, { 416, 416 }, { 516, 416 }, { 518, 416 }, { 519, 416 }, { 216, 216 }, { 662, 216 },
            { -14, 31 }, { -13, 31 }, { 31, 31 }, { 294, 31 }, { 295, 31 }, { 296, 31 }, { 396, 396 }, { 397, 396 },
            { 398, 396 }, { 399, 396 }, { 400, 396 }, { 401, 396 }, { 555, 555 }, { 556, 555 }, { 557, 555 },
            { 552, 552 }, { 553, 552 }, { 554, 552 }, { 566, 566 }, { 567, 566 }, { 570, 570 }, { 571, 570 },
            { 574, 574 }, { 575, 574 }, { 572, 572 }, { 573, 572 }, { 568, 568 }, { 569, 568 }, { 558, 558 },
            { 559, 558 }, { 560, 558 }, { 561, 561 }, { 562, 561 }, { 563, 561 }, { 564, 564 }, { 565, 564 },
            { 576, 576 }, { 577, 576 }, { 621, 621 }, { 622, 621 }, { 623, 621 }, { 657, 657 }, { 658, 657 },
            { 659, 657 }, { 660, 657 }, { -21, 176 }, { -20, 176 }, { -19, 176 }, { -18, 176 }, { 176, 176 },
            { 668, 668 }, { 669, 668 }, { 222, 222 }, { 210, 222 }, { 211, 222 }, { 109, 109 }, { 378, 109 }
        };

        private static readonly Dictionary<string, ModBannersData> ModBannersData = new()
        {
            {
                "CalamityMod",
                new()
 {
                    ModName = "CalamityMod",
                    Banners = new[]
                    {
                        "AcidEelBanner", "AeroSlimeBanner", "AmberCrawlerBanner", "AmethystCrawlerBanner",
                        "AnthozoanCrabBanner", "AquaticAberrationBanner", "AquaticUrchinBanner", "AriesBanner",
                        "ArmoredDiggerBanner", "AstralachneaBanner", "AstralProbeBanner", "AstralSlimeBanner",
                        "AtlasBanner", "BabyFlakCrabBanner", "BabyGhostBellBanner", "BelchingCoralBanner",
                        "BigSightseerBanner", "BlindedAnglerBanner", "BloatfishBanner", "BloomSlimeBanner",
                        "BobbitWormBanner", "BohldohrBanner", "BoxJellyfishBanner", "CalamityEyeBanner",
                        "CatfishBanner", "ChaoticPufferBanner", "CharredSlimeBanner", "ClamBanner",
                        "CloudElementalBanner", "CnidrionBanner", "ColossalSquidBanner", "CosmicElementalBanner",
                        "CrimulanBlightSlimeBanner", "CryonBanner", "CryoSlimeBanner", "CrystalCrawlerBanner",
                        "CultistAssassinBanner", "CuttlefishBanner", "DespairStoneBanner", "DevilFishBanner",
                        "DiamondCrawlerBanner", "EarthElementalBanner", "EbonianBlightSlimeBanner", "EidolistBanner",
                        "EidolonWyrmJuvenileBanner", "EmeraldCrawlerBanner", "EutrophicRayBanner",
                        "FearlessGoldfishWarriorBanner", "FlakCrabBanner", "FlounderBanner", "FrogfishBanner",
                        "FusionFeederBanner", "GammaSlimeBanner", "GhostBellBanner", "GiantSquidBanner",
                        "GnasherBanner", "GulperEelBanner", "HadarianBanner", "HeatSpiritBanner", "HiveBanner",
                        "IceClasperBanner", "ImpiousImmolatorBanner", "IrradiatedSlimeBanner", "LaserfishBanner",
                        "LuminousCorvinaBanner", "MantisBanner", "MantisShrimpBanner", "MelterBanner",
                        "MirageJellyBanner", "MorayEelBanner", "NovaBanner", "NuclearToadBanner", "OarfishBanner",
                        "OrthoceraBanner", "OverloadedSoldierBanner", "PerennialSlimeBanner", "PestilentSlimeBanner",
                        "PhantomSpiritBanner", "PiggyBanner", "PlaguebringerBanner", "PlagueChargerBanner",
                        "PlagueshellBanner", "PrismBackBanner", "ProfanedEnergyBanner", "RadiatorBanner",
                        "ReaperSharkBanner", "RimehoundBanner", "RotdogBanner", "RubyCrawlerBanner",
                        "SapphireCrawlerBanner", "ScornEaterBanner", "ScryllarBanner", "SeaFloatyBanner",
                        "SeaSerpentBanner", "SeaUrchinBanner", "ShockstormShuttleBanner", "SkyfinBanner",
                        "SmallSightseerBanner", "SoulSlurperBanner", "StellarCulexBanner", "StormlionBanner",
                        "SulphurousSkaterBanner", "SunskaterBanner", "TopazCrawlerBanner", "ToxicMinnowBanner",
                        "TrasherBanner", "TrilobiteBanner", "ViperfishBanner", "VirulingBanner", "WaterLeechBanner",
                        "WulfrumDroneBanner", "WulfrumGyratorBanner", "WulfrumHovercraftBanner", "WulfrumPylonBanner",
                        "WulfrumRoverBanner",
                    },
                    Trophies = new[]
                    {
                        "AnahitaTrophy", "ApolloTrophy", "AquaticScourgeTrophy", "AresTrophy", "ArtemisTrophy",
                        "AstrumAureusTrophy", "AstrumDeusTrophy", "BrimstoneElementalTrophy", "CalamitasTrophy",
                        "CataclysmTrophy", "CatastropheTrophy", "CeaselessVoidTrophy", "CrabulonTrophy",
                        "CryogenTrophy", "DesertScourgeTrophy", "DevourerofGodsTrophy", "DragonfollyTrophy",
                        "HiveMindTrophy", "LeviathanTrophy", "OldDukeTrophy", "PerforatorTrophy",
                        "PlaguebringerGoliathTrophy", "PolterghastTrophy", "ProfanedGuardianTrophy", "ProvidenceTrophy",
                        "RavagerTrophy", "SignusTrophy", "SlimeGodTrophy", "SupremeCalamitasTrophy",
                        "SupremeCataclysmTrophy", "SupremeCatastropheTrophy", "ThanatosTrophy", "WeaverTrophy",
                        "YharonTrophy", "CragmawMireTrophy", "GiantClamTrophy", "GreatSandSharkTrophy", "MaulerTrophy",
                        "NuclearTerrorTrophy",
                    },
                    Normalizer = new()
                    {
                        { "AdultEidolonWyrmBody", "AdultEidolonWyrmBody" },
                        { "AdultEidolonWyrmBodyAlt", "AdultEidolonWyrmBody" },
                        { "AdultEidolonWyrmHead", "AdultEidolonWyrmBody" },
                        { "AdultEidolonWyrmTail", "AdultEidolonWyrmBody" }, { "Anahita", "Anahita" },
                        { "AnahitasIceShield", "Anahita" }, { "AquaticScourgeBody", "AquaticScourgeBody" },
                        { "AquaticScourgeBodyAlt", "AquaticScourgeBody" },
                        { "AquaticScourgeHead", "AquaticScourgeBody" }, { "AquaticScourgeTail", "AquaticScourgeBody" },
                        { "AresBody", "AresBody" }, { "AresGaussNuke", "AresBody" }, { "AresLaserCannon", "AresBody" },
                        { "AresPlasmaFlamethrower", "AresBody" }, { "AresTeslaCannon", "AresBody" },
                        { "ArmoredDiggerBody", "ArmoredDiggerBody" }, { "ArmoredDiggerHead", "ArmoredDiggerBody" },
                        { "ArmoredDiggerTail", "ArmoredDiggerBody" }, { "AstralachneaGround", "AstralachneaGround" },
                        { "AstralachneaWall", "AstralachneaGround" }, { "AstrumAureus", "AstrumAureus" },
                        { "AstrumDeusBody", "AstrumDeusBody" }, { "AstrumDeusHead", "AstrumDeusBody" },
                        { "AstrumDeusTail", "AstrumDeusBody" }, { "AureusSpawn", "AstrumAureus" },
                        { "BloodwormFleeing", "BloodwormNormal" }, { "BloodwormNormal", "BloodwormNormal" },
                        { "BobbitWormHead", "BobbitWormHead" }, { "BobbitWormSegment", "BobbitWormHead" },
                        { "Brimling", "BrimstoneElemental" }, { "BrimstoneElemental", "BrimstoneElemental" },
                        { "BrimstoneHeart", "BrimstoneElemental" }, { "Bumblefuck", "Bumblefuck" },
                        { "Bumblefuck2", "Bumblefuck" }, { "CalamitasClone", "CalamitasClone" },
                        { "CeaselessVoid", "CeaselessVoid" }, { "CorruptSlimeSpawn", "SlimeGodCore" },
                        { "CorruptSlimeSpawn2", "SlimeGodCore" }, { "CosmicGuardianBody", "DevourerofGodsBody" },
                        { "CosmicGuardianHead", "DevourerofGodsBody" }, { "CosmicGuardianTail", "DevourerofGodsBody" },
                        { "CosmicLantern", "Signus" }, { "CosmicMine", "Signus" }, { "CrabShroom", "Crabulon" },
                        { "Crabulon", "Crabulon" }, { "CrimsonSlimeSpawn", "SlimeGodCore" },
                        { "CrimsonSlimeSpawn2", "SlimeGodCore" }, { "CrimulanSlimeGod", "SlimeGodCore" },
                        { "Cryogen", "Cryogen" }, { "CryogenShield", "Cryogen" }, { "DankCreeper", "HiveMind" },
                        { "DarkEnergy", "CeaselessVoid" }, { "DarkHeart", "HiveMind" },
                        { "DesertNuisanceBody", "DesertScourgeBody" }, { "DesertNuisanceHead", "DesertScourgeBody" },
                        { "DesertNuisanceTail", "DesertScourgeBody" }, { "DesertScourgeBody", "DesertScourgeBody" },
                        { "DesertScourgeHead", "DesertScourgeBody" }, { "DesertScourgeTail", "DesertScourgeBody" },
                        { "DevilFish", "DevilFish" }, { "DevilFishAlt", "DevilFish" },
                        { "DevourerofGodsBody", "DevourerofGodsBody" }, { "DevourerofGodsHead", "DevourerofGodsBody" },
                        { "DevourerofGodsTail", "DevourerofGodsBody" }, { "EbonianSlimeGod", "SlimeGodCore" },
                        { "EidolonWyrmBody", "EidolonWyrmBody" }, { "EidolonWyrmBodyAlt", "EidolonWyrmBody" },
                        { "EidolonWyrmHead", "EidolonWyrmBody" }, { "EidolonWyrmTail", "EidolonWyrmBody" },
                        { "FlamePillar", "RavagerBody" }, { "GulperEelBody", "GulperEelBody" },
                        { "GulperEelBodyAlt", "GulperEelBody" }, { "GulperEelHead", "GulperEelBody" },
                        { "GulperEelTail", "GulperEelBody" }, { "Hive", "Hive" }, { "HiveBlob", "HiveMind" },
                        { "HiveBlob2", "HiveMind" }, { "HiveCyst", "HiveMind" }, { "Hiveling", "Hive" },
                        { "HiveMind", "HiveMind" }, { "Leviathan", "Leviathan" }, { "LeviathanStart", "Leviathan" },
                        { "OarfishBody", "OarfishBody" }, { "OarfishHead", "OarfishBody" },
                        { "OarfishTail", "OarfishBody" }, { "OldDuke", "OldDuke" }, { "OldDukeToothBall", "OldDuke" },
                        { "PerforatorBodyLarge", "PerforatorHive" }, { "PerforatorBodyMedium", "PerforatorHive" },
                        { "PerforatorBodySmall", "PerforatorHive" }, { "PerforatorCyst", "PerforatorHive" },
                        { "PerforatorHeadLarge", "PerforatorHive" }, { "PerforatorHeadMedium", "PerforatorHive" },
                        { "PerforatorHeadSmall", "PerforatorHive" }, { "PerforatorHive", "PerforatorHive" },
                        { "PerforatorTailLarge", "PerforatorHive" }, { "PerforatorTailMedium", "PerforatorHive" },
                        { "PerforatorTailSmall", "PerforatorHive" }, { "PhantomFuckYou", "Polterghast" },
                        { "PhantomSpirit", "PhantomSpirit" }, { "PhantomSpiritL", "PhantomSpirit" },
                        { "PhantomSpiritM", "PhantomSpirit" }, { "PhantomSpiritS", "PhantomSpirit" },
                        { "PlaguebringerGoliath", "PlaguebringerGoliath" }, { "PlagueCharger", "PlagueCharger" },
                        { "PlagueChargerLarge", "PlagueCharger" }, { "PlagueHomingMissile", "PlaguebringerGoliath" },
                        { "PlagueMine", "PlaguebringerGoliath" }, { "Polterghast", "Polterghast" },
                        { "PolterghastHook", "Polterghast" }, { "PolterPhantom", "Polterghast" },
                        { "ProfanedEnergyBody", "ProfanedEnergyBody" },
                        { "ProfanedEnergyLantern", "ProfanedEnergyBody" },
                        { "ProfanedGuardianCommander", "ProfanedGuardianCommander" },
                        { "ProfanedGuardianDefender", "ProfanedGuardianCommander" },
                        { "ProfanedGuardianHealer", "ProfanedGuardianCommander" }, { "Providence", "Providence" },
                        { "ProvSpawnDefense", "Providence" }, { "ProvSpawnHealer", "Providence" },
                        { "ProvSpawnOffense", "Providence" }, { "RavagerBody", "RavagerBody" },
                        { "RavagerClawLeft", "RavagerBody" }, { "RavagerClawRight", "RavagerBody" },
                        { "RavagerHead", "RavagerBody" }, { "RavagerHead2", "RavagerBody" },
                        { "RavagerLegLeft", "RavagerBody" }, { "RavagerLegRight", "RavagerBody" },
                        { "RockPillar", "RavagerBody" }, { "Scryllar", "Scryllar" }, { "ScryllarRage", "Scryllar" },
                        { "SeaSerpent1", "SeaSerpent1" }, { "SeaSerpent2", "SeaSerpent1" },
                        { "SeaSerpent3", "SeaSerpent1" }, { "SeaSerpent4", "SeaSerpent1" },
                        { "SeaSerpent5", "SeaSerpent1" }, { "SepulcherArm", "SupremeCalamitas" },
                        { "SepulcherBody", "SupremeCalamitas" }, { "SepulcherBodyEnergyBall", "SupremeCalamitas" },
                        { "SepulcherHead", "SupremeCalamitas" }, { "SepulcherTail", "SupremeCalamitas" },
                        { "Signus", "Signus" }, { "SlimeGodCore", "SlimeGodCore" },
                        { "SoulSeeker", "SupremeCalamitas" }, { "SoulSeekerSupreme", "SupremeCalamitas" },
                        { "SplitCrimulanSlimeGod", "SlimeGodCore" }, { "SplitEbonianSlimeGod", "SlimeGodCore" },
                        { "StormWeaverBody", "StormWeaverBody" }, { "StormWeaverHead", "StormWeaverBody" },
                        { "StormWeaverTail", "StormWeaverBody" }, { "SulphurousSharkron", "OldDuke" },
                        { "SupremeCalamitas", "SupremeCalamitas" }, { "ThanatosBody1", "ThanatosHead" },
                        { "ThanatosBody2", "ThanatosHead" }, { "ThanatosHead", "ThanatosHead" },
                        { "ThanatosTail", "ThanatosHead" },
                    },
                    UniqueBanners = new()
                    {
                        { "ArmoredDiggerBody", "ArmoredDiggerBanner" }, { "AstralachneaGround", "AstralachneaBanner" },
                        { "BobbitWormHead", "BobbitWormBanner" }, { "CrawlerAmber", "AmberCrawlerBanner" },
                        { "CrawlerAmethyst", "AmethystCrawlerBanner" }, { "CrawlerCrystal", "CrystalCrawlerBanner" },
                        { "CrawlerDiamond", "DiamondCrawlerBanner" }, { "CrawlerEmerald", "EmeraldCrawlerBanner" },
                        { "CrawlerRuby", "RubyCrawlerBanner" }, { "CrawlerSapphire", "SapphireCrawlerBanner" },
                        { "CrawlerTopaz", "TopazCrawlerBanner" }, { "EidolonWyrmBody", "EidolonWyrmJuvenileBanner" },
                        { "GulperEelBody", "GulperEelBanner" }, { "Horse", "EarthElementalBanner" },
                        { "OarfishBody", "OarfishBanner" }, { "PlaguebringerMiniboss", "PlaguebringerBanner" },
                        { "ProfanedEnergyBody", "ProfanedEnergyBanner" }, { "SeaSerpent1", "SeaSerpentBanner" },
                        { "ThiccWaifu", "CloudElementalBanner" },
                    },
                    UniqueTrophies = new()
                    {
                        { "AquaticScourgeBody", "AquaticScourgeTrophy" }, { "AresBody", "AresTrophy" },
                        { "AstrumDeusBody", "AstrumDeusTrophy" }, { "AuroraSpirit", "CryogenTrophy" },
                        { "Bumblefuck", "DragonfollyTrophy" }, { "CalamitasClone", "CalamitasTrophy" },
                        { "DesertScourgeBody", "DesertScourgeTrophy" },
                        { "DevourerofGodsBody", "DevourerofGodsTrophy" }, { "PerforatorHive", "PerforatorTrophy" },
                        { "ProfanedGuardianCommander", "ProfanedGuardianTrophy" }, { "RavagerBody", "RavagerTrophy" },
                        { "SlimeGodCore", "SlimeGodTrophy" }, { "StormWeaverBody", "WeaverTrophy" },
                        { "ThanatosHead", "ThanatosTrophy" },
                    },
                    Bosses = new[]
                    {
                        "Anahita", "Apollo", "AquaticScourgeBody", "AresBody", "Artemis", "AstrumAureus",
                        "AstrumDeusBody", "AuroraSpirit", "BrimstoneElemental", "Bumblefuck", "CalamitasClone",
                        "Cataclysm", "Catastrophe", "CeaselessVoid", "Crabulon", "CragmawMire", "Cryogen",
                        "DesertScourgeBody", "DevourerofGodsBody", "GiantClam", "GreatSandShark", "HiveMind",
                        "Leviathan", "Mauler", "NuclearTerror", "OldDuke", "PerforatorHive", "PlaguebringerGoliath",
                        "Polterghast", "ProfanedGuardianCommander", "Providence", "RavagerBody", "Signus",
                        "SlimeGodCore", "StormWeaverBody", "SupremeCalamitas", "SupremeCataclysm", "SupremeCatastrophe",
                        "ThanatosHead", "Yharon",
                    },
                    Projectiles = new()
                    {
                        { "BelchingCoralSpike", "BelchingCoral" }, { "CrabBoulder", "AnthozoanCrab" },
                        { "CragmawAcidDrop", "CragmawMire" }, { "CragmawBeam", "CragmawMire" },
                        { "CragmawBubble", "CragmawMire" }, { "CragmawExplosion", "CragmawMire" },
                        { "CragmawSpike", "CragmawMire" }, { "CragmawVibeCheckChain", "CragmawMire" },
                        { "CrimsonSpike", "SlimeGodCore" }, { "EarthRockBig", "Horse" }, { "EarthRockSmall", "Horse" },
                        { "FlakAcid", "FlakCrab" }, { "FlameBurstHostile", "RavagerBody" },
                        { "GammaAcid", "GammaSlime" }, { "GammaBeam", "GammaSlime" }, { "HorsWaterBlast", "Cnidrion" },
                        { "InkBombHostile", "ColossalSquid" }, { "InkPoisonCloud", "ColossalSquid" },
                        { "InkPoisonCloud2", "ColossalSquid" }, { "InkPoisonCloud3", "ColossalSquid" },
                        { "LightningCloud", "ThiccWaifu" }, { "MantisRing", "Mantis" },
                        { "MaulerAcidBubble", "Mauler" }, { "MaulerAcidDrop", "Mauler" },
                        { "NuclearBulletLarge", "NuclearTerror" }, { "NuclearBulletMedium", "NuclearTerror" },
                        { "NuclearToadGoo", "NuclearToad" }, { "OrthoceraStream", "Orthocera" },
                        { "PearlBurst", "GiantClam" }, { "PearlRain", "GiantClam" },
                        { "PufferExplosion", "ChaoticPuffer" }, { "StormMarkHostile", "ThiccWaifu" },
                        { "TornadoHostile", "ThiccWaifu" }, { "ToxicMinnowCloud", "ToxicMinnow" },
                        { "TrilobiteSpike", "Trilobite" }, { "ApolloChargeTelegraph", "Apollo" },
                        { "ApolloFireball", "Apollo" }, { "ApolloRocket", "Apollo" },
                        { "AresDeathBeamTelegraph", "AresBody" }, { "AresGaussNukeProjectile", "AresBody" },
                        { "AresGaussNukeProjectileSpark", "AresBody" }, { "AresLaserBeamStart", "AresBody" },
                        { "AresPlasmaBolt", "AresBody" }, { "AresPlasmaFireball", "AresBody" },
                        { "AresTeslaOrb", "AresBody" }, { "ArtemisChargeTelegraph", "Artemis" },
                        { "ArtemisDeathrayTelegraph", "Artemis" }, { "ArtemisLaser", "Artemis" },
                        { "AstralFlame", "AstrumAureus" }, { "AstralGodRay", "AstrumAureus" },
                        { "AstralLaser", "AstrumAureus" }, { "AstralShot2", "AstrumAureus" }, { "BigFlare", "Yharon" },
                        { "BigFlare2", "Yharon" }, { "BirbAura", "Bumblefuck" }, { "BirbAuraFlare", "Bumblefuck" },
                        { "BloodGeyser", "PerforatorHive" }, { "BrimstoneBall", "BrimstoneElemental" },
                        { "BrimstoneBarrage", "BrimstoneElemental" }, { "BrimstoneFire", "BrimstoneElemental" },
                        { "BrimstoneHellblast", "BrimstoneElemental" }, { "BrimstoneHellblast2", "BrimstoneElemental" },
                        { "BrimstoneHellfireball", "BrimstoneElemental" }, { "BrimstoneMonster", "BrimstoneElemental" },
                        { "BrimstoneRay", "BrimstoneElemental" }, { "BrimstoneTargetRay", "BrimstoneElemental" },
                        { "BrimstoneWave", "BrimstoneElemental" }, { "BrokenApolloLens", "Apollo" },
                        { "BrokenArtemisLens", "Artemis" }, { "DarkEnergyBall", "CeaselessVoid" },
                        { "DarkEnergyBall2", "CeaselessVoid" }, { "DarkOrb", "CeaselessVoid" },
                        { "DeusMine", "AstrumDeusBody" }, { "DeusRitualDrama", "AstrumDeusBody" },
                        { "DoGBeam", "DevourerofGodsBody" }, { "DoGBeamPortal", "DevourerofGodsBody" },
                        { "DoGDeath", "DevourerofGodsBody" }, { "DoGFire", "DevourerofGodsBody" },
                        { "DoGP1EndPortal", "DevourerofGodsBody" }, { "DoGTeleportRift", "DevourerofGodsBody" },
                        { "EssenceDust", "Signus" }, { "Flare", "Yharon" }, { "FlareBomb", "Yharon" },
                        { "FlareDust", "ProfanedGuardianCommander" }, { "FlareDust2", "Yharon" },
                        { "Flarenado", "Yharon" }, { "FrostMist", "Leviathan" },
                        { "GreatSandBlast", "AquaticScourgeBody" }, { "HealOrbProv", "Providence" },
                        { "HiveBombGoliath", "PlaguebringerGoliath" }, { "HolyAura", "Providence" },
                        { "HolyBlast", "Providence" }, { "HolyBomb", "Providence" }, { "HolyBurnOrb", "Providence" },
                        { "HolyFire", "Providence" }, { "HolyFire2", "Providence" }, { "HolyFlare", "Providence" },
                        { "HolyLight", "Providence" }, { "HolySpear", "Providence" }, { "IceBlast", "Cryogen" },
                        { "IceBomb", "Cryogen" }, { "IceRain", "Cryogen" }, { "IchorBlob", "PerforatorHive" },
                        { "IchorShot", "PerforatorHive" }, { "Infernado", "Yharon" }, { "Infernado2", "Yharon" },
                        { "InfernadoRevenge", "Yharon" }, { "LeviathanBomb", "Leviathan" },
                        { "LeviathanSpawner", "Leviathan" }, { "MoltenBlast", "Providence" },
                        { "MoltenBlob", "Providence" }, { "MushBomb", "Crabulon" }, { "MushBombFall", "Crabulon" },
                        { "OldDukeGore", "OldDuke" }, { "OldDukeSummonDrop", "OldDuke" },
                        { "OldDukeVortex", "OldDuke" }, { "OverlyDramaticDukeSummoner", "OldDuke" },
                        { "PhantomBlast", "Polterghast" }, { "PhantomBlast2", "Polterghast" },
                        { "PhantomGhostShot", "Polterghast" }, { "PhantomHookShot", "Polterghast" },
                        { "PhantomMine", "Polterghast" }, { "PhantomShot", "Polterghast" },
                        { "PhantomShot2", "Polterghast" }, { "PlagueExplosion", "PlaguebringerGoliath" },
                        { "PlagueStingerGoliath", "PlaguebringerGoliath" },
                        { "PlagueStingerGoliathV2", "PlaguebringerGoliath" }, { "ProfanedSpear", "Providence" },
                        { "ProvidenceCrystal", "Providence" }, { "ProvidenceCrystalShard", "Providence" },
                        { "ProvidenceHolyRay", "Providence" }, { "RavagerFlame", "RavagerBody" },
                        { "RedLightning", "Bumblefuck" }, { "RedLightningFeather", "Bumblefuck" },
                        { "SandBlast", "AquaticScourgeBody" }, { "SandPoisonCloud", "AquaticScourgeBody" },
                        { "SandPoisonCloudOldDuke", "OldDuke" }, { "SandTooth", "AquaticScourgeBody" },
                        { "SCalBrimstoneFireblast", "SupremeCalamitas" },
                        { "SCalBrimstoneGigablast", "SupremeCalamitas" }, { "SCalRitualDrama", "SupremeCalamitas" },
                        { "ScavengerLaser", "RavagerBody" }, { "ScavengerNuke", "RavagerBody" },
                        { "ShadeNimbusHostile", "HiveMind" }, { "ShaderainHostile", "HiveMind" },
                        { "ShadowflameFireball", "HiveMind" }, { "Shadowflamethrower", "HiveMind" },
                        { "SignusScythe", "Signus" }, { "SirenSong", "Leviathan" }, { "SkyFlare", "Yharon" },
                        { "SkyFlareRevenge", "Yharon" }, { "StormWeaverFrostWaveTelegraph", "StormWeaverBody" },
                        { "SupremeCataclysmFist", "SupremeCataclysm" },
                        { "SupremeCatastropheSlash", "SupremeCatastrophe" }, { "SwirlingFire", "BrimstoneElemental" },
                        { "ThanatosBeamTelegraph", "ThanatosHead" }, { "ThanatosLaser", "ThanatosHead" },
                        { "ToxicCloud", "AquaticScourgeBody" }, { "UnstableCrimulanGlob", "SlimeGodCore" },
                        { "UnstableEbonianGlob", "SlimeGodCore" }, { "VileClot", "HiveMind" },
                        { "WaterSpear", "Leviathan" }, { "YharonBulletHellVortex", "Yharon" },
                        { "YharonFireball", "Yharon" }, { "YharonFireball2", "Yharon" },
                    },
                    ModIngredients = new()
                    {
                        { "AcidEelBanner", "AcidRainBanner" }, { "AeroSlimeBanner", "CalamityPrehardmodeBanner" },
                        { "AmberCrawlerBanner", "CrawlerBanner" }, { "AmethystCrawlerBanner", "CrawlerBanner" },
                        { "AnthozoanCrabBanner", "FullSulphurousBanner" },
                        { "AquaticAberrationBanner", "CalamityHardmodeBanner" },
                        { "AquaticUrchinBanner", "SulphurousBanner" }, { "AriesBanner", "AstralBanner" },
                        { "ArmoredDiggerBanner", "CalamitySuperHardmodeBanner" },
                        { "AstralachneaBanner", "AstralBanner" }, { "AstralProbeBanner", "AstralBanner" },
                        { "AstralSlimeBanner", "AstralBanner" }, { "AtlasBanner", "AstralBanner" },
                        { "BabyFlakCrabBanner", "FullSulphurousBanner" },
                        { "BelchingCoralBanner", "FullSulphurousBanner" }, { "BigSightseerBanner", "AstralBanner" },
                        { "BlindedAnglerBanner", "CalamityHardmodeBanner" }, { "BloatfishBanner", "LargeAbyssBanner" },
                        { "BloomSlimeBanner", "TheCalamityBanner" }, { "BobbitWormBanner", "LargeAbyssBanner" },
                        { "BohldohrBanner", "CalamitySuperHardmodeBanner" },
                        { "BoxJellyfishBanner", "SmallAbyssBanner" }, { "CalamityEyeBanner", "BrimstoneBanner" },
                        { "CatfishBanner", "SulphurousBanner" }, { "ChaoticPufferBanner", "MediumAbyssBanner" },
                        { "CharredSlimeBanner", "CalamitySuperHardmodeBanner" }, { "ClamBanner", "SunkenBanner" },
                        { "CloudElementalBanner", "CalamitySuperHardmodeBanner" },
                        { "CnidrionBanner", "CalamityBeginnerBanner" }, { "ColossalSquidBanner", "LargeAbyssBanner" },
                        { "CosmicElementalBanner", "CalamityBeginnerBanner" }, { "CryonBanner", "CryoBanner" },
                        { "CryoSlimeBanner", "CryoBanner" }, { "CrystalCrawlerBanner", "CalamityHardmodeBanner" },
                        { "CultistAssassinBanner", "CalamityHardmodeBanner" },
                        { "CuttlefishBanner", "SmallAbyssBanner" }, { "DespairStoneBanner", "BrimstoneBanner" },
                        { "DevilFishBanner", "SmallAbyssBanner" }, { "DiamondCrawlerBanner", "CrawlerBanner" },
                        { "EarthElementalBanner", "CalamitySuperHardmodeBanner" },
                        { "EidolistBanner", "MediumAbyssBanner" }, { "EidolonWyrmJuvenileBanner", "LargeAbyssBanner" },
                        { "EmeraldCrawlerBanner", "CrawlerBanner" }, { "EutrophicRayBanner", "SunkenBanner" },
                        { "FearlessGoldfishWarriorBanner", "CalamityPrehardmodeBanner" },
                        { "FlakCrabBanner", "FullAcidRainBanner" }, { "FlounderBanner", "SulphurousBanner" },
                        { "FrogfishBanner", "CalamityBeginnerBanner" }, { "FusionFeederBanner", "AstralBanner" },
                        { "GammaSlimeBanner", "TheCalamityBanner" }, { "GhostBellBanner", "SunkenBanner" },
                        { "GiantSquidBanner", "CalamityPrehardmodeBanner" }, { "GnasherBanner", "SulphurousBanner" },
                        { "GulperEelBanner", "LargeAbyssBanner" }, { "HadarianBanner", "AstralBanner" },
                        { "HeatSpiritBanner", "BrimstoneBanner" }, { "HiveBanner", "AstralBanner" },
                        { "IceClasperBanner", "CryoBanner" }, { "ImpiousImmolatorBanner", "ProfanedBanner" },
                        { "IrradiatedSlimeBanner", "FullAcidRainBanner" }, { "LaserfishBanner", "MediumAbyssBanner" },
                        { "LuminousCorvinaBanner", "MediumAbyssBanner" }, { "MantisBanner", "AstralBanner" },
                        { "MantisShrimpBanner", "HardmodeBanner" }, { "MelterBanner", "PlagueBanner" },
                        { "MirageJellyBanner", "MediumAbyssBanner" }, { "MorayEelBanner", "SmallAbyssBanner" },
                        { "NovaBanner", "AstralBanner" }, { "NuclearToadBanner", "AcidRainBanner" },
                        { "OarfishBanner", "MediumAbyssBanner" }, { "OrthoceraBanner", "MediumAcidRainBanner" },
                        { "OverloadedSoldierBanner", "CalamityHardmodeBanner" },
                        { "PerennialSlimeBanner", "CalamitySuperHardmodeBanner" },
                        { "PestilentSlimeBanner", "PlagueBanner" }, { "PhantomSpiritBanner", "TheCalamityBanner" },
                        { "PiggyBanner", "CalamityPrehardmodeBanner" }, { "PlaguebringerBanner", "PlagueBanner" },
                        { "PlagueChargerBanner", "PlagueBanner" }, { "PlagueshellBanner", "PlagueBanner" },
                        { "PrismBackBanner", "SunkenBanner" }, { "ProfanedEnergyBanner", "ProfanedBanner" },
                        { "RadiatorBanner", "AcidRainBanner" }, { "ReaperSharkBanner", "LargeAbyssBanner" },
                        { "RimehoundBanner", "CalamityBeginnerBanner" }, { "RotdogBanner", "CalamityBeginnerBanner" },
                        { "RubyCrawlerBanner", "CrawlerBanner" }, { "SapphireCrawlerBanner", "CrawlerBanner" },
                        { "ScornEaterBanner", "ProfanedBanner" }, { "ScryllarBanner", "BrimstoneBanner" },
                        { "SeaFloatyBanner", "SunkenBanner" }, { "SeaSerpentBanner", "CalamityHardmodeBanner" },
                        { "SeaUrchinBanner", "CalamityBeginnerBanner" },
                        { "ShockstormShuttleBanner", "CalamityHardmodeBanner" }, { "SkyfinBanner", "AcidRainBanner" },
                        { "SmallSightseerBanner", "AstralBanner" }, { "SoulSlurperBanner", "BrimstoneBanner" },
                        { "StellarCulexBanner", "AstralBanner" }, { "StormlionBanner", "CalamityBeginnerBanner" },
                        { "SulphurousSkaterBanner", "FullAcidRainBanner" },
                        { "SunskaterBanner", "CalamityBeginnerBanner" }, { "TopazCrawlerBanner", "CrawlerBanner" },
                        { "ToxicMinnowBanner", "SmallAbyssBanner" }, { "TrasherBanner", "SulphurousBanner" },
                        { "TrilobiteBanner", "FullAcidRainBanner" }, { "ViperfishBanner", "SmallAbyssBanner" },
                        { "VirulingBanner", "PlagueBanner" }, { "WaterLeechBanner", "AcidRainBanner" },
                        { "WulfrumDroneBanner", "WulfrumBanner" }, { "WulfrumGyratorBanner", "WulfrumBanner" },
                        { "WulfrumHovercraftBanner", "WulfrumBanner" }, { "WulfrumPylonBanner", "WulfrumBanner" },
                        { "WulfrumRoverBanner", "WulfrumBanner" }, { "AnahitaTrophy", "CalamitySuperHardmodeTrophy" },
                        { "ApolloTrophy", "TheCalamityTrophy" }, { "AquaticScourgeTrophy", "CalamityHardmodeTrophy" },
                        { "AresTrophy", "TheCalamityTrophy" }, { "ArtemisTrophy", "TheCalamityTrophy" },
                        { "AstrumAureusTrophy", "CalamitySuperHardmodeTrophy" }, { "AstrumDeusTrophy", "CalamitySuperHardmodeTrophy" },
                        { "BrimstoneElementalTrophy", "CalamityHardmodeTrophy" }, { "CalamitasTrophy", "CalamityHardmodeTrophy" },
                        { "CataclysmTrophy", "CalamityHardmodeTrophy" }, { "CatastropheTrophy", "CalamityHardmodeTrophy" },
                        { "CeaselessVoidTrophy", "CalamityDevouringTrophy" }, { "CrabulonTrophy", "CalamityPrehardmodeTrophy" },
                        { "CryogenTrophy", "CalamityHardmodeTrophy" }, { "DesertScourgeTrophy", "CalamityPrehardmodeTrophy" },
                        { "DevourerofGodsTrophy", "CalamityDevouringTrophy" }, { "DragonfollyTrophy", "CalamityProfanedTrophy" }, 
                        { "LeviathanTrophy", "CalamitySuperHardmodeTrophy" }, { "OldDukeTrophy", "CalamityImmaculateTrophy" },
                        { "PlaguebringerGoliathTrophy", "CalamitySuperHardmodeTrophy" }, { "PolterghastTrophy", "CalamityImmaculateTrophy" },
                        { "ProfanedGuardianTrophy", "CalamityProfanedTrophy" }, { "ProvidenceTrophy", "CalamityProfanedTrophy" },
                        { "RavagerTrophy", "CalamitySuperHardmodeTrophy" }, { "SignusTrophy", "CalamityDevouringTrophy" },
                        { "SlimeGodTrophy", "CalamityPrehardmodeTrophy" }, { "SupremeCalamitasTrophy", "TheCalamityTrophy" },
                        { "SupremeCataclysmTrophy", "TheCalamityTrophy" }, { "SupremeCatastropheTrophy", "TheCalamityTrophy" },
                        { "ThanatosTrophy", "TheCalamityTrophy" }, { "WeaverTrophy", "CalamityDevouringTrophy" },
                        { "YharonTrophy", "TheCalamityTrophy" }, { "GiantClamTrophy", "CalamityPrehardmodeTrophy" },
                        { "GreatSandSharkTrophy", "CalamityHardmodeTrophy" }, { "MaulerTrophy", "CalamityImmaculateTrophy" },
                        { "NuclearTerrorTrophy", "CalamityImmaculateTrophy" },

                    },
                    MergedIngredients = new()
                    {
                        { "CalamityPrehardmodeBanner", "CalamityHardmodeBanner" },
                        { "CrawlerBanner", "CalamityBeginnerBanner" },
                        { "SulphurousBanner", "CalamityPrehardmodeBanner" },
                        { "SmallAbyssBanner", "CalamityPrehardmodeBanner" },
                        { "BrimstoneBanner", "CalamityPrehardmodeBanner" },
                        { "SunkenBanner", "CalamityBeginnerBanner" },
                        { "CalamityBeginnerBanner", "CalamityPrehardmodeBanner" },
                        { "WulfrumBanner", "CalamityBeginnerBanner" }, { "AstralBanner", "CalamityHardmodeBanner" },
                        { "PlagueBanner", "CalamitySuperHardmodeBanner" },
                        { "MediumAbyssBanner", "CalamitySuperHardmodeBanner" },
                        { "FullSulphurousBanner", "CalamityHardmodeBanner" },
                        { "CryoBanner", "CalamityHardmodeBanner" }, { "AcidRainBanner", "CalamityPrehardmodeBanner" },
                        { "CalamityHardmodeBanner", "CalamitySuperHardmodeBanner" },
                        { "CalamitySuperHardmodeBanner", "TheCalamityBanner" },
                        { "LargeAbyssBanner", "TheCalamityBanner" },
                        { "FullAcidRainBanner", "CalamitySuperHardmodeBanner" },
                        { "CalamityPrehardmodeTrophy", "CalamityHardmodeTrophy" },
                        { "CalamityHardmodeTrophy", "CalamitySuperHardmodeTrophy" },
                        { "CalamitySuperHardmodeTrophy", "CalamityImmaculateTrophy" },
                        { "CalamityProfanedTrophy", "CalamityImmaculateTrophy" },
                        { "CalamityDevouringTrophy", "CalamityImmaculateTrophy" },
                        { "CalamityImmaculateTrophy", "TheCalamityTrophy" },

                    }
                }
            }

        };

        public static bool TryMapNPCToBanner(int mobId, out int bannerId)
        {
            bannerId = 0;
            int mobIndex = mobId - MinIndex;
            if (mobIndex < 0 || mobIndex >= MobToBannerMapping.Length || MobToBannerMapping[mobIndex] == 0)
                return false;
            bannerId = MobToBannerMapping[mobIndex];
            return true;
        }

        public static bool TryMapModdedNPCToBanner(string mobName, string modName, out string bannerName)
        {
            bannerName = "";
            if (!ModBannersData.ContainsKey(modName))
                return false;
            if (ModBannersData[modName].UniqueBanners.ContainsKey(mobName))
            {
                bannerName = ModBannersData[modName].UniqueBanners[mobName];
            }
            else if (ModBannersData[modName].UniqueTrophies.ContainsKey(mobName))
            {
                bannerName = ModBannersData[modName].UniqueTrophies[mobName];
            }
            else if (ModBannersData[modName].Banners.Contains(mobName + "Banner"))
            {
                bannerName = mobName + "Banner";
            }
            else if (ModBannersData[modName].Trophies.Contains(mobName + "Trophy"))
            {
                bannerName = mobName + "Trophy";
            }
            else
                return false;

            return true;
        }

        public static bool IsVanillaBanner(int item) => Banners.Contains(item);

        public static bool IsVanillaTrophy(int item) => Trophies.Contains(item);

        public static bool IsModdedBanner(Item item)
            => IsInModList(item) && ModBannersData[item.ModItem.Mod.Name].Banners.Contains(item.ModItem.Name);

        public static bool IsModdedTrophy(Item item)
            => IsInModList(item) && ModBannersData[item.ModItem.Mod.Name].Trophies.Contains(item.ModItem.Name);

        public static bool IsInModList(Item item) => item.ModItem != null && ModBannersData.ContainsKey(item.ModItem.Mod.Name);

        public static bool IsInModList(Projectile proj) => proj.ModProjectile != null && ModBannersData.ContainsKey(proj.ModProjectile.Mod.Name);

        public static int GetVanillaProjectileOwner(int projectileId)
        {
            return ProjectileOwners.ContainsKey(projectileId) ? ProjectileOwners[projectileId][0] : -1;
        }

        public static string GetModProjectileOwner(Projectile proj)
        {
            if (IsInModList(proj) && ModBannersData[proj.ModProjectile.Mod.Name].Projectiles.ContainsKey(proj.ModProjectile.Name))
                return ModBannersData[proj.ModProjectile.Mod.Name].Projectiles[proj.ModProjectile.Name];
            return null;
        }

        public static int Normalize(int mobId) => Normalizer.ContainsKey(mobId) ? Normalizer[mobId] : mobId;

        public static string Normalize(string npcName, string modName)
        {
            return (ModBannersData.ContainsKey(modName) &&
                    ModBannersData[modName].Normalizer.ContainsKey(npcName))
                ? ModBannersData[modName].Normalizer[npcName]
                : npcName;
        }

        public static bool IsBoss(int mobId) => Bosses.Contains(mobId);

        public static bool IsBoss(string name, string modName)
            => ModBannersData.ContainsKey(modName) && ModBannersData[modName].Bosses.Contains(name);

        public static void AddOrAppend<TK>(this Dictionary<TK, float> dict, TK key, float value, int cap = -1)
        {
            if (dict.ContainsKey(key))
                dict[key] += value;
            else
                dict.Add(key, value);

            if (cap > 0 && dict[key] > cap)
                dict[key] = cap;
        }

        public static int[] GetModdedBannerIngredients(string name, string mod)
        {
            if(!ModBannersData.ContainsKey(mod))
                return Array.Empty<int>();
            return ModBannersData[mod].ModIngredients
                .Where(p => p.Value == name)
                .Select(p => ModLoader.GetMod(mod).Find<ModItem>(p.Key).Type)
                .ToArray();
        }

        public static int[] GetModdedBannerMergedIngredients(string name, string mod)
        {
            if (!ModBannersData.ContainsKey(mod))
                return Array.Empty<int>();
            return ModBannersData[mod].MergedIngredients
                .Where(p => p.Value == name)
                .Select(p => ModContent.Find<ModItem>("UltimateBannerMerging",p.Key).Type)
                .ToArray();
        }
    }
}
