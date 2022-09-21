using Terraria;

namespace UltimateBannerMerging.Helpers;

internal class VanillaMergingNPC : MergingNPC
{
    private readonly int _normalizedId;

    public VanillaMergingNPC(NPC npc, BannerCollection bannerCollection, BannerConfig config) 
        : base(npc, bannerCollection, config)
    {
        _normalizedId = MapData.Normalize(npc.netID);

        _calculator = MapData.IsBoss(_normalizedId)
            ? new(config.BossInvulnerabilityCap, config.MaxBossDamageIncrease, config.MaxBossLootMultiplier)
            : new(config.InvulnerabilityCap, config.MaxDamageIncrease, config.MaxLootMultiplier);
    }

    protected override float GetQuantity()
    {
        float quantity = _bannerCollection.GetAdditionalQuantity(_normalizedId);

        if (quantity == 0 && MapData.TryMapNPCToBanner(_normalizedId, out int bannerId))
            quantity = _bannerCollection.GetBannerQuantity(bannerId);

        return quantity;
    }

    public override float GetLootMultiplier() => _calculator.CalculateLootMultiplier(GetQuantity());
}