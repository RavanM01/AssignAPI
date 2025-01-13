using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Core.Entities.Common;

namespace TaskVeren.Core.Entities
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
