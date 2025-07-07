using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Stores
{
    public class CargoSpecific:BaseModel
    {
        public CargoSpecific Parent { get; set; }
        public string ParentId { get; set; }

        public virtual Cargo Cargo { get; set; }
        public string CargoId { get; set; }

        public virtual Specification Specification { get; set; }
        public string SpecificationId { get; set; }

        public virtual ICollection<CargoSpecific> Children { get; set; }
        
       
    }
}
