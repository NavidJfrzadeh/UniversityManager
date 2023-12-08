using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManager.Entities
{
    public class Course : BaseEntity
    {
        public Course()
        {
            id = Guid.NewGuid();
        }
        public bool IsDeleted { get; set; } = false;
    }
}
