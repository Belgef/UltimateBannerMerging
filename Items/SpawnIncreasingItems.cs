//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;
//using System;
//using System.Linq;
//using System.Collections.Generic;
//using UltimateBannerMerging.Buffs;

//namespace UltimateBannerMerging.Items
//{
//	public abstract class SpawnItem : ModItem
//	{
//        public abstract string Tooltip1 { get; }
//        public abstract int Multiplier { get; }

//        public override string Texture => (GetType().Namespace + ".SpawnIncreasingItems." + Name).Replace('.', '/');
//        public override void SetDefaults()
//        {
//            Item.consumable = false;
//            Item.maxStack = 1;
//            Item.useStyle = ItemUseStyleID.HoldUp;
//            Item.keepTime = 4;
//        }
//        public override void ModifyTooltips(List<TooltipLine> tooltips)
//        {
//            tooltips.Add(new TooltipLine(Mod, "Tooltip0", "Not consumable"));
//            tooltips.Add(new TooltipLine(Mod, "Tooltip0", "Toggles enemies spawn rate increase"));
//            tooltips.Add(new TooltipLine(Mod, "Tooltip1", $"{Multiplier}x increased enemy spawn rate"));
//        }
//        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
//        {
//            if (player.HasBuff(ModContent.BuffType<SpawnRateBuff>()) && SpawnRateBuff.Text == Tooltip1)
//            {
//                NPC.SpawnRateNPC.Multiplier = 1;
//                player.ClearBuff(ModContent.BuffType<SpawnRateBuff>());
//            }
//            else if (!player.HasBuff(ModContent.BuffType<SpawnRateBuff>()))
//            {
//                NPC.SpawnRateNPC.Multiplier = Multiplier;
//                SpawnRateBuff.Text = Tooltip1;
//                player.AddBuff(ModContent.BuffType<SpawnRateBuff>(), 10);
//            }
//            else
//                return false;
//            return true;
//        }
//    }
//    public class SmellyBag : SpawnItem
//    {
//        public override int Multiplier => 5;
//        public override string Tooltip1 => "You're attracting enemies.";

//        public override void AddRecipes()
//        {
//            Recipe recipe = CreateRecipe();
//            recipe.AddIngredient(ItemID.BattlePotion, 10);
//            recipe.AddTile(TileID.WorkBenches);
//            recipe.Register();
//        }
//    }
//    public class AwfulSubstance : SpawnItem
//    {
//        public override int Multiplier => 20;
//        public override string Tooltip1 => "Enemies hate you.";

//        public override void AddRecipes()
//        {
//            Recipe recipe = CreateRecipe();
//            recipe.AddIngredient(Mod, nameof(SmellyBag));
//            recipe.AddIngredient(WorldGen.crimson ? ItemID.TissueSample : ItemID.ShadowScale, 40);
//            recipe.AddTile(TileID.DemonAltar);
//            recipe.Register();
//        }
//    }
//    public class PutrescentFlesh : SpawnItem
//    {
//        public override int Multiplier => 50;
//        public override string Tooltip1 => "Your existance is irritating.";

//        public override void AddRecipes()
//        {
//            Recipe recipe = CreateRecipe();
//            recipe.AddIngredient(Mod, nameof(AwfulSubstance));
//            recipe.AddIngredient(ItemID.Bone, 20);
//            recipe.AddTile(TileID.Hellforge);
//            recipe.Register();
//        }
//    }
//    public class DefusalMark : SpawnItem
//    {
//        public override int Multiplier => 100;
//        public override string Tooltip1 => "Enemies marked you as a main target.";

//        public override void AddRecipes()
//        {
//            Recipe recipe = CreateRecipe();
//            recipe.AddIngredient(Mod, nameof(PutrescentFlesh));
//            recipe.AddIngredient(ItemID.HallowedBar, 10);
//            recipe.AddIngredient(ItemID.SoulofFright, 10);
//            recipe.AddTile(TileID.MythrilAnvil);
//            recipe.Register();
//        }
//    }
//    public class AnnihilationSign : SpawnItem
//    {
//        public override int Multiplier => 500;
//        public override string Tooltip1 => "The war is close.";

//        public override void AddRecipes()
//        {
//            Recipe recipe = CreateRecipe();
//            recipe.AddIngredient(Mod, nameof(DefusalMark));
//            recipe.AddIngredient(ItemID.LargeRuby);
//            recipe.AddIngredient(ItemID.LunarOre, 80);
//            recipe.AddTile(TileID.MythrilAnvil);
//            recipe.Register();
//        }
//    }
//}