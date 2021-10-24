using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyTasks.Application.Common.Exceptions;
using MyTasks.Application.MyTasks.Commands.DeleteTask;
using MyTasks.Tests.Common;
using Xunit;

namespace MyTasks.Tests.MyTasks.Commands
{
    public class DeleteTaskCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteTaskCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteTaskCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteTaskCommand
            {
                Id = MyTasksContextFactory.TaskIdForDelete,
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.MyTasks.SingleOrDefault(task =>
                task.Id == MyTasksContextFactory.TaskIdForDelete));
        }

        [Fact]
        public async Task DeleteTaskCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteTaskCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteTaskCommand
                    {
                        Id = Guid.NewGuid(),
                    },
                    CancellationToken.None));
        }
    }
}