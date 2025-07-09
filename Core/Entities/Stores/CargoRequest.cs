using Acc.Core.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Stores
{
    public class CargoRequest:BaseModel
    {
        public Person Person { get; set; }
        public string PersonId { get; set; }
        public virtual ICollection<Cargo> Cargos { get; set; }
    }
}
