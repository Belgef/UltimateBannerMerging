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
            tooltips.Add(new TooltipLine(mod, "Tooltip0", "Not consumable"));
            tooltips.Add(new TooltipLine(mod, "Tooltip0", "Toggles enemies spawn rate increase"));
            tooltips.Add(new TooltipLine(mod, "Tooltip1", $"{Multiplier}x increased enemy spawn rate"));
        }
        public override bool UseItem(Player player)
        {
            if (player.HasBuff(mod.GetBuff(nameof(SpawnRateBuff)).Type) && SpawnRateBuff.Text == Tooltip1)
            {
                NPC.SpawnRateNPC.Multiplier = 1;
                player.ClearBuff(mod.GetBuff(nameof(SpawnRateBuff)).Type);
            }
            else if (!player.HasBuff(mod.GetBuff(nameof(SpawnRateBuff)).Type))
            {
                NPC.SpawnRateNPC.Multiplier = Multiplier;
                SpawnRateBuff.Text = Tooltip1;
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

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BattlePotion, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class AwfulSubstance : SpawnItem
    {
        public override int Multiplier => 20;
        public override string Tooltip1 => "Enemies hate you.";

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(SmellyBag));
            recipe.AddIngredient(WorldGen.crimson ? ItemID.TissueSample : ItemID.ShadowScale, 40);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class PutrescentFlesh : SpawnItem
    {
        public override int Multiplier => 50;
        public override string Tooltip1 => "Your existance is irritating.";

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(AwfulSubstance));
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class DefusalMark : SpawnItem
    {
        public override int Multiplier => 100;
        public override string Tooltip1 => "Enemies marked you as a main target.";

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(PutrescentFlesh));
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
    public class AnnihilationSign : SpawnItem
    {
        public override int Multiplier => 500;
        public override string Tooltip1 => "The war is close.";

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod, nameof(DefusalMark));
            recipe.AddIngredient(ItemID.LargeRuby);
            recipe.AddIngredient(ItemID.LunarOre, 80);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}