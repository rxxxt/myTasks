using System;
using MediatR;

namespace MyTasks.Application.MyTasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQuery : IRequest<TaskDetailsVm>
    {
        public Guid Id { get; set; }
    }
}