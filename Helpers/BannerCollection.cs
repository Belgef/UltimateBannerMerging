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

        private readonly BannerConfig _config;

        public BannerCollection(BannerConfig config) => _config = config;

        public event Action OnFillBanner;

        public event Action OnFillTrophy;

        public event Action OnEmptyBanner;

        public event Action OnEmptyTrophy;

        private (bool, bool) _filled = (false, false);

        public void Update(Player player)
        {
            _itemDictionary.Clear();

            Fill(player.inventory);
            Fill(player.bank.item);
            Fill(player.bank2.item);
            Fill(player.bank3.item);
            Fill(player.bank4.item);

            DetectFill(ref _filled.Item1, e => MapData.IsVanillaBanner(e), OnFillBanner, OnEmptyBanner);
            DetectFill(ref _filled.Item2, e => MapData.IsVanillaTrophy(e), OnFillTrophy, OnEmptyTrophy);
        }

        private void Fill(Item[] inventory)
        {
            foreach (var item in inventory.Where(i => i?.active ?? false && !i.IsAir))
            {
                if (MapData.IsVanillaBanner(item.netID) || MapData.IsVanillaTrophy(item.netID))
                {
                    AddItem(item.netID, item.stack);
                }
                else if (item.ModItem is BannerItem bannerItem)
                {
                    AddMergedBanner(bannerItem, item.stack);
                }
                else if (MapData.IsModdedBanner(item))
                {
                    AddModdedBanner(item.ModItem.Name, item.stack, item.ModItem.Mod.Name);
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

        private void AddItem(int itemId, float quantity)
        {
            if (_itemDictionary.ContainsKey(itemId))
                _itemDictionary[itemId] += quantity;
            else
                _itemDictionary.Add(itemId, quantity);
            if (_itemDictionary[itemId] > _config.InvulnerabilityCap)
                _itemDictionary[itemId] = _config.InvulnerabilityCap;
        }

        private void AddAdditionalMob(int mobId, float quantity)
        {
            if (_additionalMobDictionary.ContainsKey(mobId))
                _additionalMobDictionary[mobId] += quantity;
            else
                _additionalMobDictionary.Add(mobId, quantity);
            if (_additionalMobDictionary[mobId] > _config.InvulnerabilityCap)
                _additionalMobDictionary[mobId] = _config.InvulnerabilityCap;
        }

        private void AddMergedBanner(BannerItem mergedBanner, float quantity)
        {
            foreach (var bannerId in mergedBanner.BannerList)
            {
                AddItem(bannerId, mergedBanner.Multiplier * quantity);
            }
            foreach (var mob in mergedBanner.AdditionalMobs)
            {
                AddAdditionalMob(mob, mergedBanner.Multiplier * quantity);
            }
            foreach (var mergedBannerId in mergedBanner.BannerItems)
            {
                AddMergedBanner(mergedBannerId, mergedBanner.Multiplier * quantity);
            }
        }

        private void AddModdedBanner(string bannerName, int stack, string mod)
        {
            if (MapData.ModBannersData.ContainsKey(mod))
            {
                ModBannersData data = MapData.ModBannersData[mod];
                string npcName = data.UniqueBanners.ContainsKey(bannerName) ?
                    data.UniqueBanners[bannerName] :
                    bannerName.Replace("Banner", "");

                if (ModContent.TryFind(mod, npcName, out ModNPC npc))
                {
                    AddItem(npc.Type, stack);
                }
                else
                    Logging.PublicLogger.Warn($"Cannot find {npc.Mod} NPC \"{npc.Name}\" from {bannerName}");
            }

        }

        public float GetDealtDamageMultiplier(NPC npc)
        {
            if (npc.ModNPC == null)
            {
                float quantity = 0;
                int normalizedId = MapData.Normalize(npc.netID);
                if (TryGetAdditionalMobQuantity(normalizedId, out float quantity2))
                {
                    quantity = quantity2;
                }
                else if (MapData.TryMapNPCToBanner(normalizedId, out int bannerId))
                {
                    quantity = GetBannerQuantity(bannerId);
                }
                else
                    Logging.PublicLogger.Warn($"Cannot find banner of Terraria NPC \"{npc.FullName}\"");

                return Calculator.CalculateDealtDamageMultiplier(quantity, _config.InvulnerabilityCap, _config.MaxDamageIncrease);
            }
            else
            {
                //TODO
            }
            return 1;
        }

        private float GetBannerQuantity(int bannerId)
        {
            if (_itemDictionary.ContainsKey(bannerId))
                return _itemDictionary[bannerId];
            else
                return 0;
        }

        private bool TryGetAdditionalMobQuantity(int mobId, out float quantity)
        {
            quantity = 0;
            if (!_additionalMobDictionary.ContainsKey(mobId))
                return false;
            quantity = _additionalMobDictionary[mobId];
            return true;
        } 

        public float GetReceivedDamageMultiplier(PlayerDeathReason damageSource)
        {
            if (damageSource.SourceNPCIndex != -1)
            {
                NPC npc = Main.npc[damageSource.SourceNPCIndex];
                return GetReceivedNPCDamageMultiplier(npc.netID, npc.ModNPC != null);
            }
            else if (damageSource.SourceProjectileIndex != -1)
                return GetReceivedProjectileDamageMultiplier(Main.projectile[damageSource.SourceProjectileIndex].type);
            return 1;
        }

        private float GetReceivedNPCDamageMultiplier(int npcId, bool isModded)
        {
            if (!isModded)
            {
                float quantity = 0;
                int normalizedId = MapData.Normalize(npcId);
                if (TryGetAdditionalMobQuantity(normalizedId, out float quantity2))
                {
                    quantity = quantity2;
                }
                else if (MapData.TryMapNPCToBanner(normalizedId, out int bannerId))
                {
                    quantity = GetBannerQuantity(bannerId);
                }
                else
                    Logging.PublicLogger.Warn($"Cannot find banner of Terraria NPC \"{npcId}\"");

                return Calculator.CalculateReceivedDamageMultiplier(quantity, _config.InvulnerabilityCap);
            }
            else
            {
                //TODO
            }
            return 1;
        }

        public float GetReceivedProjectileDamageMultiplier(int projectileId)
        {
            if (!MapData.TryGetProjectileOwners(projectileId, out int[] owners))
                return 1;
            float minMultiplier = 1;
            foreach (var owner in owners)
            {
                float multiplier = GetReceivedNPCDamageMultiplier(owner, false);
                if(multiplier < minMultiplier)
                    minMultiplier = multiplier;
            }
            return minMultiplier;
        }
    }
}
