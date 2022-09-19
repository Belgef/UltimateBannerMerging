using Terraria;
using Terraria.DataStructures;
using UltimateBannerMerging.NPCs;
using UltimateBannerMerging.Players;

namespace UltimateBannerMerging.Helpers;

internal abstract class MergingNPC : MergingObject
{
    protected readonly NPC _npc;

    protected MergingNPC(NPC npc, BannerCollection bannerCollection, BannerConfig config) : base(bannerCollection, config) => _npc = npc;

    public static MergingNPC Create(NPC npc, BannerCollection bannerCollection, BannerConfig config)
    {
        return npc.ModNPC != null
            ? new ModdedMergingNPC(npc, bannerCollection, config)
            : new VanillaMergingNPC(npc, bannerCollection, config);
    }

    public void SetNPCLootParameters(BannerPlayer player, int lastDamage)
    {
        MoreLootNPC gnpc = _npc.GetGlobalNPC<MoreLootNPC>();
        gnpc.Player = player;
        gnpc.LastDamage = lastDamage;
    }

    public float GetLootMultiplier()
    {
        return _calculator.CalculateLootMultiplier(GetQuantity());
    }
}