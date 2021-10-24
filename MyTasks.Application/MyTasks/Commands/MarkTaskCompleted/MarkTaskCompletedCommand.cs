using System;
using MediatR;

namespace MyTasks.Application.MyTasks.Commands.MarkTaskCompleted
{
    public class MarkTaskCompletedCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}