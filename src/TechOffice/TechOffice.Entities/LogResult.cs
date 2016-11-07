using System;

namespace TechOffice.Entities
{
    public class LogResult
    {
        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}