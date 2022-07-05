using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateBannerMerging.Items
{
    public class HorrorTrophy : TrophyItem
    {
        public override string ShowName => "Horror";

        public override short[] TrophyList => new short[]
        {
            ItemID.EyeofCthulhuTrophy,
            WorldGen.crimson ? ItemID.BrainofCthulhuTrophy : ItemID.EaterofWorldsTrophy,
            ItemID.SkeletronTrophy
        };

        public override int[] TrophyItemIds => System.Array.Empty<int>();

        public override short[] AdditionalBosses => new short[] {
            (!WorldGen.crimson) ? ItemID.BrainofCthulhuTrophy : ItemID.EaterofWorldsTrophy,
        };
    }
    public class PreHardmodeTrophy : TrophyItem
    {
        public override string ShowName => "Pre Hardmode";

        public override short[] TrophyList => new short[]
        {
            ItemID.WallofFleshTrophy,
            ItemID.KingSlimeTrophy,
            ItemID.QueenBeeTrophy
        };

        public override int[] TrophyItemIds => new int[] {
            ModContent.ItemType<HorrorTrophy>(),
        };

        public override short[] AdditionalBosses => new short[] { };
    }
    public class MechanicsTrophy : TrophyItem
    {
        public override string ShowName => "Mechanics";

        public override short[] TrophyList => new short[]
        {
            ItemID.DestroyerTrophy,
            ItemID.SpazmatismTrophy,
            ItemID.RetinazerTrophy,
            ItemID.SkeletronPrimeTrophy
        };

        public override int[] TrophyItemIds => System.Array.Empty<int>();

        public override short[] AdditionalBosses => new short[] { };
    }
    public class AncientTrophy : TrophyItem
    {
        public override string ShowName => "Ancient";

        public override short[] TrophyList => new short[]
        {
            ItemID.PlanteraTrophy,
            ItemID.GolemTrophy,
            ItemID.AncientCultistTrophy,
            ItemID.MoonLordTrophy,
            ItemID.DukeFishronTrophy
        };

        public override int[] TrophyItemIds => System.Array.Empty<int>();

        public override short[] AdditionalBosses => new short[] { };
    }
    public class MoonTrophy : TrophyItem
    {
        public override string ShowName => "Moon";

        public override short[] TrophyList => new short[]
        {
            ItemID.MourningWoodTrophy,
            ItemID.PumpkingTrophy,
            ItemID.EverscreamTrophy,
            ItemID.IceQueenTrophy,
            ItemID.SantaNK1Trophy
        };

        public override int[] TrophyItemIds => System.Array.Empty<int>();

        public override short[] AdditionalBosses => new short[] { };
    }
    public class EventsTrophy : TrophyItem
    {
        public override string ShowName => "Events";

        public override short[] TrophyList => new short[]
        {
            ItemID.FlyingDutchmanTrophy,
            ItemID.MartianSaucerTrophy
        };

        public override int[] TrophyItemIds => new int[] {
            ModContent.ItemType<MoonTrophy>(),
        };

        public override short[] AdditionalBosses => new short[] { };
    }
    public class TheTrophy : TrophyItem
    {
        public override string ShowName => "The";

        public override short[] TrophyList => new short[] { };

        public override int[] TrophyItemIds => new int[] {
            ModContent.ItemType<PreHardmodeTrophy>(),
            ModContent.ItemType<MechanicsTrophy>(),
            ModContent.ItemType<AncientTrophy>(),
            ModContent.ItemType<EventsTrophy>(),
        };

        public override short[] AdditionalBosses => new short[] { };
    }
}
