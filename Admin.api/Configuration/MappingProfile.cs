using Admin.DTO.Masters.Cargo;
using Admin.Entities.Modelos;
using Admin.Repositories.Repositories;
using AutoMapper;

namespace Admin.api.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cargo, CargoDTO>().ReverseMap();
            CreateMap<Cargo, CreateCargoDTO>().ReverseMap();
        }
    }
}
