using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PolicyHolderDTO
    {
        public int Id { get; set; }
        public string? Idnumber { get; set; }
        public string? Initials { get; set; }
        public string? Surname { get; set; }
        public string? DateOfBirth { get; set; }
        public int? GenderId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }

        public GenderDTO? Gender { get; set; }
        public  List<PolicyDTO> Policies { get; set; } = new List<PolicyDTO>();
    }
}
