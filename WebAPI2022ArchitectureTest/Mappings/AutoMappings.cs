using AutoMapper;
using WebAPI2022ArchitectureTest.Business.Interfaces;
using WebAPI2022ArchitectureTest.Business.Models;

namespace WebAPI2022ArchitectureTest.Mappings
{
    public class AutoMappings : Profile
    {
        public AutoMappings(IAppHashIdService appHashIdService)
        {
            // Todo ListResult 
            CreateMap<TodoItemDTO, Endpoints.Todo.ListResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => appHashIdService.Encode(src.Id)));

            // Todo GetResult 
            CreateMap<TodoItemDTO, Endpoints.Todo.GetResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => appHashIdService.Encode(src.Id)));
        }
    }
}
