using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using UltimateBannerMerging.Items;

namespace UltimateBannerMerging.Helpers
{
    internal class BannerCollection
    {
        private readonly Dictionary<int, float> _itemDictionary = new();

        private readonly Dictionary<int, float> _additionalMobDictionary = new();

        public event Action OnFillBanner;

        public event Action OnFillTrophy;

        public event Action OnEmptyBanner;

        public event Action OnEmptyTrophy;

        private (bool, bool) _filled = (false, false);

        public void Update(Player player, int mobCap, int bossCap)
        {
            _itemDictionary.Clear();

            Fill(player.inventory, mobCap, bossCap);
            Fill(player.bank.item, mobCap, bossCap);
            Fill(player.bank2.item, mobCap, bossCap);
            Fill(player.bank3.item, mobCap, bossCap);
            Fill(player.bank4.item, mobCap, bossCap);

            DetectFill(ref _filled.Item1, MapData.IsVanillaBanner, OnFillBanner, OnEmptyBanner);
            DetectFill(ref _filled.Item2, MapData.IsVanillaTrophy, OnFillTrophy, OnEmptyTrophy);
        }

        private void Fill(IEnumerable<Item> inventory, int mobCap, int bossCap)
        {
            foreach (var item in inventory.Where(i => (i?.active ?? false) && !i.IsAir))
            {
                if (MapData.IsVanillaBanner(item.netID) || MapData.IsVanillaTrophy(item.netID))
                {
                    AddItem(item.netID, item.stack, mobCap, bossCap);
                }
                else if (item.ModItem is BannerItem bannerItem)
                {
                    AddMergedBanner(bannerItem, item.stack, mobCap, bossCap);
                }
                else if (MapData.IsModdedBanner(item) || MapData.IsModdedTrophy(item))
                {
                    AddModdedBanner(item, mobCap, bossCap);
                }
            }
        }

        private void DetectFill(ref bool isFilled, Func<int, bool> check, Action onFill, Action onEmpty)
        {
            if (!isFilled && _itemDictionary.Any(e => check(e.Key)))
            {
                isFilled = true;
                onFill();
            }
            else if (isFilled && _itemDictionary.All(e => !check(e.Key)))
            {
                isFilled = false;
                onEmpty();
            }
        }

        private void AddItem(int itemId, float quantity, int mobCap, int bossCap)
        {
            _itemDictionary.AddOrAppend(itemId, quantity,
                MapData.IsVanillaBanner(itemId) ? mobCap : bossCap);
        }

        private void AddMergedBanner(BannerItem mergedBanner, float quantity, int mobCap, int bossCap)
        {
            foreach (int bannerId in mergedBanner.BannerList)
            {
                AddItem(bannerId, mergedBanner.Multiplier * quantity, mobCap, bossCap);
            }
            foreach (short mob in mergedBanner.AdditionalMobs)
            {
                AddAdditionalMob(mob, mergedBanner.Multiplier * quantity, mobCap, bossCap);
            }
            foreach (BannerItem mergedBanner2 in mergedBanner.BannerItems)
            {
                AddMergedBanner(mergedBanner2, mergedBanner.Multiplier * quantity, mobCap, bossCap);
            }
        }

        private void AddAdditionalMob(int mobId, float quantity, int mobCap, int bossCap)
        {
            _additionalMobDictionary.AddOrAppend(mobId, quantity,
                !MapData.IsBoss(mobId) ? mobCap : bossCap);
        }

        private void AddModdedBanner(Item item, int mobCap, int bossCap)
        {
            if (!MapData.IsInModList(item))
                return;
            
            _itemDictionary.AddOrAppend(item.ModItem.Type, item.stack,
                MapData.IsModdedBanner(item) ? mobCap : bossCap);
        }
        
        public float GetBannerQuantity(int bannerId)
        {
            if (_itemDictionary.ContainsKey(bannerId))
                return _itemDictionary[bannerId];
            return 0;
        }

        public float GetAdditionalQuantity(int mobId)
        {
            if (_additionalMobDictionary.ContainsKey(mobId))
                return _additionalMobDictionary[mobId];
            return 0;
        }
    }
}
