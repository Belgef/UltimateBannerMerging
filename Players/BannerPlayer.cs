using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using UltimateBannerMerging.Buffs;
using UltimateBannerMerging.Helpers;

namespace UltimateBannerMerging.Players
{
    internal class BannerPlayer : ModPlayer
    {
        private BannerCollection _bannerCollection;

        public override void Initialize()
        {
            _bannerCollection = new(Mod.GetConfig(nameof(BannerConfig)) as BannerConfig);
            _bannerCollection.OnFillBanner += () => Player.AddBuff(ModContent.BuffType<BannerBuff>(), int.MaxValue);
            _bannerCollection.OnEmptyBanner += () => Player.ClearBuff(ModContent.BuffType<BannerBuff>());
            _bannerCollection.OnFillTrophy += () => Player.AddBuff(ModContent.BuffType<TrophyBuff>(), int.MaxValue);
            _bannerCollection.OnEmptyTrophy += () => Player.ClearBuff(ModContent.BuffType<TrophyBuff>());
        }
        public override void PostUpdate()
        {
            _bannerCollection.Update(Player);

            if (Player.HasBuff(ModContent.BuffType<SpawnRateBuff>()))
                Player.AddBuff(ModContent.BuffType<SpawnRateBuff>(), 10);
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            damage = (int)(damage * _bannerCollection.GetDealtDamageMultiplier(target));
        }
        
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            ModifyHitNPC(null, target, ref damage, ref knockback, ref crit);
        }
        
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            float damageMultiplier = _bannerCollection.GetReceivedDamageMultiplier(damageSource);
            if (damageMultiplier == 0)
                return false;
            damage = (int)(damage * damageMultiplier);
            return true;
        }
    }
}
