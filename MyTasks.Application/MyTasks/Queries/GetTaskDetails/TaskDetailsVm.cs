using System;
using AutoMapper;
using MyTasks.Application.Common.Mappings;
using MyTasks.Domain;

namespace MyTasks.Application.MyTasks.Queries.GetTaskDetails
{
    public class TaskDetailsVm : IMapWith<Task>
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime DateDue { get; set; }
        public bool IsDone { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Task, TaskDetailsVm>()
                .ForMember(taskVm => taskVm.Type,
                    opt => opt.MapFrom(task => task.TaskType.ToString()))
                .ForMember(taskVm => taskVm.Description,
                    opt => opt.MapFrom(task => task.Description))
                .ForMember(taskVm => taskVm.DateDue,
                    opt => opt.MapFrom(task => task.DateDue))
                .ForMember(taskVm => taskVm.IsDone,
                    opt => opt.MapFrom(task => task.IsDone));
        }
    }
}