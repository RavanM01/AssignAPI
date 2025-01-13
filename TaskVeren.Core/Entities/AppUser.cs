using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskVeren.Core.Entities
{
    public class AppUser: IdentityUser
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Assignment> Assignments { get; set; }

    }
}
