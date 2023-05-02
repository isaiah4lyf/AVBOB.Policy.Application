using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DocumentTypeDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int IOrder { get; set; }
        public Guid Guid { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
