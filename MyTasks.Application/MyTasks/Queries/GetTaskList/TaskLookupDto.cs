using AutoMapper;
using System;
using MyTasks.Application.Common.Mappings;
using MyTasks.Domain;

namespace MyTasks.Application.MyTasks.Queries.GetTaskList
{
    public class TaskLookupDto : IMapWith<Task>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Task, TaskLookupDto>()
                .ForMember(taskDto => taskDto.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(taskDto => taskDto.Description,
                    opt => opt.MapFrom(task => task.Description));
        }
    }
}