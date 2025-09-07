using Acc.Core.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Stores
{
    public class Factor:BaseModel
    {
        public Person Person { get; set; }
        public string PersonId { get; set; }
        public string FactorNo { get; set; }
        public int FactorType { get; set; }
        public virtual ICollection<CargoFactor> CargoFactors { get; set; }
    }
}
