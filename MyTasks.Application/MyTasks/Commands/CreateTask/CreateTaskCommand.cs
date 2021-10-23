﻿using System;
using MediatR;

namespace MyTasks.Application.MyTasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }
    }
}