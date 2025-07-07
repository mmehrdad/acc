using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Stores
{
    public class Store:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StoreNo { get; set; }
        public virtual ICollection<CargoStore> CargoStores { get; set; }
    }
}
