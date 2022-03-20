using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateBannerMerging.Buffs;
using UltimateBannerMerging.Items;

namespace UltimateBannerMerging.NPC
{
    internal class SpawnRateNPC : GlobalNPC
    {
        public static float Multiplier = 1f;
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            spawnRate = (int)(spawnRate / Multiplier);
            maxSpawns = (int)(maxSpawns * Multiplier);
        }
    }
}