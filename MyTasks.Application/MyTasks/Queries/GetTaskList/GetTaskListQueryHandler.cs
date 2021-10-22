using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyTasks.Application.Interfaces;

namespace MyTasks.Application.MyTasks.Queries.GetTaskList
{
    public class GetTaskListQueryHandler
        : IRequestHandler<GetTaskListQuery, TaskListVm>
    {
        private readonly IMyTasksDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(IMyTasksDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TaskListVm> Handle(GetTaskListQuery request,
            CancellationToken cancellationToken)
        {
            var myTasksQuery = await _dbContext.MyTasks
                .ProjectTo<TaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TaskListVm { MyTasks = myTasksQuery };
        }
    }
}