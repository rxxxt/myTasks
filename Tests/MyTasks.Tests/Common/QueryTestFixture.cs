using AutoMapper;
using System;
using MyTasks.Application.Interfaces;
using MyTasks.Application.Common.Mappings;
using MyTasks.Persistence;
using Xunit;

namespace MyTasks.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public MyTasksDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = MyTasksContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IMyTasksDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            MyTasksContextFactory.Destroy(Context);
        }
    }
    
    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}