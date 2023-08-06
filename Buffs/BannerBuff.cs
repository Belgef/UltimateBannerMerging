using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace UltimateBannerMerging.Buffs
{
    internal class BannerBuff : ModBuff
    {
        public void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override bool RightClick(int buffIndex) => false;
    }
}
