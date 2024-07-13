
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
            
            CreateMap<Arl, ArlDTO>();
            CreateMap<Arl, CreateArlDTO>();
            CreateMap<Cargo, CargoDTO>();
            CreateMap<Cargo, CreateCargoDTO>();
            CreateMap<Ceco,CecoDTO >();
            CreateMap<Ceco, CreateCecoDTO>();
            CreateMap<Empleado,EmpleadosDTO>();
            CreateMap<Empleado,CreateEmpleadoDTO>();
            CreateMap<Ep,EpDTO>();
            CreateMap<Ep,CreateEpDTO>();
            CreateMap<FondosPensione,FondosPensionDTO>();
            CreateMap<FondosPensione,CreateFondosPension>();
            CreateMap<Servicio,ServiciosDTO>();
            CreateMap<Servicio,CreateServicioDTO>();
            CreateMap<TiposContrato,TiposContratoDTO>();
            CreateMap<TiposContrato,CreateTiposContratoDTO>();
        }
    }
}
