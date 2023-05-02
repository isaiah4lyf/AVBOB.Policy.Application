namespace DTO
{
    public class PolicyDTO
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

        public DocumentDTO ApplicationFormDocument { get; set; } = new DocumentDTO();
        public PolicyTypeDTO? PolicyType { get; set; }
    }
}