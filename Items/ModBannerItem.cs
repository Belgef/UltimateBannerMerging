using System;
using System.Linq;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.ModLoader;
using UltimateBannerMerging.Helpers;

namespace UltimateBannerMerging.Items;

public abstract class ModBannerItem : BannerItem
{
    private int[] _bannerList;
    public override int[] BannerList
    {
        get
        {
            _bannerList ??= MapData.GetModdedBannerIngredients(Name, ModSource);
            return _bannerList;
        }
    }

    private int[] _bannerItemIds;
    public override int[] BannerItemIds
    {
        get
        {
            _bannerItemIds ??= MapData.GetModdedBannerMergedIngredients(Name, ModSource);
            return _bannerItemIds;
        }
    }

    private int[] _additionalMobs;
    public override int[] AdditionalMobs
    {
        get
        {
            _additionalMobs ??= Array.Empty<int>();
            return _additionalMobs;
        }
    }
    
    public abstract string ModSource { get; }

    public override ModBannerItem[] BannerItems => BannerItemIds.Select(s => ModContent.GetModItem(s) as ModBannerItem).ToArray();

    public override string Texture => (GetType().Namespace + ".ModSprites." + Name).Replace('.', '/');

    public override bool IsLoadingEnabled(Mod mod) => ModLoader.TryGetMod(ModSource, out _);
		
}