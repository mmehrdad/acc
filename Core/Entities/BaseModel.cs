using Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Core.Entities
{
    public class BaseModel
    {
        public string Id { get; set; } 
        /// <summary>
        /// gets or sets date that this entity was created
        /// </summary>
        public virtual DateTime? CreatedTime { get; set; }
        /// <summary>
        /// gets or sets Date that this entity was updated
        /// </summary>
        public virtual DateTime? ModifiedTime { get; set; }
        /// <summary>
        /// gets or sets IP Address of Creator
        /// </summary>

        public virtual string? CreatorIp { get; set; }
        /// <summary>
        /// gets or set IP Address of Modifier
        /// </summary>

        public virtual string? ModifierIp { get; set; }
        /// <summary>
        /// indicate this entity is Locked for Modify
        /// </summary>
        public virtual bool? ModifyLocked { get; set; }
        /// <summary>
        /// indicate this entity is deleted softly
        /// </summary>
        public virtual bool? IsDeleted { get; set; }

        /// <summary>
        /// gets or sets count of Modification Default is 1
        /// </summary>
        public virtual int? Version { get; set; }

        /// <summary>
        /// gets or sets TimeStamp for prevent concurrency Problems
        /// </summary>
        public virtual byte[]? RowVersion { get; set; }

        public virtual Guid? EntityGuid { get; set; }

        /// <summary>
        /// gets ro sets User that Modify this entity
        /// </summary>

        public virtual string? ModifierId { get; set; }
        public User Modifier { get; set; }

        /// <summary>
        /// gets ro sets User that Create this entity
        /// </summary>

        public virtual string? CreatorId { get; set; }
        public User Creator { get; set; }

        public bool? IsActive { get; set; }

    }
}
