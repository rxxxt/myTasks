using System.Collections.Generic;

namespace MyTasks.Application.MyTasks.Queries.GetTaskList
{
    public class TaskListVm
    {
        public IList<TaskLookupDto> MyTasks { get; set; }
    }
}