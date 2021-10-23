using System;
using FluentValidation;
using MyTasks.Application.MyTasks.Queries.GetTaskDetails;

namespace MyTasks.Application.MyTasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryValidator : AbstractValidator<GetTaskDetailsQuery>
    {
        public GetTaskDetailsQueryValidator()
        {
            RuleFor(task => task.Id).NotEqual(Guid.Empty);
        }
    }
}