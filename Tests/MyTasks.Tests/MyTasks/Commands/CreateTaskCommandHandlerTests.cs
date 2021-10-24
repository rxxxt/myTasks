using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTasks.Application.MyTasks.Commands.CreateTask;
using MyTasks.Tests.Common;
using Xunit;

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
            var taskType = "task type";

            // Act
            var taskId = await handler.Handle(
                new CreateTaskCommand
                {
                    Description = taskDescription,
                    Type = taskType,
                    CompletionDate = DateTime.Today
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.MyTasks.SingleOrDefaultAsync(task =>
                    task.Id == taskId && task.Description == taskDescription &&
                    task.Type == taskType));
        }
    }
}