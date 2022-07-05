using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UltimateBannerMerging.Items
{
    public abstract class TrophyItem : ModItem
    {
        public abstract string ShowName { get; }

        public abstract short[] TrophyList { get; }
        public abstract int[] TrophyItemIds { get; }
        public abstract short[] AdditionalBosses { get; }

        public int Price => (Mod.GetConfig(nameof(BannerConfig)) as BannerConfig).TrophyStats[ShowName].Price;
        public float Multiplyer => (Mod.GetConfig(nameof(BannerConfig)) as BannerConfig).TrophyStats[ShowName].Multiplyer;
        public TrophyItem[] TrophyItems => TrophyItemIds.Select(s => ModContent.GetModItem(s) as TrophyItem).ToArray();
        
        public override string Texture => (GetType().Namespace + ".TrophySprites." + Name).Replace('.', '/');

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault($"{ShowName} Trophy");
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Add(new TooltipLine(Mod, "Tooltip0", "Increases damage and defense against all included bosses and minibosses."));
            tooltips.Add(new TooltipLine(Mod, "Tooltip1", $"{Multiplyer} times more effective than its crafting components."));
            //AdditionalBanners.Select(b=>MobBannerConverter.)
            //tooltips.Add(new TooltipLine(mod, "Tooltip2", $"{Multiplyer} times more effective than its crafting components."));
        }

        public override void SetDefaults()
        {
            Item.value = Price;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            foreach (var item in TrophyItems)
                recipe.AddIngredient(item);
            foreach (int id in TrophyList)
                recipe.AddIngredient(id, 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}
