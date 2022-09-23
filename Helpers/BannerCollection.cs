using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using UltimateBannerMerging.Buffs;
using UltimateBannerMerging.Items;

namespace UltimateBannerMerging.Helpers
{
    internal class BannerCollection
    {
        private readonly Dictionary<int, float> _itemDictionary = new();
        private readonly Dictionary<int, float> _additionalMobDictionary = new();

        public BuffToggleEvent BannerBuffToggleEvent { get; set; }
        public BuffToggleEvent TrophyBuffToggleEvent { get; set; }

        public Func<int> GetMobCap { get; set; }
        public Func<int> GetBossCap { get; set; }

        public BannerCollection(Player player, BannerConfig config)
        {
            BannerBuffToggleEvent = new(
                ModContent.BuffType<BannerBuff>(), player,
                () => _itemDictionary.Any(e => MapData.IsVanillaBanner(e.Key)),
                () => _itemDictionary.All(e => !MapData.IsVanillaBanner(e.Key)));
            TrophyBuffToggleEvent = new(
                ModContent.BuffType<TrophyBuff>(), player,
                () => _itemDictionary.Any(e => MapData.IsVanillaTrophy(e.Key)),
                () => _itemDictionary.All(e => !MapData.IsVanillaBanner(e.Key)));

            GetMobCap = () => config.InvulnerabilityCap;
            GetBossCap = () => config.BossInvulnerabilityCap;
        }

        public void Update(Player player)
        {
            _itemDictionary.Clear();

            Fill(player.inventory);
            Fill(player.bank.item);
            Fill(player.bank2.item);
            Fill(player.bank3.item);
            Fill(player.bank4.item);

            BannerBuffToggleEvent.Update();
            TrophyBuffToggleEvent.Update();
        }

        private void Fill(IEnumerable<Item> inventory)
        {
            foreach (Item item in inventory.Where(i => (i?.active ?? false) && !i.IsAir))
            {
                if (MapData.IsVanillaBanner(item.netID) || MapData.IsVanillaTrophy(item.netID))
                {
                    AddItem(item.netID, item.stack);
                }
                else if (item.ModItem is BannerItem bannerItem and not ModBannerItem )
                {
                    AddMergedBanner(bannerItem, item.stack);
                }
                else if (item.ModItem is ModBannerItem modBannerItem && ModLoader.TryGetMod(modBannerItem.ModSource, out _))
                {
                    AddMergedBanner(modBannerItem, item.stack);
                }
                else if (item.ModItem is not BannerItem && (MapData.IsModdedBanner(item) || MapData.IsModdedTrophy(item)))
                {
                    AddModdedBanner(item);
                }
            }
        }

        private void AddItem(int itemId, float quantity)
        {
            _itemDictionary.AddOrAppend(itemId, quantity,
                MapData.IsVanillaBanner(itemId) ? GetMobCap() : GetBossCap());
        }

        private void AddMergedBanner(BannerItem mergedBanner, float quantity)
        {
            foreach (int bannerId in mergedBanner.BannerList)
            {
                AddItem(bannerId, mergedBanner.Multiplier * quantity);
            }
            foreach (int mob in mergedBanner.AdditionalMobs)
            {
                AddAdditionalMob(mob, mergedBanner.Multiplier * quantity);
            }
            foreach (BannerItem mergedBanner2 in mergedBanner.BannerItems)
            {
                AddMergedBanner(mergedBanner2, mergedBanner.Multiplier * quantity);
            }
            foreach (int groupItemId in mergedBanner.GroupItems)
            {
                AddItem(groupItemId, mergedBanner.Multiplier * quantity);
            }
            foreach (BannerItem groupMergedBanner in mergedBanner.GroupMergedItems)
            {
                AddMergedBanner(groupMergedBanner, mergedBanner.Multiplier * quantity);
            }
        }

        private void AddAdditionalMob(int mobId, float quantity)
        {
            _additionalMobDictionary.AddOrAppend(mobId, quantity,
                !MapData.IsBoss(mobId) ? GetMobCap() : GetBossCap());
        }

        private void AddModdedBanner(Item item)
        {
            if (!MapData.IsInModList(item))
                return;
            
            _itemDictionary.AddOrAppend(item.ModItem.Type, item.stack,
                MapData.IsModdedBanner(item) ? GetMobCap() : GetBossCap());
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
