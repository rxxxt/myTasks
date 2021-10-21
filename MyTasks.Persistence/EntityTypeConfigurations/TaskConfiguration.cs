using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyTasks.Domain;

namespace MyTasks.Persistence.EntityTypeConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(task => task.Id);
            builder.HasIndex(task => task.Id).IsUnique();
            builder.Property(task => task.Description).HasMaxLength(250);
        }
    }
}