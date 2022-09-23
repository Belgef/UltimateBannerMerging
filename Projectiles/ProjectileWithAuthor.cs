using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace UltimateBannerMerging.Projectiles
{
    internal class ProjectileWithAuthor : GlobalProjectile
    {
        public NPC Author { get; set; }
        public override bool InstancePerEntity => true;
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (source is EntitySource_Parent { Entity: NPC parent })
                Author = parent;
        }
    }
}
