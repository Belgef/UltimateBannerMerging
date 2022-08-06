using Terraria;
using Terraria.DataStructures;
using UltimateBannerMerging.NPCs;
using UltimateBannerMerging.Players;

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

    public static MergingNPC Create(NPC npc, BannerCollection bannerCollection, BannerConfig config)
    {
        if (npc.ModNPC != null)
            return new ModdedMergingNPC(npc, bannerCollection, config);
        return new VanillaMergingNPC(npc, bannerCollection, config);
    }

    public static MergingNPC Create(Projectile projectile, BannerCollection bannerCollection, BannerConfig config)
    {
        if (projectile.ModProjectile != null)
            return ModdedMergingNPC.FromProjectile(projectile, bannerCollection, config);
        return new VanillaMergingNPC.FromProjectile(projectile, bannerCollection, config);
    }

    protected abstract float GetQuantity();

    public float GetDealtDamageMultiplier()
    {
        return _calculator.CalculateDealtDamageMultiplier(GetQuantity());
    }

    public float GetReceivedDamageMultiplier()
    {
        return _calculator.CalculateReceivedDamageMultiplier(GetQuantity());
    }

    public void SetNPCLootParameters(BannerPlayer player, int lastDamage)
    {
        MoreLootNPC gnpc = _npc.GetGlobalNPC<MoreLootNPC>();
        gnpc.Player = player;
        gnpc.LastDamage = lastDamage;
    }
}