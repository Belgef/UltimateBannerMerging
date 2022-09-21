using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateBannerMerging.Helpers
{
    internal class ModBannersData
    {
        public string ModName { get; set; }

        public string[] Banners { get; set; }

        public string[] Trophies { get; set; }

        public Dictionary<string, string> UniqueBanners { get; set; }

        public Dictionary<string, string> UniqueTrophies { get; set; }

        public Dictionary<string, string> Normalizer { get; set; }

        public string[] Bosses { get; set; }

        public Dictionary<string, string> Projectiles { get; set; }

        public Dictionary<string, string> ModIngredients { get; set; }

        public Dictionary<string, string> MergedIngredients { get; set; }
    }
}
