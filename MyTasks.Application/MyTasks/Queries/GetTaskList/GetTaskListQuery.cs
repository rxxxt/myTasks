using System;
using MediatR;

namespace MyTasks.Application.MyTasks.Queries.GetTaskList
{
    public class GetTaskListQuery : IRequest<TaskListVm>
    {
    }
}