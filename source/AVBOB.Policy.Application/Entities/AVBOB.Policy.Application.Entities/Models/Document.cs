using System;
using System.Collections.Generic;

namespace AVBOB.Application.Entities.Models
{
    public partial class Document
    {
        public Document()
        {
            Policies = new HashSet<Policy>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int? DocumentTypeId { get; set; }
        public string Title { get; set; } = null!;
        public string? OriginalTitle { get; set; }
        public string? Name { get; set; }
        public string? Extension { get; set; }
        public string? Size { get; set; }
        public DateTime? DateModified { get; set; }
        public string Url { get; set; } = null!;
        public int IOrder { get; set; }
        public Guid Guid { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual DocumentType? DocumentType { get; set; }
        public virtual ICollection<Policy> Policies { get; set; }
    }
}
