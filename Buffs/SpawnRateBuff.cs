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
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        // ModifyBuffText: Void ModifyBuffTip(System.String ByRef, Int32 ByRef) overrides a method which doesn't exist in any base class
        public override void ModifyBuffText(ref string text, ref int rare);
        
        public override bool RightClick(int buffIndex)
        {
            SpawnRateNPC.Multiplier = 1;
            Main.LocalPlayer.DelBuff(buffIndex);
            return true;
        }
    }
}
