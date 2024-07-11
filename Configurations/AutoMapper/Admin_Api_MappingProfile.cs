
using Admin.DTO;
using Admin.Entities.Modelos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurations.AutoMapper
{
    public class Admin_Api_MappingProfile : Profile
    {
        public Admin_Api_MappingProfile()
        {
            CreateMap<Cargo, CargoDTO>();
            CreateMap<Cargo, CreateCargoDTO>();
        }
    }
}
