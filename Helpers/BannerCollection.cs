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

        public BannerCollection(Player player)
        {
            BannerBuffToggleEvent = new(
                ModContent.BuffType<BannerBuff>(), player,
                () => _itemDictionary.Any(e => MapData.IsVanillaBanner(e.Key)),
                () => _itemDictionary.All(e => !MapData.IsVanillaBanner(e.Key)));
            TrophyBuffToggleEvent = new(
                ModContent.BuffType<TrophyBuff>(), player,
                () => _itemDictionary.Any(e => MapData.IsVanillaTrophy(e.Key)),
                () => _itemDictionary.All(e => !MapData.IsVanillaBanner(e.Key)));
        }

        public void Update(Player player, int mobCap, int bossCap)
        {
            _itemDictionary.Clear();

            Fill(player.inventory, mobCap, bossCap);
            Fill(player.bank.item, mobCap, bossCap);
            Fill(player.bank2.item, mobCap, bossCap);
            Fill(player.bank3.item, mobCap, bossCap);
            Fill(player.bank4.item, mobCap, bossCap);

            BannerBuffToggleEvent.Update();
            TrophyBuffToggleEvent.Update();
        }

        private void Fill(IEnumerable<Item> inventory, int mobCap, int bossCap)
        {
            foreach (Item item in inventory.Where(i => (i?.active ?? false) && !i.IsAir))
            {
                if (MapData.IsVanillaBanner(item.netID) || MapData.IsVanillaTrophy(item.netID))
                {
                    AddItem(item.netID, item.stack, mobCap, bossCap);
                }
                else if (item.ModItem is BannerItem bannerItem and not ModBannerItem )
                {
                    AddMergedBanner(bannerItem, item.stack, mobCap, bossCap);
                }
                else if (item.ModItem is ModBannerItem modBannerItem && ModLoader.TryGetMod(modBannerItem.ModSource, out _))
                {
                    AddMergedBanner(modBannerItem, item.stack, mobCap, bossCap);
                }
                else if (item.ModItem is not BannerItem && (MapData.IsModdedBanner(item) || MapData.IsModdedTrophy(item)))
                {
                    AddModdedBanner(item, mobCap, bossCap);
                }
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
            foreach (int mob in mergedBanner.AdditionalMobs)
            {
                AddAdditionalMob(mob, mergedBanner.Multiplier * quantity, mobCap, bossCap);
            }
            foreach (BannerItem mergedBanner2 in mergedBanner.BannerItems)
            {
                AddMergedBanner(mergedBanner2, mergedBanner.Multiplier * quantity, mobCap, bossCap);
            }
            foreach (int groupItemId in mergedBanner.GroupItems)
            {
                AddItem(groupItemId, mergedBanner.Multiplier * quantity, mobCap, bossCap);
            }
            foreach (BannerItem groupMergedBanner in mergedBanner.GroupMergedItems)
            {
                AddMergedBanner(groupMergedBanner, mergedBanner.Multiplier * quantity, mobCap, bossCap);
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
