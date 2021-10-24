using System;
using FluentValidation;
using MyTasks.Domain;

namespace MyTasks.Application.MyTasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(createTaskCommand =>
                createTaskCommand.TaskType).Must(type => Enum.IsDefined(typeof(TaskType), type));
            RuleFor(createTaskCommand =>
                createTaskCommand.Description).NotEmpty().MaximumLength(100);
            RuleFor(updateTaskCommand => updateTaskCommand.DateDue)
               .NotEmpty().Must(dateDue => dateDue > DateTime.Now);
        }
    }
}