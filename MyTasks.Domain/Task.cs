using System;

namespace MyTasks.Domain
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime CompletionDate { get; set; }
        public bool IsDone { get; set; }
    }
}