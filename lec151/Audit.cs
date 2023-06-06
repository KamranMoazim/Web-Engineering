using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lec151
{
    public abstract class Audit
    {
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }

        // public bool IsActive { get; set; } = true;
    }
}