using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskVeren.Business.DTOs.Assignment
{
    public class GetAssignmentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
        public int TagId { get; set; }
        public string AppUserId { get; set; }
    }
}
