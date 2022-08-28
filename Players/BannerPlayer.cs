using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using UltimateBannerMerging.Buffs;
using UltimateBannerMerging.Helpers;
using UltimateBannerMerging.NPCs;

namespace UltimateBannerMerging.Players
{
    internal class BannerPlayer : ModPlayer
    {
        public BannerCollection BannerCollection { get; set; }

        public override void Initialize()
        {
            BannerCollection = new(Mod.GetConfig(nameof(BannerConfig)) as BannerConfig);
            BannerCollection.OnFillBanner += () => Player.AddBuff(ModContent.BuffType<BannerBuff>(), int.MaxValue);
            BannerCollection.OnEmptyBanner += () => Player.ClearBuff(ModContent.BuffType<BannerBuff>());
            BannerCollection.OnFillTrophy += () => Player.AddBuff(ModContent.BuffType<TrophyBuff>(), int.MaxValue);
            BannerCollection.OnEmptyTrophy += () => Player.ClearBuff(ModContent.BuffType<TrophyBuff>());
        }
        public override void PostUpdate()
        {
            BannerCollection.Update(Player);

            if (Player.HasBuff(ModContent.BuffType<SpawnRateBuff>()))
                Player.AddBuff(ModContent.BuffType<SpawnRateBuff>(), 10);
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            damage = (int)(damage * BannerCollection.GetDealtDamageMultiplier(target));

            SetNPCLootParameters(target, damage);
        }

        private void SetNPCLootParameters(NPC npc, int lastDamage)
        {
            MoreLootNPC gnpc = npc.GetGlobalNPC<MoreLootNPC>();
            gnpc.Player = this;
            gnpc.LastDamage = lastDamage;
        }
        
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            ModifyHitNPC(null, target, ref damage, ref knockback, ref crit);
        }
        
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
        {
            float damageMultiplier = BannerCollection.GetReceivedDamageMultiplier(damageSource);
            if (damageMultiplier == 0)
                return false;
            damage = (int)(damage * damageMultiplier);
            return true;
        }
    }
}
