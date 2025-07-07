using Core.Entities.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Persons
{
    public class Person:BaseModel
    {
        public string Name { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public int PersonType { get; set; } // شخص-شرکت-فروشگاه-کارخانه
        public string NationalCode { get; set; }
        public virtual ICollection<Factor> Factors { get; set; }
    }
}
