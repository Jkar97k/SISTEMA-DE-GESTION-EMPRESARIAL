
using Admin.DTO;
using Admin.Entities.Models;
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
            
            CreateMap<Arl, GenericDTO>().ReverseMap();
            CreateMap<Arl, CreateGenericDTO>().ReverseMap();
            CreateMap<Cargo, GenericDTO>().ReverseMap();
            CreateMap<Cargo, CreateGenericDTO>().ReverseMap();
            CreateMap<Ceco,GenericDTO >().ReverseMap();
            CreateMap<Ceco, CreateGenericDTO>().ReverseMap();
            CreateMap<Empleado,EmpleadosDTO>().ReverseMap();
            CreateMap<Empleado,CreateEmpleadoDTO>().ReverseMap();
            CreateMap<ContratosLaborale,ContratosLaboralesDTO>().ReverseMap();
            CreateMap<ContratosLaborale,CreateContratosLaboralesDTO>().ReverseMap();
            CreateMap<Ep,GenericDTO>().ReverseMap();
            CreateMap<Ep,CreateGenericDTO>().ReverseMap();
            CreateMap<FondosPensione,GenericDTO>().ReverseMap();
            CreateMap<FondosPensione,CreateGenericDTO>().ReverseMap();
            CreateMap<Servicio,ServiciosDTO>().ReverseMap();
            CreateMap<Servicio,CreateServicioDTO>().ReverseMap();
            CreateMap<TiposContrato,GenericDTO>().ReverseMap();
            CreateMap<TiposContrato,CreateGenericDTO>().ReverseMap();
            CreateMap<FileRecord,FileRecordDTO>().ReverseMap();
            CreateMap<FileRecord,CreateFileRecordDTO>().ReverseMap();
        }
    }
}
