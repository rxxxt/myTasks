using System;
using MediatR;
using MyTasks.Domain;

namespace MyTasks.Application.MyTasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest
    {
        public Guid Id { get; set; }
        public TaskType TaskType { get; set; }
        public string Description { get; set; }
        public DateTime DateDue { get; set; }
    }
}