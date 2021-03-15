using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public class EntityBaseModel
    {
        public long Id { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsDeleted { get; set; }

        public EntityBaseModel()
        {
            CreationTime = DateTime.Now;
            IsDeleted = false;
        } 
    }
}
