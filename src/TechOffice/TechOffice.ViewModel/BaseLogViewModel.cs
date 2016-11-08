using System;

namespace AnThinhPhat.ViewModel
{
    public class BaseLogViewModel
    {
        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}