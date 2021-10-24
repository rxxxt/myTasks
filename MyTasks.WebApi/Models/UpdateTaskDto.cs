using AutoMapper;
using System;
using MyTasks.Application.Common.Mappings;
using MyTasks.Application.MyTasks.Commands.UpdateTask;

namespace MyTasks.WebApi.Models
{
    public class UpdateTaskDto : IMapWith<UpdateTaskCommand>
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime DateDue { get; set; }
        public bool IsDone { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTaskDto, UpdateTaskCommand>()
                .ForMember(taskCommand => taskCommand.Id,
                    opt => opt.MapFrom(taskDto => taskDto.Id))
                .ForMember(taskCommand => taskCommand.Type,
                    opt => opt.MapFrom(taskDto => taskDto.Type))
                .ForMember(taskCommand => taskCommand.Description,
                    opt => opt.MapFrom(taskDto => taskDto.Description))
                .ForMember(taskCommand => taskCommand.DateDue,
                    opt => opt.MapFrom(taskDto => taskDto.DateDue))
                .ForMember(taskCommand => taskCommand.IsDone,
                    opt => opt.MapFrom(taskDto => taskDto.IsDone));
        }
    }
}