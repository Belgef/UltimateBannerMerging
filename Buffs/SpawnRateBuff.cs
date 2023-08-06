using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using UltimateBannerMerging.NPCs;

namespace UltimateBannerMerging.Buffs
{
    internal class SpawnRateBuff : ModBuff
    {
        public static string Text = "";
        public override void SetStaticDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            Main.persistentBuff[Type] = true;
        }

        public override void ModifyBuffText(ref string buffName, ref string tip, ref int rare)
        {
            tip = Text;
        }

        public override bool RightClick(int buffIndex)
        {
            SpawnRateNPC.Multiplier = 1;
            Main.LocalPlayer.DelBuff(buffIndex);
            return true;
        }
    }
}
