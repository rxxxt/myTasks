using System;
using MediatR;

namespace MyTasks.Application.MyTasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime DateDue  { get; set; }
    }
}