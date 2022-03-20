using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace UltimateBannerMerging.Buffs
{
    internal class TrophyBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Boss Dominance");
            Description.SetDefault("More trophies in your inventory give you more power against specific bosses");
            Main.buffNoTimeDisplay[Type] = true;
            Main.persistentBuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            canBeCleared = false;
        }
    }
}
