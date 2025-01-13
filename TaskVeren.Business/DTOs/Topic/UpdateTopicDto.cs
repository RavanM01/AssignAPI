using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskVeren.Business.DTOs.Topic
{
    public class UpdateTopicDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
   
}
