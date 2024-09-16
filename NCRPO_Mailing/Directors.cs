using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NCRPO_Mailing
{
    public partial class Directors
    {
        public Directors()
        {
            Organizations = new HashSet<Organizations>();
        }

        public int DirectorId { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Organizations> Organizations { get; set; }
    }
}
