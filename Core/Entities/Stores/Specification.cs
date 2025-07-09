using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Stores
{
    public class Specification : BaseModel
    {
        public string Title { get; set; }
        public Specification Parent { get; set; }
        public string ParentId { get; set; }
        public virtual ICollection<CargoSpecific> CargoSpecifics { get; set; }
        public virtual ICollection<Specification> Children { get; set; }
    }
}
