using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Enums
{
    public enum CargoRequestType
    {
        [Display(Name = "خرید")]
        Normal = 1,

        [Display(Name = "فروش")]
        System = 2,

        [Display(Name = "جابجایی")]
        Edit = 3,
    }
}
