using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace UltimateBannerMerging.Buffs
{
    internal class SpawnRateBuff : ModBuff
    {
        public static string Text = "";
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lure");
            Main.buffNoTimeDisplay[Type] = true;
            Main.persistentBuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
        }
        public override void ModifyBuffTip(ref string tip, ref int rare)
        {
            tip = Text;
        }
    }
}
