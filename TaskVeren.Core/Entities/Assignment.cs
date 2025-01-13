using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Core.Entities.Common;

namespace TaskVeren.Core.Entities
{
    public class Assignment:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }



        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
