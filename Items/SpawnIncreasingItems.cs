using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using System.Collections.Generic;
using UltimateBannerMerging.Buffs;

namespace UltimateBannerMerging.Items
{
	public abstract class SpawnItem : ModItem
	{
        public abstract string Tooltip1 { get; }
        public abstract int Multiplier { get; }

        public override string Texture => (GetType().Namespace + ".SpawnIncreasingItems." + Name).Replace('.', '/');
        public override void SetDefaults()
        {
            item.consumable = false;
            item.maxStack = 1;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.keepTime = 4;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(mod, "Tooltip0", Tooltip1));
        }
        public override bool UseItem(Player player)
        {
            if (player.HasBuff(mod.GetBuff(nameof(SpawnRateBuff)).Type) && SpawnRateBuff.Multiplier == Multiplier)
            {
                NPC.SpawnRateNPC.Multiplier = 1;
                player.ClearBuff(mod.GetBuff(nameof(SpawnRateBuff)).Type);
            }
            else if (!player.HasBuff(mod.GetBuff(nameof(SpawnRateBuff)).Type))
            {
                NPC.SpawnRateNPC.Multiplier = Multiplier;
                SpawnRateBuff.Multiplier = Multiplier;
                player.AddBuff(mod.GetBuff(nameof(SpawnRateBuff)).Type, 10);
            }
            else
                return false;
            return true;
        }
    }
    public class SmellyBag : SpawnItem
    {
        public override int Multiplier => 5;
        public override string Tooltip1 => "You're attracting enemies.";
    }
    public class AwfulSubstance : SpawnItem
    {
        public override int Multiplier => 20;
        public override string Tooltip1 => "Enemies hate you.";
    }
    public class PutrescentFlesh : SpawnItem
    {
        public override int Multiplier => 50;
        public override string Tooltip1 => "Your existance is irritating.";
    }
    public class DefusalMark : SpawnItem
    {
        public override int Multiplier => 100;
        public override string Tooltip1 => "Enemies marked you as a main target.";
    }
    public class AnnihilationSign : SpawnItem
    {
        public override int Multiplier => 500;
        public override string Tooltip1 => "The war is close.";
    }
}