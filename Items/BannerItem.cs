using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
using System.Collections.Generic;
using Terraria.Localization;

namespace UltimateBannerMerging.Items
{
	public abstract class BannerItem : ModItem
	{
        public abstract int RarityID { get; }
		public abstract int[] BannerList { get; }
		public abstract int[] BannerItemIds { get; }
		public abstract int[] AdditionalMobs { get; }
        public virtual string[] Groups => Array.Empty<string>();
        public virtual int[] GroupItems => Array.Empty<int>();
        public virtual int[] GroupMergedItemIds => Array.Empty<int>();

		public float Multiplier => (Mod.GetConfig(nameof(BannerConfig)) as BannerConfig)?.BannerStats[Name].Multiplyer ?? 1;
		public int Price => (Mod.GetConfig(nameof(BannerConfig)) as BannerConfig)?.BannerStats[Name].Price ?? 1;
		public virtual BannerItem[] BannerItems => BannerItemIds.Select(s => ModContent.GetModItem(s) as BannerItem).ToArray();
		//protected string[] NameList => BannerList.Concat(AdditionalBanners).Select(n => MobBanners.GetBannerByID((int)n).Name)
		//	.Concat(BannerItems.SelectMany(b=>b.NameList)).OrderBy(s=>s).ToArray();
        public virtual BannerItem[] GroupMergedItems => GroupMergedItemIds.Select(s => ModContent.GetModItem(s) as BannerItem).ToArray();

		public override string Texture => (GetType().Namespace + ".Sprites." + Name).Replace('.', '/');
		
        public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
            tooltips.Add(new(Mod, "Tooltip0", Language.GetTextValue("Mods.UltimateBannerMerging.ItemTooltip.BannerItem.1")));
            tooltips.Add(new(Mod, "Tooltip1", Language.GetTextValue("Mods.UltimateBannerMerging.ItemTooltip.BannerItem.2").Replace("%", Multiplier.ToString())));
            tooltips.RemoveAll(s => s.Text.Contains("__EMPTY__"));
            //AdditionalBanners.Select(b=>MobBannerConverter.)
        }

        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults() 
		{
			Item.value = Price;
			Item.rare = ItemRarityID.Green;
			Item.maxStack = 99;
            Item.rare = RarityID;
		}

        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			foreach(BannerItem item in BannerItems)
				recipe.AddIngredient(item);
			foreach(int id in BannerList)
				recipe.AddIngredient(id);
            foreach (string groupName in Groups)
                recipe.AddRecipeGroup(groupName);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
    }
}