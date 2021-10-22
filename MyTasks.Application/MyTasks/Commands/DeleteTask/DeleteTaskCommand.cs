using System;
using MediatR;

namespace MyTasks.Application.MyTasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}