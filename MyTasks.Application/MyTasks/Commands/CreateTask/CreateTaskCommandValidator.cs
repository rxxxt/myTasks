using System;
using FluentValidation;

namespace MyTasks.Application.MyTasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(createTaskCommand =>
                createTaskCommand.Description).NotEmpty().MaximumLength(250);
            RuleFor(createTaskCommand =>
                createTaskCommand.Id).NotEqual(Guid.Empty);
        }
    }
}