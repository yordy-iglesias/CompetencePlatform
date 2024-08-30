namespace CompetencePlatform.Core.Common
{
    public interface IAuditedEntity
    {
        //public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        //public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public bool? Deleted { get; set; }
        public bool? IsSelected { get; set; }
    }
}
