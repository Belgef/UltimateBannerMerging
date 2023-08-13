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
            Config = Mod.GetConfig(nameof(BannerConfig)) as BannerConfig;
            BannerCollection = new(Player, Config);
        }
        public override void PostUpdate()
        {
            BannerCollection.Update(Player);

            if (Player.HasBuff(ModContent.BuffType<SpawnRateBuff>()))
                Player.AddBuff(ModContent.BuffType<SpawnRateBuff>(), 10);
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            MergingNPC mergingNPC = MergingNPC.Create(target, BannerCollection, Config);

            modifiers.FinalDamage += mergingNPC.GetDealtDamageMultiplier();

            mergingNPC.SetNPCLootParameters();
        }

        public override bool ImmuneTo(PlayerDeathReason damageSource, int cooldownCounter, bool dodgeable)
        {
            MergingNPC npc = null;

            if (damageSource.SourceNPCIndex != -1)
                npc = MergingNPC.Create(Main.npc[damageSource.SourceNPCIndex], BannerCollection, Config);
            else if (damageSource.SourceProjectileLocalIndex != -1)
                npc = MergingNPC.Create(Main.projectile[damageSource.SourceProjectileLocalIndex], BannerCollection, Config);

            float damageMultiplier = npc?.GetReceivedDamageMultiplier() ?? 1;
            return damageMultiplier == 0;
        }

        public override void ModifyHitByNPC(NPC npc, ref Player.HurtModifiers modifiers)
        {
            MergingNPC mnpc = MergingNPC.Create(npc, BannerCollection, Config);

            float damageMultiplier = mnpc?.GetReceivedDamageMultiplier() ?? 1;

            modifiers.FinalDamage *= damageMultiplier;
        }

        public override void ModifyHitByProjectile(Projectile proj, ref Player.HurtModifiers modifiers)
        {
            MergingNPC npc = MergingNPC.Create(proj, BannerCollection, Config);

            float damageMultiplier = npc?.GetReceivedDamageMultiplier() ?? 1;

            modifiers.FinalDamage *= damageMultiplier;
        }
    }
}
