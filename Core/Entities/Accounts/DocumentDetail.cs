using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Accounts
{
    public class DocumentDetail:BaseModel
    {
        public Document Document { get; set; }
        public string DocumentId { get; set; }
    }
}
