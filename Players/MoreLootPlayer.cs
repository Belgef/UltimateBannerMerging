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
                if(MobConverter.IsVanillaBanner(item.netID))
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
            AddMob(MobConverter.GetMobID(id, mod), quantity);
        }
        private void AddMob(int mobID, float quantity)
        {
            var config = mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
            if (CurrentMobs.ContainsKey(mobID))
                CurrentMobs[mobID] += quantity;
            else
                CurrentMobs.Add(mobID, quantity);
            if (CurrentMobs[mobID] > config.InvulnerabilityCap)
                CurrentMobs[mobID] = config.InvulnerabilityCap;
        }
        private void AddModBanner(BannerItem modItem, float quantity)
        {
            foreach (var banner in modItem.BannerList)
            {
                AddVanillaBanner(banner, modItem.Multiplyer * quantity);
            }
            foreach (var mob in modItem.AdditionalBanners)
            {
                AddMob(mob, modItem.Multiplyer * quantity);
            }
            foreach (var modBanner in modItem.BannerItems)
            {
                AddModBanner(modBanner, modItem.Multiplyer * quantity);
            }
        }
        
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            var config = mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
            int mobID = MobConverter.GetMobID(target);
            if (CurrentMobs.ContainsKey(mobID))
                damage += (int)(damage * ((config.MaxDamageIncrease - 1) / config.InvulnerabilityCap * CurrentMobs[mobID] + 1));
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            ModifyHitNPC(null, target, ref damage, ref knockback, ref crit);
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (damageSource.SourceNPCIndex != -1)
            {
                int mobID = MobConverter.GetMobID(Main.npc[damageSource.SourceNPCIndex]);
                if (MobConverter.NPCProjectileOwners.ContainsKey(mobID))
                    mobID = MobConverter.NPCProjectileOwners[mobID];
                if (ReachedInvulnerabilityCap(mobID))
                    return false;
                damage = ModifyReceivedDamage(mobID, damage);
            }
            else if (damageSource.SourceProjectileIndex != -1)
            {
                int[] mobIDs = (MobConverter.GetMobID(Main.projectile[damageSource.SourceProjectileIndex])??(new int[] { })).Where(id=>CurrentMobs.ContainsKey(id)).ToArray();
                if (mobIDs.Length == 0)
                    return true;
                if (mobIDs.FirstOrDefault(id => ReachedInvulnerabilityCap(id)) != 0)//WARNING
                    return false;
                damage = ModifyReceivedDamage(mobIDs[0], damage);
            }
            return true;
        }
        private bool ReachedInvulnerabilityCap(int mobID)
        {
            var config = mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
            return CurrentMobs.ContainsKey(mobID) && CurrentMobs[mobID] >= config.InvulnerabilityCap;
        }
        private int ModifyReceivedDamage(int mobID, int damage)
        {
            var config = mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
            if (CurrentMobs.ContainsKey(mobID))
                return (int)(damage * (-CurrentMobs[mobID] / config.InvulnerabilityCap + 1));
            return damage;
        }
    }
}
