using System;
using Terraria;
using Terraria.DataStructures;
using UltimateBannerMerging.NPCs;
using UltimateBannerMerging.Players;
using UltimateBannerMerging.Projectiles;

namespace UltimateBannerMerging.Helpers;

internal abstract class MergingNPC
{
    protected readonly NPC _npc;

    protected readonly BannerCollection _bannerCollection;

    protected readonly BannerConfig _config;

    protected DamageCalculator _calculator;

    protected MergingNPC(NPC npc, BannerCollection bannerCollection, BannerConfig config)
    {
        _npc = npc;
        _bannerCollection = bannerCollection;
        _config = config;
    }

    public static MergingNPC Create(NPC npc, BannerCollection bannerCollection, BannerConfig config) =>
        npc.ModNPC != null
            ? new ModdedMergingNPC(npc, bannerCollection, config)
            : new VanillaMergingNPC(npc, bannerCollection, config);

    // Create: Method not found: '!!0 Terraria.Projectile.GetGlobalProjectile(Boolean)'.
    public static MergingNPC Create(Projectile proj, BannerCollection bannerCollection, BannerConfig config)
    {
        NPC author = proj.GetGlobalProjectile<ProjectileWithAuthor>().Author;
        return author != null ? Create(author, bannerCollection, config) : null;
    }

    protected abstract float GetQuantity();

    public float GetDealtDamageMultiplier()
        => _calculator.CalculateDealtDamageMultiplier(GetQuantity());

    public float GetReceivedDamageMultiplier()
        => _calculator.CalculateReceivedDamageMultiplier(GetQuantity());

    public void SetNPCLootParameters()
    {
        MoreLootNPC gnpc = _npc.GetGlobalNPC<MoreLootNPC>();
        gnpc.EntitiesToKill = (int)Math.Ceiling(GetLootMultiplier()) - 1;
        gnpc.MaxEntitiesToKill = gnpc.EntitiesToKill;
    }

    public abstract float GetLootMultiplier();
}