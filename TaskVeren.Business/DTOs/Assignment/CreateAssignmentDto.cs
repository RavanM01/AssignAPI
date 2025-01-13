using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskVeren.Business.DTOs.Assignment
{
    public class CreateAssignmentDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
        public int TagId { get; set; }
      
    }
}
