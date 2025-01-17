﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MyTasks.Application.Interfaces;

namespace MyTasks.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<MyTasksDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IMyTasksDbContext>(provider =>
                provider.GetService<MyTasksDbContext>());
            return services;
        }
    }
}