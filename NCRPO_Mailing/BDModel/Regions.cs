using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NCRPO_Mailing
{
    public partial class Regions
    {
        public Regions()
        {
            Organizations = new HashSet<Organizations>();
        }

        public int RegionId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Organizations> Organizations { get; set; }
    }
}
