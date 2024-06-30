using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NCRPO_Mailing
{
    public partial class Organizations
    {
        public int OrganizationId { get; set; }
        public string Address { get; set; }
        public int? DirectorId { get; set; }
        public string Email { get; set; }
        public string Inn { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int? RegionId { get; set; }
        public string ShortName { get; set; }
        public int? TypeId { get; set; }
        public string Website { get; set; }

        public virtual Directors Director { get; set; }
        public virtual Regions Region { get; set; }
        public virtual Types Type { get; set; }
    }
}
