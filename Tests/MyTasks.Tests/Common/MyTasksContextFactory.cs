using System;
using Microsoft.EntityFrameworkCore;
using MyTasks.Domain;
using MyTasks.Persistence;

namespace MyTasks.Tests.Common
{
    public class MyTasksContextFactory
    {
        public static Guid TaskIdForDelete = Guid.NewGuid();
        public static Guid TaskIdForUpdate = Guid.NewGuid();

        public static MyTasksDbContext Create()
        {
            var options = new DbContextOptionsBuilder<MyTasksDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new MyTasksDbContext(options);
            context.Database.EnsureCreated();
            context.MyTasks.AddRange(
                new Task
                {
                    Id = Guid.Parse("A6BB65BB-5AC2-4AFA-8A28-2616F675B825"),
                    TaskType = TaskType.Personal,
                    Description = "Description1",
                    DateDue = DateTime.Today,
                    IsDone = false
                },
                new Task
                {
                    Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084"),
                    TaskType = TaskType.Work,
                    Description = "Description2",
                    DateDue = DateTime.Today,
                    IsDone = false
                },
                new Task
                {
                    Id = TaskIdForDelete,
                    TaskType = TaskType.Personal,
                    Description = "Description3",
                    DateDue = DateTime.Today,
                    IsDone = false
                },
                new Task
                {
                    Id = TaskIdForUpdate,
                    TaskType = TaskType.Work,
                    Description = "Description4",
                    DateDue = DateTime.Today,
                    IsDone = false
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(MyTasksDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}