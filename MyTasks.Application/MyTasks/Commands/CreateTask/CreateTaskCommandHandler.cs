using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyTasks.Application.Interfaces;
using Task = MyTasks.Domain.Task;

namespace MyTasks.Application.MyTasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler
        :IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly IMyTasksDbContext _dbContext;

        public CreateTaskCommandHandler(IMyTasksDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateTaskCommand request,
            CancellationToken cancellationToken)
        {
            var task = new Task
            {
                Id = Guid.NewGuid(),
                Type = request.Type,
                Description = request.Description,
                DateDue = request.DateDue,
                IsDone = false
            };

            await _dbContext.MyTasks.AddAsync(task, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return task.Id;
        }
    }
}