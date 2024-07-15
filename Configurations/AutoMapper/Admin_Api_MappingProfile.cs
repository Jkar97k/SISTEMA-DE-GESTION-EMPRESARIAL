
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
            
            CreateMap<Arl, GenericDTO>();
            CreateMap<Arl, CreateGenericDTO>();
            CreateMap<Cargo, GenericDTO>();
            CreateMap<Cargo, CreateGenericDTO>();
            CreateMap<Ceco,GenericDTO >();
            CreateMap<Ceco, CreateGenericDTO>();
            CreateMap<Empleado,EmpleadosDTO>();
            CreateMap<Empleado,CreateEmpleadoDTO>();
            CreateMap<Ep,GenericDTO>();
            CreateMap<Ep,CreateGenericDTO>();
            CreateMap<FondosPensione,GenericDTO>();
            CreateMap<FondosPensione,CreateGenericDTO>();
            CreateMap<Servicio,ServiciosDTO>();
            CreateMap<Servicio,CreateServicioDTO>();
            CreateMap<TiposContrato,GenericDTO>();
            CreateMap<TiposContrato,CreateGenericDTO>();
        }
    }
}
