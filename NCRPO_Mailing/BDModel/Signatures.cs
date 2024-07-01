﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NCRPO_Mailing.Models
{
    public partial class Signatures
    {
        public int SignatureId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }

        public virtual Departments Department { get; set; }
    }
}
