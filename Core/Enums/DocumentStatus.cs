using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum DocumentStatus
    {
        [Display(Name = "ثبت موقت")]
        Normal = 1,

        [Display(Name = "تایید شده")]
        System = 2,

        [Display(Name = "ابطال شده")]
        Edit = 3,

        
    }
}
