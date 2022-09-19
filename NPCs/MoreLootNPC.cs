using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using UltimateBannerMerging.Helpers;
using UltimateBannerMerging.Players;

namespace UltimateBannerMerging.NPCs
{
    internal class MoreLootNPC : GlobalNPC
    {
        public BannerPlayer Player { get; set; }

        public int LastDamage { get; set; }

        public override bool InstancePerEntity => true;

        public override void OnKill(NPC npc)
        {
            if (Player == null)
                return;
            
            MergingNPC mNpc = MergingNPC.Create(npc, Player.BannerCollection, Player.Config);

            int respawnQuantity = (int)Math.Ceiling(mNpc.GetLootMultiplier()) - 1;
            for (int i = 0; i < respawnQuantity; i++)
                RespawnAndKillNPC(npc);

            CombatText.clearAll();
            CombatText.NewText(new((int)npc.position.X, (int)npc.position.Y, 1, 1), CombatText.DamagedHostile, LastDamage);
        }

        private static void RespawnAndKillNPC(NPC npc)
        {
            Main.npc[NPC.NewNPC(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.type)].StrikeNPCNoInteraction(int.MaxValue, 0, 0);
        }
    }
}