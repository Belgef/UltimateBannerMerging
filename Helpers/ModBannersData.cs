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

        public Dictionary<string, string> UniqueBanners { get; set; }

        public Dictionary<string, string> Multiparts { get; set; }
    }
}
