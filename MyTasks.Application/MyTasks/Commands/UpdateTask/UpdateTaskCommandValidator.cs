using System;
using FluentValidation;

namespace MyTasks.Application.MyTasks.Commands.UpdateTask
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(updateTaskCommand => updateTaskCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createTaskCommand =>
                createTaskCommand.Type).NotEmpty().MaximumLength(25);
            RuleFor(createTaskCommand =>
                createTaskCommand.Description).NotEmpty().MaximumLength(100);
            RuleFor(updateTaskCommand => updateTaskCommand.DateDue)
                .NotEmpty().Must(dateDue => dateDue > DateTime.Now);
        }
    }
}