//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Terraria;
//using Terraria.DataStructures;
//using Terraria.GameContent.ItemDropRules;
//using Terraria.ID;
//using Terraria.ModLoader;
//using UltimateBannerMerging.Players;

//namespace UltimateBannerMerging.NPCs
//{
//    internal class MoreLootNPC : GlobalNPC
//    {
//        public MoreLootPlayer Player { get; set; }
//        public int LastDamage { get; set; }

//        public override bool InstancePerEntity => true;

//        private static readonly List<int> _black_list = new List<int>() { 
//            NPCID.MotherSlime,
//            NPCID.SolarCorite,
//            NPCID.SolarCrawltipedeHead,
//            NPCID.SolarDrakomire,
//            NPCID.SolarDrakomireRider,
//            NPCID.SolarSolenian,
//            NPCID.SolarSpearman,
//            NPCID.SolarSroller,
//            NPCID.NebulaBeast,
//            NPCID.NebulaBrain,
//            NPCID.NebulaHeadcrab,
//            NPCID.NebulaSoldier,
//            NPCID.VortexHornet,
//            NPCID.VortexHornetQueen,
//            NPCID.VortexLarva,
//            NPCID.VortexRifleman,
//            NPCID.VortexSoldier,
//            NPCID.StardustCellBig,
//            NPCID.StardustCellSmall,
//            NPCID.StardustJellyfishBig,
//            NPCID.StardustJellyfishSmall,
//            NPCID.StardustSoldier,
//            NPCID.StardustSpiderBig,
//            NPCID.StardustSpiderSmall,
//            NPCID.StardustWormHead,
//            NPCID.Slimer
//        };
//        public override void OnKill(Terraria.NPC npc)
//        {
//            if (Player != null)
//            {
//                var config = Mod.GetConfig(nameof(BannerConfig)) as BannerConfig;

//                int mobID;
//                if (npc.ModNPC != null)
//                {
//                    if (MobConverter.ModBannersData.ContainsKey(npc.ModNPC.Mod.Name))
//                    {
//                        ModBannersData data = MobConverter.ModBannersData[npc.ModNPC.Mod.Name];
//                        mobID = npc.ModNPC.Type;
//                        if (data.Multiparts.ContainsKey(npc.ModNPC.Name))
//                        {
//                            if (ModContent.TryFind(npc.ModNPC.Mod.Name, data.Multiparts[npc.ModNPC.Name], out ModNPC npcauth))
//                            {
//                                mobID = npcauth.Type;
//                            }
//                            else
//                            {
//                                Logging.PublicLogger.Warn(data.Multiparts[npc.ModNPC.Name] + " is not found mob prehit");
//                                return;
//                            }
//                        }

//                    }
//                    else return;
//                }
//                else
//                {
//                    mobID = MobConverter.GetMobID(npc);
//                    if (MobConverter.NPCProjectileOwners.ContainsKey(mobID))
//                        mobID = MobConverter.NPCProjectileOwners[mobID];
//                }
//                var currentMobs = Player.Player.GetModPlayer<BannerPlayer>().CurrentMobs;
//                float quantity = (currentMobs.ContainsKey(mobID) &&
//                    !_black_list.Contains(mobID)) ? currentMobs[mobID] : 0;
//                float lootMultiplier = quantity / config.InvulnerabilityCap * (config.DropMaxMultiplier-1);
//                CombatText.clearAll();
//                for (int i = 0; i < (int)lootMultiplier; i++)
//                    Main.npc[Terraria.NPC.NewNPC(npc.GetSource_Loot(), (int)npc.position.X, (int)npc.position.Y, npc.type)].StrikeNPCNoInteraction(int.MaxValue, 0, 0);
//                CombatText.clearAll();
//                CombatText.NewText(new Microsoft.Xna.Framework.Rectangle((int)npc.position.X, (int)npc.position.Y, 1, 1), CombatText.DamagedHostile, LastDamage);
//            }
//        }
//    }
//}
