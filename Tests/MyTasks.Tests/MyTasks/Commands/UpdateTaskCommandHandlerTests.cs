using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyTasks.Application.Common.Exceptions;
using MyTasks.Application.MyTasks.Commands.UpdateTask;
using MyTasks.Tests.Common;
using Xunit;

namespace MyTasks.Tests.MyTasks.Commands
{
    public class UpdateTaskCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateTaskCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateTaskCommandHandler(Context);
            var updatedDescription = "new description";

            // Act
            await handler.Handle(new UpdateTaskCommand
            {
                Id = MyTasksContextFactory.TaskIdForUpdate,
                Description = updatedDescription
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.MyTasks.SingleOrDefaultAsync(task =>
                task.Id == MyTasksContextFactory.TaskIdForUpdate &&
                task.Description == updatedDescription));
        }

        [Fact]
        public async Task UpdateTaskCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateTaskCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateTaskCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}