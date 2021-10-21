namespace MyTasks.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(MyTasksDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}