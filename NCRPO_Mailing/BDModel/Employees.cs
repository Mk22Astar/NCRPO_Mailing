using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NCRPO_Mailing.Models
{
    public partial class Employees
    {
        public int EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public int? PositionId { get; set; }
        public string Surname { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Positions Position { get; set; }
    }
}
