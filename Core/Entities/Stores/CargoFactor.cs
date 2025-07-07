using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Stores
{
    public class CargoFactor:BaseModel
    {
        public Cargo Cargo { get; set; }
        public string CargoId { get; set; }
        public Factor Factor { get; set; }
        public string FactorId { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    }
}
