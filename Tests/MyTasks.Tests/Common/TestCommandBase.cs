using System;
using MyTasks.Persistence;

namespace MyTasks.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly MyTasksDbContext Context;

        public TestCommandBase()
        {
            Context = MyTasksContextFactory.Create();
        }

        public void Dispose()
        {
            MyTasksContextFactory.Destroy(Context);
        }
    }
}