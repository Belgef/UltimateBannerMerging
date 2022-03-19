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
		public abstract string[] BannerItemNames { get; }
		public abstract short[] AdditionalMobs { get; }

		private int price;
		private float multiplier;
		public int Price => price;
		public float Multiplyer => multiplier;
		public BannerItem[] BannerItems => BannerItemNames.Select(s => mod.GetItem(s) as BannerItem).ToArray();
		//protected string[] NameList => BannerList.Concat(AdditionalBanners).Select(n => MobBanners.GetBannerByID((int)n).Name)
		//	.Concat(BannerItems.SelectMany(b=>b.NameList)).OrderBy(s=>s).ToArray();

		public override string Texture => (GetType().Namespace + ".BannerSprites." + Name).Replace('.', '/');

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault($"{ShowName} Banner");
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			tooltips.Add(new TooltipLine(mod, "Tooltip0", "Increases damage and defense against all included enemies."));
			tooltips.Add(new TooltipLine(mod, "Tooltip1", $"{Multiplyer} times more effective than its crafting components."));
			//AdditionalBanners.Select(b=>MobBannerConverter.)
			//tooltips.Add(new TooltipLine(mod, "Tooltip2", $"{Multiplyer} times more effective than its crafting components."));
		}

		public override void SetDefaults() 
		{
			item.value = Price;
			item.rare = ItemRarityID.Green;
			item.maxStack = 99;
		}

        public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			var config = mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
			price = config.BannerStats[ShowName].Price;
			multiplier = config.BannerStats[ShowName].Multiplyer;
		}

        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			foreach(string item in BannerItemNames)
				recipe.AddIngredient(mod, item);
			foreach(int id in BannerList)
				recipe.AddIngredient(id);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}