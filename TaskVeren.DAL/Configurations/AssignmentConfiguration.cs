using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Core.Entities;

namespace TaskVeren.DAL.Configurations
{
    public class AssignmentConfiguration: IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Description).IsRequired();



            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.Assignments)
                .HasForeignKey(x => x.AppUserId);

            builder.HasOne(x=>x.Tag)
                .WithMany(x => x.Assignments)
                .HasForeignKey(x=>x.TagId);


            builder.HasOne(x => x.Tag)
                .WithMany(x => x.Assignments)
                .HasForeignKey(x => x.TagId);



        }
    }
}
