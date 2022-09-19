using Terraria;

namespace UltimateBannerMerging.Helpers;

internal class VanillaMergingProjectile : MergingProjectile
{
    private readonly int _owner;

    public VanillaMergingProjectile(Projectile proj, BannerCollection bannerCollection, BannerConfig config)
        : base(bannerCollection, config)
    {
        _owner = MapData.GetVanillaProjectileOwner(proj.type);
        if(_owner != -1) 
            MapData.Normalize(_owner);

        _calculator = MapData.IsBoss(_owner)
            ? new(config.BossInvulnerabilityCap, config.MaxBossDamageIncrease, 1)
            : new(config.InvulnerabilityCap, config.MaxDamageIncrease, config.MaxLootMultiplier);
    }

    protected override float GetQuantity()
    {
        float quantity = _bannerCollection.GetAdditionalQuantity(_owner);

        if (quantity == 0 && MapData.TryMapNPCToBanner(_owner, out int bannerId))
            quantity = _bannerCollection.GetBannerQuantity(bannerId);

        return quantity;
    }
}