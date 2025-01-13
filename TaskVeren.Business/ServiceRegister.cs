using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskVeren.Business.Services.Implementations;
using TaskVeren.Business.Services.Interfaces;

namespace TaskVeren.Business
{
    public static class ServiceRegister
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegister));
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
