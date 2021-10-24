using System;
using FluentValidation;
using MyTasks.Domain;

namespace MyTasks.Application.MyTasks.Commands.UpdateTask
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(updateTaskCommand => updateTaskCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateTaskCommand =>
                updateTaskCommand.TaskType).Must(type => Enum.IsDefined(typeof(TaskType), type));
            RuleFor(updateTaskCommand =>
                updateTaskCommand.Description).NotEmpty().MaximumLength(100);
            RuleFor(updateTaskCommand => updateTaskCommand.DateDue)
                .NotEmpty().Must(dateDue => dateDue > DateTime.Now);
        }
    }
}