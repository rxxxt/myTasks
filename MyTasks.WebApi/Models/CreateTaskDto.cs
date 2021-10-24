using System;
using AutoMapper;
using MyTasks.Application.Common.Mappings;
using MyTasks.Application.MyTasks.Commands.CreateTask;
using System.ComponentModel.DataAnnotations;
using MyTasks.Domain;

namespace MyTasks.WebApi.Models
{
    public class CreateTaskDto : IMapWith<CreateTaskCommand>
    {
        [Required]
        public TaskType TaskType { get; set; }
        public string Description { get; set; }
        public DateTime DateDue { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTaskDto, CreateTaskCommand>()
                .ForMember(taskCommand => taskCommand.TaskType,
                    opt => opt.MapFrom(taskDto => taskDto.TaskType))
                .ForMember(taskCommand => taskCommand.Description,
                    opt => opt.MapFrom(taskDto => taskDto.Description))
                .ForMember(taskCommand => taskCommand.DateDue,
                    opt => opt.MapFrom(taskDto => taskDto.DateDue));
        }
    }
}