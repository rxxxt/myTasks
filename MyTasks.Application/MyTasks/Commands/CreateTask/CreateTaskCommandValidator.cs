using System;
using FluentValidation;

namespace MyTasks.Application.MyTasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(createTaskCommand =>
                createTaskCommand.Type).NotEmpty().MaximumLength(25);
            RuleFor(createTaskCommand =>
                createTaskCommand.Description).NotEmpty().MaximumLength(100);
            RuleFor(updateTaskCommand => updateTaskCommand.CompletionDate)
               .NotEmpty().Must(completionDate => completionDate > DateTime.Now);
        }
    }
}