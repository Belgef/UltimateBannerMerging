using Terraria;
using Terraria.ID;


namespace UltimateBannerMerging.Items
{
    public class HorrorTrophy : TrophyItem
    {
        public override string ShowName => "Horror Trophy";

        public override short[] TrophyIdList => new short[] 
        { 
            ItemID.EyeofCthulhuTrophy,
            WorldGen.crimson ? ItemID.BrainofCthulhuTrophy : ItemID.EaterofWorldsTrophy,
            ItemID.SkeletronTrophy
        };

        public override string[] TrophyFromModNames => new string [] { };

        public override int[] BossesID => new int[]
        {
            NPCID.EyeofCthulhu,
            NPCID.EaterofWorldsHead,
            NPCID.BrainofCthulhu,
            NPCID.SkeletronHand
        };
    }
    public class PreHardmodeTrophy : TrophyItem
    {
        public override string ShowName => "Pre Hardmode Trophy";

        public override short[] TrophyIdList => new short[]
        {
            ItemID.WallofFleshTrophy,
            ItemID.KingSlimeTrophy
        };

        public override string[] TrophyFromModNames => new string[]
        {
            nameof(HorrorTrophy),
        };

        public override int[] BossesID => new int[]
        {
            NPCID.EyeofCthulhu,
            NPCID.EaterofWorldsHead,
            NPCID.BrainofCthulhu,
            NPCID.SkeletronHand,
            NPCID.KingSlime,
            NPCID.WallofFlesh
        };
    }
    public class MechanicsTrophy : TrophyItem
    {
        public override string ShowName => "Mechanics Trophy";

        public override short[] TrophyIdList => new short[]
        {
            ItemID.DestroyerTrophy,
            ItemID.SpazmatismTrophy,
            ItemID.RetinazerTrophy,
            ItemID.SkeletronPrimeTrophy
        };

        public override string[] TrophyFromModNames => new string[] { };

        public override int[] BossesID => new int[]
        {
            NPCID.TheDestroyer,
            NPCID.Spazmatism,
            NPCID.Retinazer,
            NPCID.SkeletronPrime
        };
    }
    public class AncientTrophy : TrophyItem
    {
        public override string ShowName => "Ancient Trophy";

        public override short[] TrophyIdList => new short[]
        {
            ItemID.PlanteraTrophy,
            ItemID.GolemTrophy,
            ItemID.AncientCultistTrophy,
            ItemID.MoonLordTrophy
        };

        public override string[] TrophyFromModNames => new string[] {};

        public override int[] BossesID => new int[]
        {
            NPCID.Plantera,
            NPCID.Golem,
            NPCID.CultistBoss,
            NPCID.MoonLordHead,
            NPCID.MoonLordHand,
            NPCID.MoonLordFreeEye
        };
    }
    public class MoonTrophy : TrophyItem
    {
        public override string ShowName => "Moon Trophy";

        public override short[] TrophyIdList => new short[]
        {
            ItemID.MourningWoodTrophy,
            ItemID.PumpkingTrophy,
            ItemID.EverscreamTrophy,
            ItemID.IceQueenTrophy,
            ItemID.SantaNK1Trophy
        };

        public override string[] TrophyFromModNames => new string[] { };

        public override int[] BossesID => new int[]
        {
            NPCID.MourningWood,
            NPCID.Pumpking,
            NPCID.Everscream,
            NPCID.IceQueen,
            NPCID.SantaNK1
        };
    }
    public class EventsTrophy : TrophyItem
    {
        public override string ShowName => "Events Trophy";

        public override short[] TrophyIdList => new short[]
        {
            ItemID.FlyingDutchmanTrophy,
            ItemID.MartianSaucerTrophy
        };

        public override string[] TrophyFromModNames => new string[] 
        { 
            nameof(MoonTrophy),
        };

        public override int[] BossesID => new int[]
        {
            NPCID.MourningWood,
            NPCID.Pumpking,
            NPCID.Everscream,
            NPCID.IceQueen,
            NPCID.SantaNK1,
            NPCID.MartianSaucer,
            NPCID.PirateShip
        };
    }
    public class TrophyOfTerraria : TrophyItem
    {
        public override string ShowName => "Trophy of Terraria";

        public override short[] TrophyIdList => new short[] { };

        public override string[] TrophyFromModNames => new string[]
        {
            nameof(PreHardmodeTrophy),
            nameof(HorrorTrophy),
            nameof(MechanicsTrophy),
            nameof(AncientTrophy),
            nameof(EventsTrophy)
        };

        public override int[] BossesID => new int[]
        {
            NPCID.EyeofCthulhu,
            NPCID.EaterofWorldsHead,
            NPCID.BrainofCthulhu,
            NPCID.SkeletronHand,
            NPCID.EyeofCthulhu,
            NPCID.EaterofWorldsHead,
            NPCID.BrainofCthulhu,
            NPCID.SkeletronHand,
            NPCID.KingSlime,
            NPCID.WallofFlesh,
            NPCID.TheDestroyer,
            NPCID.Spazmatism,
            NPCID.Retinazer,
            NPCID.SkeletronPrime,
            NPCID.Plantera,
            NPCID.Golem,
            NPCID.CultistBoss,
            NPCID.MoonLordHead,
            NPCID.MoonLordHand,
            NPCID.MoonLordFreeEye,
            NPCID.MourningWood,
            NPCID.Pumpking,
            NPCID.Everscream,
            NPCID.IceQueen,
            NPCID.SantaNK1,
            NPCID.MourningWood,
            NPCID.Pumpking,
            NPCID.Everscream,
            NPCID.IceQueen,
            NPCID.SantaNK1,
            NPCID.MartianSaucer,
            NPCID.PirateShip
        };
    }
}
