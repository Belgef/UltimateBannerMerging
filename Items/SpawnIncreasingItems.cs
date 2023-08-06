using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria.Localization;
using UltimateBannerMerging.Buffs;
using UltimateBannerMerging.NPCs;

namespace UltimateBannerMerging.Items
{
    public abstract class SpawnItem : ModItem
    {
        public abstract int RarityID { get; }
        public abstract int Multiplier { get; }
        public override string Texture => (GetType().Namespace + ".SpawnIncreasingItems." + Name).Replace('.', '/');

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 2;
        }

        public override void SetDefaults()
        {
            Item.consumable = false;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.keepTime = 4;
            Item.rare = RarityID;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new(Mod, "Tooltip0", Language.GetTextValue("Mods.UltimateBannerMerging.Items.SpawnItem.Tooltip.1")));
            tooltips.Add(new(Mod, "Tooltip1", Language.GetTextValue("Mods.UltimateBannerMerging.Items.SpawnItem.Tooltip.2")));
            tooltips.Add(new(Mod, "Tooltip2", Language.GetTextValue("Mods.UltimateBannerMerging.Items.SpawnItem.Tooltip.3").Replace("%", Multiplier.ToString())));
        }
        public override bool? UseItem(Player player)
        {
            if (player.HasBuff(ModContent.BuffType<SpawnRateBuff>()))
            {
                SpawnRateNPC.Multiplier = 1;
                player.ClearBuff(ModContent.BuffType<SpawnRateBuff>());
            }
            else
            {
                SpawnRateNPC.Multiplier = Multiplier;
                SpawnRateBuff.Text = Language.GetTextValue($"Mods.UltimateBannerMerging.Items.{Name}.Tooltip");
                player.AddBuff(ModContent.BuffType<SpawnRateBuff>(), 10);
            }
            return true;
        }
    }
    public class SmellyBag : SpawnItem
    {
        public override int RarityID => ItemRarityID.Blue;
        public override int Multiplier => 5;

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BattlePotion, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
    public class AwfulSubstance : SpawnItem
    {
        public override int RarityID => ItemRarityID.Green;
        public override int Multiplier => 20;

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, nameof(SmellyBag));
            recipe.AddRecipeGroup("UltimateBannerMerging:EvilBiomeMeat", 40);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
    public class PutrescentFlesh : SpawnItem
    {
        public override int RarityID => ItemRarityID.Orange;
        public override int Multiplier => 50;

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, nameof(AwfulSubstance));
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
        }
    }
    public class DefusalMark : SpawnItem
    {
        public override int RarityID => ItemRarityID.Pink;
        public override int Multiplier => 100;

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, nameof(PutrescentFlesh));
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.SoulofFright, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
    public class AnnihilationSign : SpawnItem
    {
        public override int RarityID => ItemRarityID.Red;
        public override int Multiplier => 500;

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod, nameof(DefusalMark));
            recipe.AddIngredient(ItemID.LargeRuby);
            recipe.AddIngredient(ItemID.LunarOre, 80);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}