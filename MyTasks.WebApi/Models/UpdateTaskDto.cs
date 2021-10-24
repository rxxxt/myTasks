using AutoMapper;
using System;
using MyTasks.Application.Common.Mappings;
using MyTasks.Application.MyTasks.Commands.UpdateTask;
using MyTasks.Domain;

namespace MyTasks.WebApi.Models
{
    public class UpdateTaskDto : IMapWith<UpdateTaskCommand>
    {
        public Guid Id { get; set; }
        public TaskType TaskType { get; set; }
        public string Description { get; set; }
        public DateTime DateDue { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTaskDto, UpdateTaskCommand>()
                .ForMember(taskCommand => taskCommand.Id,
                    opt => opt.MapFrom(taskDto => taskDto.Id))
                .ForMember(taskCommand => taskCommand.TaskType,
                    opt => opt.MapFrom(taskDto => taskDto.TaskType))
                .ForMember(taskCommand => taskCommand.Description,
                    opt => opt.MapFrom(taskDto => taskDto.Description))
                .ForMember(taskCommand => taskCommand.DateDue,
                    opt => opt.MapFrom(taskDto => taskDto.DateDue));
        }
    }
}