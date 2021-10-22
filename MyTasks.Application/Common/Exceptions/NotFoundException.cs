using System;

namespace MyTasks.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string id, object key)
            : base($"Entity \"{id}\" ({key}) not found.") { }
    }
}