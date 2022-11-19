using AutoMapper;
using PaparaProject.Domain.Entities;
using PaparaProject.Services.DTOs;

namespace PaparaProject.Services.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Worker, WorkerDto>().ReverseMap();
        }
    }
}
