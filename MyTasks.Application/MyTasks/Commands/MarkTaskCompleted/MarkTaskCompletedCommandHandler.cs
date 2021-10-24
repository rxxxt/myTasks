using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyTasks.Application.Interfaces;
using MyTasks.Application.Common.Exceptions;
using Task = MyTasks.Domain.Task;

namespace MyTasks.Application.MyTasks.Commands.MarkTaskCompleted
{
    public class MarkTaskCompletedCommandHandler
        : IRequestHandler<MarkTaskCompletedCommand>
    {
        private readonly IMyTasksDbContext _dbContext;

        public MarkTaskCompletedCommandHandler(IMyTasksDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(MarkTaskCompletedCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.MyTasks.FirstOrDefaultAsync(task =>
                    task.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Task), request.Id);
            }
            
            entity.IsDone = true;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}