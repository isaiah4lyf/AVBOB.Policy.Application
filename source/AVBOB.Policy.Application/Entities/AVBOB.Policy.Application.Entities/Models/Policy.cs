using System;
using System.Collections.Generic;

namespace AVBOB.Application.Entities.Models
{
    public partial class Policy
    {
        public int Id { get; set; }
        public string? PolicyNumber { get; set; }
        public int PolicyTypeId { get; set; }
        public int PolicyHolderId { get; set; }
        public DateTime CommencementDate { get; set; }
        public string? Installment { get; set; }
        public int? ApplicationFormDocumentId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual Document? ApplicationFormDocument { get; set; }
        public virtual PolicyHolder PolicyHolder { get; set; } = null!;
        public virtual PolicyType PolicyType { get; set; } = null!;
    }
}
