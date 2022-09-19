using Terraria;

namespace UltimateBannerMerging.Helpers;

internal abstract class MergingObject
{
    protected readonly BannerCollection _bannerCollection;

    protected readonly BannerConfig _config;

    protected DamageCalculator _calculator;

    protected MergingObject(BannerCollection bannerCollection, BannerConfig config)
    {
        _bannerCollection = bannerCollection;
        _config = config;
    }

    public static MergingObject Create(object obj, BannerCollection bannerCollection, BannerConfig config) =>
        obj switch
        {
            NPC npc => MergingNPC.Create(npc, bannerCollection, config),
            Projectile proj => MergingProjectile.Create(proj, bannerCollection, config),
            _ => null
        };

    protected abstract float GetQuantity();

    public float GetDealtDamageMultiplier() 
        => _calculator.CalculateDealtDamageMultiplier(GetQuantity());

    public float GetReceivedDamageMultiplier() 
        => _calculator.CalculateReceivedDamageMultiplier(GetQuantity());
}