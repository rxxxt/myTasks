using System;
using FluentValidation;

namespace MyTasks.Application.MyTasks.Commands.UpdateTask
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(updateTaskCommand => updateTaskCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateTaskCommand => updateTaskCommand.Description)
                .NotEmpty().MaximumLength(250);
            RuleFor(updateTaskCommand => updateTaskCommand.Type)
                .NotEmpty().MaximumLength(25);
            RuleFor(updateTaskCommand => updateTaskCommand.CompletionDate)
                .NotEmpty().Must(completionDate => completionDate > DateTime.Now); //TODO: Проверить на корректность =
        }
    }
}