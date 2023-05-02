using System;
using System.Collections.Generic;

namespace AVBOB.Application.Entities.Models
{
    public partial class PolicyHolder
    {
        public PolicyHolder()
        {
            Policies = new HashSet<Policy>();
        }

        public int Id { get; set; }
        public string? Idnumber { get; set; }
        public string? Initials { get; set; }
        public string? Surname { get; set; }
        public string? DateOfBirth { get; set; }
        public int? GenderId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Gender? Gender { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
    }
}
