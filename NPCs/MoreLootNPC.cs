using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using UltimateBannerMerging.Helpers;
using UltimateBannerMerging.Players;

namespace UltimateBannerMerging.NPCs
{
    internal class MoreLootNPC : GlobalNPC
    {
        public int EntitiesToKill { get; set; }
        public int MaxEntitiesToKill { get; set; }

        public override bool InstancePerEntity => true;

        public override bool PreKill(NPC npc)
        {
            if (EntitiesToKill > 0)
            {
                EntitiesToKill--;
                MyNPCLoot(npc);
                npc.extraValue = 0;
            }
            return true;
        }

        private void MyNPCLoot(NPC npc)
        {
            if (Main.netMode == 1 || npc.type >= NPCLoader.NPCCount)
                return;
            Player closestPlayer = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
            
            if (npc.type == 23 && Main.hardMode 
                || npc.SpawnedFromStatue && NPCID.Sets.NoEarlymodeLootWhenSpawnedFromStatue[npc.type] && !Main.hardMode 
                || npc.SpawnedFromStatue && (double)NPCID.Sets.StatueSpawnedDropRarity[npc.type] != -1.0 && ((double)Main.rand.NextFloat() >= (double)NPCID.Sets.StatueSpawnedDropRarity[npc.type] || !npc.AnyInteractions()) 
                || !NPCLoader.PreKill(npc))
                return;

            npc.GetType().GetMethod("NPCLoot_DropItems", BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(npc, new object[]{ closestPlayer });
            npc.GetType().GetMethod("NPCLoot_DropMoney", BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(npc, new object[] { closestPlayer });
            npc.GetType().GetMethod("NPCLoot_DropHeals", BindingFlags.NonPublic | BindingFlags.Instance)?.Invoke(npc, new object[] { closestPlayer });
        }
    }
}