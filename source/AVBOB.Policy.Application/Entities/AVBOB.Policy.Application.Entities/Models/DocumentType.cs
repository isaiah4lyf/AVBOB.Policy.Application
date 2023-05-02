using System;
using System.Collections.Generic;

namespace AVBOB.Application.Entities.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Documents = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int IOrder { get; set; }
        public Guid Guid { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
