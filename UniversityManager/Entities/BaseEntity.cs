using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManager.Entities
{
    public class BaseEntity
    {
        public Guid id { get; set; }
        public string name { get; set; }
    }
}
