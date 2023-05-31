

using System;

namespace School.Domain.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            this.CreateDate = DateTime.Now;
            this.Deleted = false;
        }
        public DateTime CreateDate { get; set; }
        public int CreationUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? UserMod { get; set; }

        public int? UserDeleted { get; set; }

        public DateTime? DeletedDate { get; set; }

        public bool Deleted { get; set; }
    }
}
