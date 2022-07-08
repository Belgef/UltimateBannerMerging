using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateBannerMerging.Buffs;
using UltimateBannerMerging.Items;

namespace UltimateBannerMerging.Players
{
    internal class BannerPlayer : ModPlayer
    {        
        public readonly Dictionary<int, float> CurrentMobs = new Dictionary<int, float>();

        public override void PostUpdate()
        {
            CurrentMobs.Clear();

            Check(Player.inventory);
            Check(Player.bank.item);
            Check(Player.bank2.item);
            Check(Player.bank3.item);
            Check(Player.bank4.item);

            if (CurrentMobs.Count > 0)
            {
                Player.AddBuff(ModContent.BuffType<BannerBuff>(), 10);
            }
            else
            {
                Player.ClearBuff(ModContent.BuffType<BannerBuff>());
            }

            if (Player.HasBuff(ModContent.BuffType<SpawnRateBuff>()))
            {
                Player.AddBuff(ModContent.BuffType<SpawnRateBuff>(), 10);
            }
        }
        private void Check(Item[] inv)
        {
            foreach (var item in inv.Where(i => i?.active ?? false && !i.IsAir))
            {
                if (MobConverter.IsVanillaBanner(item.netID))
                {
                    AddVanillaBanner(item.netID, item.stack);
                }
                else if (item.ModItem is BannerItem bannerItem)
                {
                    AddModBanner(bannerItem, item.stack);
                }
            }
        }
        private void AddVanillaBanner(int id, float quantity)
        {
            AddMob(MobConverter.GetMobID(id), quantity);
        }
        private void AddMob(int mobID, float quantity)
        {
            var config = Mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
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
                AddVanillaBanner(banner, modItem.Multiplier * quantity);
            }
            foreach (var mob in modItem.AdditionalMobs)
            {
                AddMob(mob, modItem.Multiplier * quantity);
            }
            foreach (var modBanner in modItem.BannerItems)
            {
                AddModBanner(modBanner, modItem.Multiplier * quantity);
            }
        }
        
        public override void ModifyHitNPC(Item item, Terraria.NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            var config = Mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
            int mobID = MobConverter.GetMobID(target);
            if (MobConverter.NPCProjectileOwners.ContainsKey(mobID))
                mobID = MobConverter.NPCProjectileOwners[mobID];
            if (CurrentMobs.ContainsKey(mobID))
                damage += (int)(damage * (((float)config.MaxDamageIncrease - 1) / config.InvulnerabilityCap * CurrentMobs[mobID] + 1));
        }
        public override void ModifyHitNPCWithProj(Projectile proj, Terraria.NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
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
            var config = Mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
            return CurrentMobs.ContainsKey(mobID) && CurrentMobs[mobID] >= config.InvulnerabilityCap;
        }
        private int ModifyReceivedDamage(int mobID, int damage)
        {
            var config = Mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
            if (CurrentMobs.ContainsKey(mobID))
                return (int)(damage * (-CurrentMobs[mobID] / config.InvulnerabilityCap + 1));
            return damage;
        }
    }
}
