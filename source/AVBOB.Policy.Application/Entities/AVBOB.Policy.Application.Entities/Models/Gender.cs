using System;
using System.Collections.Generic;

namespace AVBOB.Application.Entities.Models
{
    public partial class Gender
    {
        public Gender()
        {
            PolicyHolders = new HashSet<PolicyHolder>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<PolicyHolder> PolicyHolders { get; set; }
    }
}
