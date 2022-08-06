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

        public BannerConfig Config { get; set; }

        public override void Initialize()
        {
            BannerCollection = new();
            Config = Mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
            BannerCollection.OnFillBanner += () => Player.AddBuff(ModContent.BuffType<BannerBuff>(), int.MaxValue);
            BannerCollection.OnEmptyBanner += () => Player.ClearBuff(ModContent.BuffType<BannerBuff>());
            BannerCollection.OnFillTrophy += () => Player.AddBuff(ModContent.BuffType<TrophyBuff>(), int.MaxValue);
            BannerCollection.OnEmptyTrophy += () => Player.ClearBuff(ModContent.BuffType<TrophyBuff>());
        }
        public override void PostUpdate()
        {
            BannerCollection.Update(Player, Config.InvulnerabilityCap, Config.BossInvulnerabilityCap);//WARNING

            if (Player.HasBuff(ModContent.BuffType<SpawnRateBuff>()))
                Player.AddBuff(ModContent.BuffType<SpawnRateBuff>(), 10);
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            MergingNPC mergingNPC = MergingNPC.Create(target, BannerCollection, Config);

            damage = (int)(damage * mergingNPC.GetDealtDamageMultiplier());

            mergingNPC.SetNPCLootParameters(this, damage);
        }
        
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            ModifyHitNPC(null, target, ref damage, ref knockback, ref crit);
        }
        
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            MergingNPC npc;
            if (damageSource.SourceNPCIndex != -1)
                npc = MergingNPC.Create(Main.npc[damageSource.SourceNPCIndex], BannerCollection, Config);
            else if (damageSource.SourceProjectileIndex != -1)
                npc = MergingNPC.Create(Main.projectile[damageSource.SourceProjectileIndex], BannerCollection, Config);



            float damageMultiplier = BannerCollection.GetReceivedDamageMultiplier(damageSource);
            if (damageMultiplier == 0)
                return false;
            damage = (int)(damage * damageMultiplier);
            return true;
        }
    }
}
