using Terraria;
using Terraria.ModLoader;

namespace UltimateBannerMerging.Helpers;

internal class ModdedMergingProjectile : MergingProjectile
{
    private readonly string _owner;

    private readonly string _modName;

    public ModdedMergingProjectile(Projectile proj, BannerCollection bannerCollection, BannerConfig config) : base(bannerCollection, config)
    {
        _modName = proj.ModProjectile.Mod.Name;
        _owner = MapData.GetModProjectileOwner(proj);
        _owner = (_owner == null) ? "" : MapData.Normalize(_owner, _modName);

        _calculator = MapData.IsBoss(_owner, _modName)
            ? new(config.BossInvulnerabilityCap, config.MaxBossDamageIncrease, config.MaxLootMultiplier)
            : new(config.InvulnerabilityCap, config.MaxDamageIncrease, config.MaxLootMultiplier);
    }

    protected override float GetQuantity()
    {
        if (!ModContent.TryFind(_modName, _owner, out ModNPC ownerNPC))
            return 0;

        float quantity = _bannerCollection.GetAdditionalQuantity(ownerNPC.Type);

        if (quantity == 0 && MapData.TryMapModdedNPCToBanner(_owner, _modName, out string bannerName) &&
            ModContent.TryFind(_modName, bannerName, out ModItem banner))
        {
            quantity = _bannerCollection.GetBannerQuantity(banner.Type);
        }

        return quantity;
    }
}