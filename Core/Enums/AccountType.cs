using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Enums
{
    public enum AccountType
    {
        [Display(Name = "بدهکار")]
        Debit = 1,

        [Display(Name = "بستانکار")]
        Credit = 2,
    }
}
