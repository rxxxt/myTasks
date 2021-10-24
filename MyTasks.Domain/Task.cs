using System;

namespace MyTasks.Domain
{
    public class Task
    {
        public Guid Id { get; set; }
        public TaskType TaskType { get; set; }
        public string Description { get; set; }
        public DateTime DateDue  { get; set; }
        public bool IsDone { get; set; }
    }
}