using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Task = MyTasks.Domain.Task;

namespace MyTasks.Application.Interfaces
{
    public interface IMyTasksDbContext
    {
        DbSet<Task> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}