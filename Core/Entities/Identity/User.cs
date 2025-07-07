using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {

        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public Doctor Doctor { get; set; }
        public Guid? DoctorId { get; set; }
        public Patient Patient { get; set; }
        public Guid? PatientId { get; set; }
        public Admin Admin { get; set; }
        public Guid? AdminId { get; set; }
        public ICollection<UserRole> Roles { get; set; }

    }
}
