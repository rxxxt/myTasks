using Microsoft.EntityFrameworkCore;
using MyTasks.Application.Interfaces;
using MyTasks.Domain;
using MyTasks.Persistence.EntityTypeConfigurations;

namespace MyTasks.Persistence
{
    public class MyTasksDbContext: DbContext, IMyTasksDbContext
    {
        public DbSet<Task> MyTasks { get; set; }

        public MyTasksDbContext(DbContextOptions<MyTasksDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TaskConfiguration());
            base.OnModelCreating(builder);
        }
    }
}