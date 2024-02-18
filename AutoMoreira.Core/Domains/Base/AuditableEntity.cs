namespace AutoMoreira.Core.Domains.Base
{
    public class AuditableEntity : EntityBase
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
