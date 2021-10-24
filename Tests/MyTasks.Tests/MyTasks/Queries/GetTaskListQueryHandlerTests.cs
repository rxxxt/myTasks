using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using MyTasks.Application.MyTasks.Queries.GetTaskList;
using MyTasks.Persistence;
using MyTasks.Tests.Common;
using Shouldly;
using Xunit;

namespace MyTasks.Tests.MyTasks.Queries
{
    [Collection("QueryCollection")]
    public class GetTaskListQueryHandlerTests
    {
        private readonly MyTasksDbContext Context;
        private readonly IMapper Mapper;

        public GetTaskListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetTaskListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetTaskListQuery
                {
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<TaskListVm>();
            result.MyTasks.Count.ShouldBe(4);
        }
    }
}