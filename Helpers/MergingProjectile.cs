using Terraria;

namespace UltimateBannerMerging.Helpers;

internal abstract class MergingProjectile : MergingObject
{
    protected MergingProjectile(BannerCollection bannerCollection, BannerConfig config) : base(bannerCollection, config) { }

    public static MergingProjectile Create(Projectile proj, BannerCollection bannerCollection, BannerConfig config)
    {
        return proj.ModProjectile != null
            ? new ModdedMergingProjectile(proj, bannerCollection, config)
            : new VanillaMergingProjectile(proj, bannerCollection, config);
    }
}