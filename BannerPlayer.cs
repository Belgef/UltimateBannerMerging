using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateBannerMerging.Buffs;
using UltimateBannerMerging.Items;

namespace UltimateBannerMerging
{
    internal class BannerPlayer : ModPlayer
    {
        public const float DamageIncrease = 0.2f;
        public const float DamageReduction = 40;
        
        public readonly Dictionary<int, int> CurrentMobs = new Dictionary<int, int>();

        public override void PostUpdate()
        {
            CurrentMobs.Clear();
            foreach(var item in player.inventory)
            {
                if(MobBannerConverter.IsVanillaBanner(item.netID))
                {
                    AddVanillaBanner(item.netID, item.stack);
                }
                else if(item.modItem is BannerItem bannerItem)
                {
                    AddModBanner(bannerItem, item.stack);
                }
            }
            if(CurrentMobs.Count > 0)
            {
                player.AddBuff(mod.GetBuff(nameof(BannerBuff)).Type, 10);
            }
            else
            {
                player.ClearBuff(mod.GetBuff(nameof(BannerBuff)).Type);
            }
        }
        private void AddVanillaBanner(int id, int quantity)
        {
            int mobID = MobBannerConverter.GetMobID(id, mod);
            if (CurrentMobs.ContainsKey(mobID))
                CurrentMobs[mobID] += quantity;
            else
                CurrentMobs.Add(mobID, quantity);
        }
        private void AddModBanner(BannerItem modItem, int quantity)
        {
            foreach (var banner in modItem.BannerList.Concat(modItem.AdditionalBanners))
            {
                AddVanillaBanner(banner, modItem.Multiplyer * quantity);
            }
            foreach (var modBanner in modItem.BannerItems)
            {
                AddModBanner(modBanner, modItem.Multiplyer * quantity);
            }
        }
        
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            int mobID = MobBannerConverter.GetMobID(target);
            if (CurrentMobs.ContainsKey(mobID))
                damage += (int)(damage * DamageIncrease * CurrentMobs[mobID]);
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            ModifyHitNPC(null, target, ref damage, ref knockback, ref crit);
        }
        private void ModifyHitByAnyone(int mobID, ref int damage)
        {
            if (CurrentMobs.ContainsKey(mobID))
                damage = (int)(DamageReduction * damage / (DamageReduction + CurrentMobs[mobID]));
        }
        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            int mobID = MobBannerConverter.GetMobID(npc);
            ModifyHitByAnyone(mobID, ref damage);
        }
        public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit)
        {
            int mobID = MobBannerConverter.GetMobID(proj);
            ModifyHitByAnyone(mobID, ref damage);
        }
    }
}
