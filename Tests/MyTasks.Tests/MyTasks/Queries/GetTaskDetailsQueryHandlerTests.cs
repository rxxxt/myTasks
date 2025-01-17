﻿using AutoMapper;
using System;
using System.Threading;
using MyTasks.Application.MyTasks.Queries.GetTaskDetails;
using MyTasks.Domain;
using MyTasks.Persistence;
using MyTasks.Tests.Common;
using Shouldly;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace MyTasks.Tests.MyTasks.Queries
{
    [Collection("QueryCollection")]
    public class GetTaskDetailsQueryHandlerTests
    {
        private readonly MyTasksDbContext Context;
        private readonly IMapper Mapper;

        public GetTaskDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTaskDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetTaskDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetTaskDetailsQuery
                {
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<TaskDetailsVm>();
            result.Description.ShouldBe("Description2");
            result.Type.ShouldBe(TaskType.Work.ToString());
            result.DateDue.ShouldBe(DateTime.Today);
            result.IsDone.ShouldBe(false);
        }
    }
}