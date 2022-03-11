using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using UltimateBannerMerging.Buffs;
using UltimateBannerMerging.Items;

namespace UltimateBannerMerging
{
    internal class BannerPlayer : ModPlayer
    {
        public readonly Dictionary<Banner, int> CurrentBanners = new Dictionary<Banner, int>();
        public override void PostUpdate()
        {
            CurrentBanners.Clear();
            foreach(var item in player.inventory)
            {
                if(MobBanners.GetBannerByID(item.netID) != null)
                {
                    AddBanner(MobBanners.GetBannerByID(item.netID), item.stack);
                }
                else if(item.modItem is BannerItem modItem)
                {
                    AddModBanner(modItem, item.stack);
                }
            }
            if(CurrentBanners.Count > 0)
            {
                player.AddBuff(mod.GetBuff(nameof(BannerBuff)).Type, 10);
            }
            else
            {
                player.ClearBuff(mod.GetBuff(nameof(BannerBuff)).Type);
            }
        }
        private void AddModBanner(BannerItem modItem, int quantity)
        {
            foreach (var banner in modItem.BannerList.Concat(modItem.AdditionalBanners).Select(b => MobBanners.GetBannerByID(b)))
            {
                AddBanner(banner, modItem.Multiplyer * quantity);
            }
            foreach (var modBanner in modItem.BannerItems)
            {
                AddModBanner(modBanner, modItem.Multiplyer * quantity);
            }
        }
        private void AddBanner(Banner banner, int quantity)
        {
            if (CurrentBanners.ContainsKey(banner))
                CurrentBanners[banner] += quantity;
            else
                CurrentBanners.Add(banner, quantity);
        }
        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            var banner = MobBanners.GetBannerByMobName(target.FullName);
            if (banner != null && CurrentBanners.ContainsKey(banner))
                damage += (int)(damage * 0.2 * CurrentBanners[banner]);
        }
        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            var banner = MobBanners.GetBannerByMobName(npc.FullName);
            int coef = 40;
            if (banner != null && CurrentBanners.ContainsKey(banner))
                damage = (int)(coef * damage / (coef + CurrentBanners[banner]));
        }
    }
}
