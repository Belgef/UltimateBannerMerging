//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Terraria;
//using Terraria.DataStructures;
//using Terraria.ID;
//using Terraria.ModLoader;
//using UltimateBannerMerging.Buffs;
//using UltimateBannerMerging.Items;
//using UltimateBannerMerging.NPCs;

//namespace UltimateBannerMerging.Players
//{
//    internal class MoreLootPlayer : ModPlayer
//    {      
//        public override void ModifyHitNPC(Item item, Terraria.NPC target, ref int damage, ref float knockback, ref bool crit)
//        {
//            MoreLootNPC npc = target.GetGlobalNPC<MoreLootNPC>();
//            npc.Player = this;
//            npc.LastDamage = damage;
//        }
//        public override void ModifyHitNPCWithProj(Projectile proj, Terraria.NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
//        {
//            ModifyHitNPC(null, target, ref damage, ref knockback, ref crit);
//        }
//    }
//}
