using System;

namespace SmartTraining.Data.Domain
{
    public abstract class AuditedEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
