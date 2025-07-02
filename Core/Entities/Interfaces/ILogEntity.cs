using System;
using System.ComponentModel.DataAnnotations;

namespace Acc.Core.Entities.Interfaces
{
    //public interface ICreateLogEntity
    //{
        
    //    [Display(Name = "تاریخ تولید کننده")]
    //    public DateTime CreateDateTime { get; set; }
        
    //    [Display(Name = "شناسه کاربر تولید کننده")]
    //    public int CreatorUserId { get; set; }
        
    //    [Display(Name = "کاربر تولید کننده")]
    //    public User CreatorUser { get; set; }

    //}

    //public interface IModifyLogEntity
    //{
        
    //    [Display(Name = "آخرین تاریخ تغییر داده شده")]
    //    public DateTime? ModifiedDateTime { get; set; }
        
    //    [Display(Name = "شناسه آخرین کاربر تغییر دهنده")]
    //    public int? ModifierUserId { get; set; }
        
    //    [Display(Name = "آخرین کاربر تغییر دهنده")]
    //    public User ModifierUser { get; set; }
    //}

    //public interface ILogEntity : ICreateLogEntity, IModifyLogEntity
    //{
    //}

    public interface ISoftEntity
    {
        [Display(Name = "حذف شده")]
        public bool? IsDeleted { get; set; }
    }
}
