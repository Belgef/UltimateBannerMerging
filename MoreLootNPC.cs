using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using UltimateBannerMerging.Players;

namespace UltimateBannerMerging
{
    internal class MoreLootNPC : GlobalNPC
    {
        public MoreLootPlayer Player { get; set; }
        public int LastDamage { get; set; }

        public override bool InstancePerEntity => true;

        public override void NPCLoot(NPC npc)
        {
            if (Player != null)
            {
                var mobID = MobConverter.GetMobID(npc);
                var currentMobs = Player.player.GetModPlayer<BannerPlayer>().CurrentMobs;
                float quantity = currentMobs.ContainsKey(mobID) ? currentMobs[mobID] : 0;
                float lootMultiplier = quantity / BannerConfig.InvulnerabilityCap * (BannerConfig.DropMaxMultiplier - 1) + 1;
                CombatText.clearAll();
                for (int i = 0; i < (int)lootMultiplier; i++)
                    Main.npc[NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, npc.type)].StrikeNPCNoInteraction(int.MaxValue, 0, 0);
                CombatText.clearAll();
                CombatText.NewText(new Microsoft.Xna.Framework.Rectangle((int)npc.position.X, (int)npc.position.Y, 1, 1), CombatText.DamagedHostile, LastDamage);
            }
        }
    }
}
