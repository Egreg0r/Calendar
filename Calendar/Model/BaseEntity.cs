using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Model
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
