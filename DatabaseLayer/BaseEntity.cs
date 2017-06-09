using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseLayer
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
