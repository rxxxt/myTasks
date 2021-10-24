using System;
using MediatR;
using MyTasks.Domain;

namespace MyTasks.Application.MyTasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public TaskType TaskType { get; set; }
        public string Description { get; set; }
        public DateTime DateDue  { get; set; }
    }
}