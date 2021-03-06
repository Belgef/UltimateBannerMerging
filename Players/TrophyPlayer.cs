using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UltimateBannerMerging.Buffs;
using UltimateBannerMerging.Items;
using System;
using Terraria.DataStructures;

namespace UltimateBannerMerging.Players
{
    internal class TrophyPlayer : ModPlayer
    {
        public readonly Dictionary<int, float> CurrentBosses = new Dictionary<int, float>();

        public override void PostUpdate()
        {
            CurrentBosses.Clear();

            Check(Player.inventory);
            Check(Player.bank.item);
            Check(Player.bank2.item);
            Check(Player.bank3.item);
            Check(Player.bank4.item);
                
            if (CurrentBosses.Count > 0)
            {
                Player.AddBuff(ModContent.BuffType<TrophyBuff>(), 10);
            }
            else
            {
                Player.ClearBuff(ModContent.BuffType<TrophyBuff>());
            }
        }
        private void Check(Item[] inv)
        {
            foreach (var item in inv.Where(i => i?.active ?? false && !i.IsAir))
            {
                if (MobConverter.IsVanillaTrophy(item.netID))
                {
                    AddVanillaTrophy(item.netID, item.stack);
                }
                else if (item.ModItem is TrophyItem trophyItem)
                {
                    AddModTrophy(trophyItem, item.stack);
                }
            }
        }
        private void AddVanillaTrophy(int id, float quantity)
        {
            AddBoss(MobConverter.GetBossID(id), quantity);
        }
        private void AddBoss(int bossID, float quantity)
        {
            var config = Mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
            if (CurrentBosses.ContainsKey(bossID))
                CurrentBosses[bossID] += quantity;
            else
                CurrentBosses.Add(bossID, quantity);
            if (CurrentBosses[bossID] > config.BossInvulnerabilityCap)
                CurrentBosses[bossID] = config.BossInvulnerabilityCap;
        }
        private void AddModTrophy(TrophyItem modItem, float quantity)
        {
            foreach (var banner in modItem.TrophyList)
            {
                AddVanillaTrophy(banner, modItem.Multiplyer * quantity);
            }
            foreach (var mob in modItem.AdditionalBosses)
            {
                AddBoss(mob, modItem.Multiplyer * quantity);
            }
            foreach (var modBanner in modItem.TrophyItems)
            {
                AddModTrophy(modBanner, modItem.Multiplyer * quantity);
            }
        }

        public override void ModifyHitNPC(Item item, Terraria.NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            var config = Mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
            int mobID = MobConverter.GetMobID(target);
            if (MobConverter.NPCProjectileOwners.ContainsKey(mobID))
                mobID = MobConverter.NPCProjectileOwners[mobID];
            if (CurrentBosses.ContainsKey(mobID))
                damage += (int)(damage * ((config.MaxBossDamageIncrease - 1) / config.BossInvulnerabilityCap * CurrentBosses[mobID] + 1));
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
                int[] mobIDs = (MobConverter.GetMobID(Main.projectile[damageSource.SourceProjectileIndex]) ?? (new int[] { }));

                for (int i = 0; i < mobIDs.Length; i++) 
                    if (MobConverter.NPCProjectileOwners.ContainsKey(mobIDs[i]))
                        mobIDs[i] = MobConverter.NPCProjectileOwners[mobIDs[i]];

                int[] newMobIDs = mobIDs.Where(id => CurrentBosses.ContainsKey(id)).ToArray();

                if (newMobIDs.Length == 0)
                    return true;
                if (newMobIDs.FirstOrDefault(id => ReachedInvulnerabilityCap(id)) != 0)//WARNING
                    return false;
                damage = ModifyReceivedDamage(newMobIDs[0], damage);
            }
            return true;
        }
        private bool ReachedInvulnerabilityCap(int mobID)
        {
            var config = Mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
            return CurrentBosses.ContainsKey(mobID) && CurrentBosses[mobID] >= config.BossInvulnerabilityCap;
        }
        private int ModifyReceivedDamage(int mobID, int damage)
        {
            var config = Mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
            if (CurrentBosses.ContainsKey(mobID))
                return (int)(damage * (-CurrentBosses[mobID] / config.BossInvulnerabilityCap + 1));
            return damage;
        }
    }
}
