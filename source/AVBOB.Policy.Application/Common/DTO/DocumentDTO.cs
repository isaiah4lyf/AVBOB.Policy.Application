using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DocumentDTO
    {
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

        public DocumentTypeDTO? DocumentType { get; set; }
    }
}
