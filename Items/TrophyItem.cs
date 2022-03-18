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
        public abstract short[] TrophyIdList { get; }
        public abstract string[] TrophyFromModNames { get; }
        public abstract int[] BossesID { get; }

        public override string Texture => (GetType().Namespace + ".TrophySprites." + Name).Replace('.', '/');

        public override void SetDefaults()
        {
            item.value = 0;
            item.rare = ItemRarityID.Lime;
            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(mod);
            foreach (var trophyID in TrophyIdList)
                modRecipe.AddIngredient(trophyID);

            foreach (var modTrophy in TrophyFromModNames)
                modRecipe.AddIngredient(mod, modTrophy);

            modRecipe.AddTile(TileID.Anvils);
            modRecipe.SetResult(this);
            modRecipe.AddRecipe();
        }
    }
}
