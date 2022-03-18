using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using System.Collections.Generic;

namespace UltimateBannerMerging.Items
{
	public class SmellyMeat : ModItem
	{
        public override void SetDefaults()
        {
            item.consumable = false;
            item.maxStack = 1;
            item.useStyle = ItemUseStyleID.HoldingUp;
        }
        public override bool UseItem(Player player)
        {
            NPC.SpawnRateNPC.Multiplier = 5;
            return true;
        }
    }
}