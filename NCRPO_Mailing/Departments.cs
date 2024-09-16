using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NCRPO_Mailing
{
    public partial class Departments
    {
        public Departments()
        {
            Emails = new HashSet<Emails>();
            Employees = new HashSet<Employees>();
            Signatures = new HashSet<Signatures>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Emails> Emails { get; set; }
        public virtual ICollection<Employees> Employees { get; set; }
        public virtual ICollection<Signatures> Signatures { get; set; }
    }
}
