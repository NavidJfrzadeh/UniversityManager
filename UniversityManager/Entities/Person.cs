using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManager.Entities
{
    public class Person:BaseEntity
    {
        public Guid id { get; set; }
        public bool isDeleted { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public Role Role { get; set; }

        public Person()
        {
            id = Guid.NewGuid();
        }
    }
}
