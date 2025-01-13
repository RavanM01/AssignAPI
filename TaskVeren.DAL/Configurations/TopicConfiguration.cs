using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Core.Entities;

namespace TaskVeren.DAL.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.Property(x => x.Name).IsRequired();


            builder.HasMany(x => x.Assignments)
                .WithOne(x => x.Topic)
                .HasForeignKey(x => x.TopicId);


        }
    }
}
