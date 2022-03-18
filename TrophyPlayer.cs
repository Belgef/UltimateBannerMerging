using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateBannerMerging.Buffs;
using UltimateBannerMerging.Items;
using System;

namespace UltimateBannerMerging
{
    internal class TrophyPlayer : ModPlayer
    {
        private List<int> currentBossesID = new List<int>();

        public override void PostUpdate()
        {
            currentBossesID.Clear();

            foreach (var item in player.inventory)
            {
                if (item.modItem is TrophyItem)
                {
                    var trophyItem = item.modItem as TrophyItem;
                    foreach (var id in trophyItem.BossesID)
                    {
                        if (!currentBossesID.Contains(id))
                            currentBossesID.Add(id);
                    }
                }

                else if (item.Name.Contains("Trophy"))
                    currentBossesID.Add(MobConverter.TrophyToBossName(item.Name));
            }

            if (currentBossesID.Count > 0)
            {
                player.AddBuff(mod.GetBuff(nameof(TrophyBuff)).Type, 10);
            }
            else
            {
                player.ClearBuff(mod.GetBuff(nameof(TrophyBuff)).Type);
            }
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            var id = NPCID.FromNetId(npc.netID);

            foreach (var bossId in currentBossesID)
            {
                if (bossId == id)
                {
                     damage -= (int)(damage * 0.5);
                }
            }
        }
    }
}
