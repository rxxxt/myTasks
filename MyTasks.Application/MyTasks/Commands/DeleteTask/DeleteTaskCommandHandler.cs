using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyTasks.Application.Interfaces;
using MyTasks.Application.Common.Exceptions;
using Task = MyTasks.Domain.Task;

namespace MyTasks.Application.MyTasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler
        : IRequestHandler<DeleteTaskCommand>
    {
        private readonly IMyTasksDbContext _dbContext;

        public DeleteTaskCommandHandler(IMyTasksDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteTaskCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.MyTasks
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Task), request.Id);
            }

            _dbContext.MyTasks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}