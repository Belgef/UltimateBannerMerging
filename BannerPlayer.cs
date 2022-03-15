using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateBannerMerging.Buffs;
using UltimateBannerMerging.Items;

namespace UltimateBannerMerging
{
    internal class BannerPlayer : ModPlayer
    {        
        public readonly Dictionary<int, float> CurrentMobs = new Dictionary<int, float>();

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
        private void AddVanillaBanner(int id, float quantity)
        {
            int mobID = MobBannerConverter.GetMobID(id, mod);
            if (CurrentMobs.ContainsKey(mobID))
                CurrentMobs[mobID] += quantity;
            else
                CurrentMobs.Add(mobID, quantity);
            if(CurrentMobs[mobID] > BannerConfig.InvulnerabilityCap)
                CurrentMobs[mobID] = BannerConfig.InvulnerabilityCap;
        }
        private void AddModBanner(BannerItem modItem, float quantity)
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
                damage += (int)(damage * ((BannerConfig.MaxDamageIncrease - 1) / BannerConfig.InvulnerabilityCap * CurrentMobs[mobID] + 1));
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            ModifyHitNPC(null, target, ref damage, ref knockback, ref crit);
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            int mobID;
            if(damageSource.SourceNPCIndex != -1)
                mobID = MobBannerConverter.GetMobID(Main.npc[damageSource.SourceNPCIndex]);
            else if(damageSource.SourceProjectileIndex != -1)
                mobID = MobBannerConverter.GetMobID(Main.projectile[damageSource.SourceProjectileIndex]);
            else
                return true;

            if (ReachedInvulnerabilityCap(mobID))
                return false;
            damage = ModifyReceivedDamage(mobID, damage);
            return true;
        }
        private bool ReachedInvulnerabilityCap(int mobID)
        {
            return CurrentMobs.ContainsKey(mobID) && CurrentMobs[mobID] >= BannerConfig.InvulnerabilityCap;
        }
        private int ModifyReceivedDamage(int mobID, int damage)
        {
            if (CurrentMobs.ContainsKey(mobID))
                return (int)(damage * (-CurrentMobs[mobID] / BannerConfig.InvulnerabilityCap + 1));
            return damage;
        }
    }
}
