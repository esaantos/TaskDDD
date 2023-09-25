using APIDailyTasks.Domain.Entities;
using AutoMapper;
using DailyTask.Application.Dtos;

namespace DailyTask.Application.Mapping
{
    public class TarefaProfile: Profile
    {
        public TarefaProfile()
        {
            CreateMap<CreateTarefaDto, Tarefa>();
            CreateMap<UpdateTarefaDto, Tarefa>();
            CreateMap<Tarefa, UpdateTarefaDto>();
            CreateMap<Tarefa, ReadTarefaDto>();
            CreateMap<Tarefa, CreateTarefaDto>();
        }
    }
}
