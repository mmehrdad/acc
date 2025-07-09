using Acc.Core.Entities.Identity;
using Acc.Core.Entities.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities.Stores
{
    public class Store:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StoreNo { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public ICollection<Person> Emploees { get; set; }
        public virtual ICollection<CargoStore> CargoStores { get; set; }
        public virtual ICollection<CargoLocation> CargoLocations { get; set; }
    }
}
