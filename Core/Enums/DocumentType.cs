using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum DocumentType
    {
        [Display(Name = "عادی")]
        Normal = 1,

        [Display(Name = "سیستماتیک")]
        System = 2,

        [Display(Name = "اصلاحی")]
        Edit = 3,

        [Display(Name = "حواله")]
        Havaleh = 4,

        [Display(Name = "دریافت")]
        Recieve = 5,
    }
}
