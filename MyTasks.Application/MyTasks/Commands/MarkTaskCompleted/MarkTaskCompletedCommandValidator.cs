using System;
using FluentValidation;

namespace MyTasks.Application.MyTasks.Commands.MarkTaskCompleted
{
    public class MarkTaskCompletedCommandValidator : AbstractValidator<MarkTaskCompletedCommand>
    {
        public MarkTaskCompletedCommandValidator()
        {
            RuleFor(markTaskCompletedCommand => markTaskCompletedCommand.Id).NotEqual(Guid.Empty);
        }
    }
}