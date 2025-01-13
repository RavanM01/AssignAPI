using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.DAL.Repositories.Implementations;
using TaskVeren.DAL.Repositories.Interfaces;

namespace TaskVeren.DAL
{
    public static class DALServiceRegister
    {
        public static void AddDALServices(this IServiceCollection services)
        {
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IAssingmentRepository, AssignmentRepository>();
        }
    }
}
