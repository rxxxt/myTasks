using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MyTasks.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyTasks.Application.Common.Exceptions;
using Task = MyTasks.Domain.Task;

namespace MyTasks.Application.MyTasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryHandler
        : IRequestHandler<GetTaskDetailsQuery, TaskDetailsVm>
    {
        private readonly IMyTasksDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskDetailsQueryHandler(IMyTasksDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TaskDetailsVm> Handle(GetTaskDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.MyTasks
                .FirstOrDefaultAsync(task =>
                    task.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Task), request.Id);
            }

            return _mapper.Map<TaskDetailsVm>(entity);
        }
    }
}