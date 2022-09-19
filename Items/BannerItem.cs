using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using System.Collections.Generic;

namespace UltimateBannerMerging.Items
{
	public abstract class BannerItem : ModItem
	{
		public abstract string ShowName { get; }
		public abstract short[] BannerList { get; }
		public abstract int[] BannerItemIds { get; }
		public abstract short[] AdditionalMobs { get; }

		public float Multiplier => (Mod.GetConfig(nameof(BannerConfig)) as BannerConfig)?.BannerStats[ShowName].Multiplyer ?? 1;
		public int Price => (Mod.GetConfig(nameof(BannerConfig)) as BannerConfig)?.BannerStats[ShowName].Price ?? 1;
		public BannerItem[] BannerItems => BannerItemIds.Select(s => ModContent.GetModItem(s) as BannerItem).ToArray();
		//protected string[] NameList => BannerList.Concat(AdditionalBanners).Select(n => MobBanners.GetBannerByID((int)n).Name)
		//	.Concat(BannerItems.SelectMany(b=>b.NameList)).OrderBy(s=>s).ToArray();

		public override string Texture => (GetType().Namespace + ".Sprites." + Name).Replace('.', '/');

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault(ShowName);
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips.Add(new(Mod, "Tooltip0", "Increases damage and defense against all included enemies."));
			tooltips.Add(new(Mod, "Tooltip1", $"{Multiplier} times more effective than its crafting components."));
			//AdditionalBanners.Select(b=>MobBannerConverter.)
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
			foreach(BannerItem item in BannerItems)
				recipe.AddIngredient(item);
			foreach(int id in BannerList)
				recipe.AddIngredient(id);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
    }
}