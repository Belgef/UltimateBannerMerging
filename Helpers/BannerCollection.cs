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

            DetectFill(ref _filled.Item1, MapData.IsVanillaBanner, OnFillBanner, OnEmptyBanner);
            DetectFill(ref _filled.Item2, MapData.IsVanillaTrophy, OnFillTrophy, OnEmptyTrophy);
        }

        private void Fill(IEnumerable<Item> inventory)
        {
            foreach (var item in inventory.Where(i => (i?.active ?? false) && !i.IsAir))
            {
                if (MapData.IsVanillaBanner(item.netID) || MapData.IsVanillaTrophy(item.netID))
                {
                    AddItem(item.netID, item.stack);
                }
                else if (item.ModItem is BannerItem bannerItem)
                {
                    AddMergedBanner(bannerItem, item.stack);
                }
                else if (MapData.IsModdedBanner(item) || MapData.IsModdedTrophy(item))
                {
                    AddModdedBanner(item);
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
            _itemDictionary.AddOrAppend(itemId, quantity,
                MapData.IsVanillaBanner(itemId) ? _config.InvulnerabilityCap : _config.BossInvulnerabilityCap);
        }

        private void AddMergedBanner(BannerItem mergedBanner, float quantity)
        {
            foreach (int bannerId in mergedBanner.BannerList)
            {
                AddItem(bannerId, mergedBanner.Multiplier * quantity);
            }
            foreach (short mob in mergedBanner.AdditionalMobs)
            {
                AddAdditionalMob(mob, mergedBanner.Multiplier * quantity);
            }
            foreach (BannerItem mergedBanner2 in mergedBanner.BannerItems)
            {
                AddMergedBanner(mergedBanner2, mergedBanner.Multiplier * quantity);
            }
        }

        private void AddAdditionalMob(int mobId, float quantity)
        {
            _additionalMobDictionary.AddOrAppend(mobId, quantity,
                !MapData.IsBoss(mobId) ? _config.InvulnerabilityCap : _config.BossInvulnerabilityCap);
        }

        private void AddModdedBanner(Item item)
        {
            if (!MapData.IsInModList(item))
                return;
            
            _itemDictionary.AddOrAppend(item.ModItem.Type, item.stack,
                MapData.IsModdedBanner(item) ? _config.InvulnerabilityCap : _config.BossInvulnerabilityCap);
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

                 return MapData.IsBoss(normalizedId)
                     ? Calculator.CalculateDealtDamageMultiplier(quantity, _config.BossInvulnerabilityCap,
                         _config.MaxBossDamageIncrease)
                     : Calculator.CalculateDealtDamageMultiplier(quantity, _config.InvulnerabilityCap,
                         _config.MaxDamageIncrease);
             }
             if(MapData.IsInModList(npc))
             {
                 float quantity = 0;
                 string normalizedName = MapData.Normalize(npc);
                 if (ModContent.TryFind(npc.ModNPC.Mod.Name, normalizedName, out ModNPC normalizedNpc))
                 {
                     if (TryGetAdditionalMobQuantity(normalizedNpc.Type, out float quantity2))
                     {
                         quantity = quantity2;
                     }
                     else if (MapData.TryMapNPCToBanner(normalizedName, npc.ModNPC.Mod.Name, out string bannerName))
                     {
                         if (ModContent.TryFind(npc.ModNPC.Mod.Name, bannerName, out ModItem bannerItem))
                             quantity = GetBannerQuantity(bannerItem.Type);
                     }
                     else
                         Logging.PublicLogger.Warn($"Cannot find banner of {npc.ModNPC.Mod.Name} NPC \"{npc.FullName}\"");
                 }
                
                 return MapData.IsBoss(normalizedName, npc.ModNPC.Mod.Name)
                     ? Calculator.CalculateDealtDamageMultiplier(quantity, _config.BossInvulnerabilityCap,
                         _config.MaxBossDamageIncrease)
                     : Calculator.CalculateDealtDamageMultiplier(quantity, _config.InvulnerabilityCap,
                         _config.MaxDamageIncrease);
             }
             return 1;
        }

        private float GetBannerQuantity(int bannerId)
        {
            if (_itemDictionary.ContainsKey(bannerId))
                return _itemDictionary[bannerId];
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
                return GetReceivedNPCDamageMultiplier(npc);
            }
            if (damageSource.SourceProjectileIndex != -1)
                return GetReceivedProjectileDamageMultiplier(Main.projectile[damageSource.SourceProjectileIndex]);
            return 1;
        }

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

        public float GetReceivedProjectileDamageMultiplier(Projectile projectile)
        {
            if (MapData.TryGetProjectileOwners(projectile.type, out int[] owners))
                return owners.Select(GetReceivedNPCDamageMultiplier).Min();
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
                    _config.DropMaxMultiplier);
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
                    _config.DropMaxMultiplier);
            }
        }
    }
}
