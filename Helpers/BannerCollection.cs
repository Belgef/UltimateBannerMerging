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
        }//Good

        public float GetAdditionalQuantity(int mobId)
        {
            if (_additionalMobDictionary.ContainsKey(mobId))
                return _additionalMobDictionary[mobId];
            return 0;
        }//Good

        

        private float GetReceivedNPCDamageMultiplier(int npcId)
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

            return Calculator.CalculateReceivedDamageMultiplier(quantity,
                MapData.IsBoss(normalizedId) ? _config.BossInvulnerabilityCap : _config.InvulnerabilityCap);
        }

        private float GetReceivedNPCDamageMultiplier(NPC npc)
        {
            return npc.ModNPC == null
                ? GetReceivedNPCDamageMultiplier(npc.netID)
                : GetReceivedNPCDamageMultiplier(npc.ModNPC.Name, npc.ModNPC.Mod.Name);
        }

        private float GetReceivedNPCDamageMultiplier(string npcName, string modName)
        {
            float quantity = 0;
            string normalizedName = MapData.Normalize(npcName, modName);
            if (ModContent.TryFind(modName, normalizedName, out ModNPC normalizedNpc))
            {
                if (TryGetAdditionalMobQuantity(normalizedNpc.Type, out float quantity2))
                {
                    quantity = quantity2;
                }
                else if (MapData.TryMapNPCToBanner(normalizedName, modName, out string bannerName))
                {
                    if (ModContent.TryFind(modName, bannerName, out ModItem bannerItem))
                        quantity = GetBannerQuantity(bannerItem.Type);
                }
                else
                    Logging.PublicLogger.Warn($"Cannot find banner of {modName} NPC \"{npcName}\"");
            }

            return MapData.IsBoss(normalizedName, modName)
                ? Calculator.CalculateReceivedDamageMultiplier(quantity, _config.BossInvulnerabilityCap)
                : Calculator.CalculateReceivedDamageMultiplier(quantity, _config.InvulnerabilityCap);
        }

        public NPC GetProjectileOwner(Projectile projectile)
        {
            if (MapData.IsInModList(projectile))
            {

            }





            if (MapData.TryGetProjectileOwners(projectile.type, out int[] owners))
                return owners.Min(Comparer<int>.Create((n1, n2)=> GetReceivedNPCDamageMultiplier(n1).CompareTo(GetReceivedNPCDamageMultiplier(n2)))).;
            if (MapData.IsInModList(projectile) && MapData.TryGetProjectileOwner(projectile, out string owner))
            {
                return GetReceivedNPCDamageMultiplier(owner, projectile.ModProjectile.Mod.Name);
            }
            return 1;
        }

        public int GetLootMultiplier(NPC npc)
        {
            if (npc.ModNPC == null)
            {
                float quantity = 0;
                int normalizedId = MapData.Normalize(npc.netID);

                if (!MapData.IsInLootBlackList(normalizedId) && !MapData.IsBoss(normalizedId))
                {
                    if (TryGetAdditionalMobQuantity(normalizedId, out float quantity2))
                        quantity = quantity2;
                    else
                    {
                        if (MapData.TryMapNPCToBanner(normalizedId, out int bannerId))
                            quantity = GetBannerQuantity(bannerId);
                    }

                }

                return Calculator.CalculateLootMultiplier(quantity,
                    MapData.IsBoss(normalizedId) ? _config.BossInvulnerabilityCap : _config.InvulnerabilityCap,
                    _config.MaxLootMultiplier);
            }
            else
            {
                float quantity = 0;
                string normalizedName = MapData.Normalize(npc);

                if (!MapData.IsInLootBlackList(normalizedName, npc.ModNPC.Mod.Name) && !MapData.IsBoss(normalizedName, npc.ModNPC.Mod.Name))
                {
                    if (ModContent.TryFind(npc.ModNPC.Mod.Name, normalizedName, out ModNPC normalizedNpc))
                    {
                        if (TryGetAdditionalMobQuantity(normalizedNpc.Type, out float quantity2))
                        {
                            quantity = quantity2;
                        }
                    }
                    else
                    {
                        if (MapData.TryMapNPCToBanner(normalizedName, npc.ModNPC.Mod.Name, out string bannerName))
                        {
                            if (ModContent.TryFind(npc.ModNPC.Mod.Name, bannerName, out ModItem bannerItem))
                                quantity = GetBannerQuantity(bannerItem.Type);
                        }
                    }

                }

                return Calculator.CalculateLootMultiplier(quantity,
                    MapData.IsBoss(normalizedName, npc.ModNPC.Mod.Name) ? _config.BossInvulnerabilityCap : _config.InvulnerabilityCap,
                    _config.MaxLootMultiplier);
            }
        }
    }
}
