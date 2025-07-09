using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Enums
{
    public enum LocationType
    {
        [Display(Name = "قفسه")]
        Shelf = 1,

        [Display(Name = "پالت")]
        Palet = 2,

        [Display(Name = "فضای باز")]
        Environment = 3,
    }
}
