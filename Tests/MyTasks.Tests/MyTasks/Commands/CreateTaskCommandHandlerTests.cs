using System;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using MyTasks.Application.MyTasks.Commands.CreateTask;
using MyTasks.Domain;
using MyTasks.Tests.Common;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace MyTasks.Tests.MyTasks.Commands
{
    public class CreateTaskCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateTaskCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateTaskCommandHandler(Context);
            var taskDescription = "task description";
            var taskType = TaskType.Personal;

            // Act
            var taskId = await handler.Handle(
                new CreateTaskCommand
                {
                    Description = taskDescription,
                    TaskType = taskType,
                    DateDue = DateTime.Today
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.MyTasks.SingleOrDefaultAsync(task =>
                    task.Id == taskId && task.Description == taskDescription &&
                    task.TaskType == taskType));
        }
    }
}