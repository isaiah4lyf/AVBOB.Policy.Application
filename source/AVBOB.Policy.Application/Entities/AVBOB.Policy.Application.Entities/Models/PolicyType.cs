using System;
using System.Collections.Generic;

namespace AVBOB.Application.Entities.Models
{
    public partial class PolicyType
    {
        public PolicyType()
        {
            Policies = new HashSet<Policy>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
