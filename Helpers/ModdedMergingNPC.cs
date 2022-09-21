using Terraria;
using Terraria.ModLoader;

namespace UltimateBannerMerging.Helpers;

internal class ModdedMergingNPC : MergingNPC
{
    private readonly string _normalizedName;

    private readonly string _modName;

    public ModdedMergingNPC(NPC npc, BannerCollection bannerCollection, BannerConfig config) 
        : base(npc, bannerCollection, config)
    {
        _modName = npc.ModNPC.Mod.Name;
        _normalizedName = MapData.Normalize(npc.ModNPC.Name, _modName);

        _calculator = MapData.IsBoss(_normalizedName, _modName)
            ? new(config.BossInvulnerabilityCap, config.MaxBossDamageIncrease, config.MaxLootMultiplier)
            : new(config.InvulnerabilityCap, config.MaxDamageIncrease, config.MaxBossLootMultiplier);
    }

    protected override float GetQuantity()
    {
        if (!ModContent.TryFind(_modName, _normalizedName, out ModNPC normalizedNpc))
            return 0;

        float quantity = _bannerCollection.GetAdditionalQuantity(normalizedNpc.Type);

        if (quantity == 0 && MapData.TryMapModdedNPCToBanner(_normalizedName, _modName, out string bannerName) &&
            ModContent.TryFind(_modName, bannerName, out ModItem banner))
        {
            quantity = _bannerCollection.GetBannerQuantity(banner.Type);
        }

        return quantity;
    }

    public override float GetLootMultiplier() => _calculator.CalculateLootMultiplier(GetQuantity());
}