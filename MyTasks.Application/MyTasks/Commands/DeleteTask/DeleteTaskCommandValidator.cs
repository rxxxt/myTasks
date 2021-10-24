using System;
using FluentValidation;

namespace MyTasks.Application.MyTasks.Commands.DeleteTask
{
    public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
    {
        public DeleteTaskCommandValidator()
        {
            RuleFor(deleteTaskCommand => deleteTaskCommand.Id).NotEqual(Guid.Empty);
        }
    }
}