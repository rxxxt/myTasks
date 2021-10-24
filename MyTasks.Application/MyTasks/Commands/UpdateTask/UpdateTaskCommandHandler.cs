using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyTasks.Application.Interfaces;
using MyTasks.Application.Common.Exceptions;
using Task = MyTasks.Domain.Task;

namespace MyTasks.Application.MyTasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler
        : IRequestHandler<UpdateTaskCommand>
    {
        private readonly IMyTasksDbContext _dbContext;

        public UpdateTaskCommandHandler(IMyTasksDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateTaskCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.MyTasks.FirstOrDefaultAsync(task =>
                    task.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Task), request.Id);
            }

            entity.Description = request.Description;
            entity.Type = request.Type;
            entity.CompletionDate = request.CompletionDate;
            entity.IsDone = request.IsDone;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}