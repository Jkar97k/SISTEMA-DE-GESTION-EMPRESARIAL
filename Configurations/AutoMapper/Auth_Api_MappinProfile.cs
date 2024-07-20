using Auth.DTO;
using Auth.Entities.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurations.AutoMapper
{
    public class Auth_Api_MappinProfile : Profile
    {
        public Auth_Api_MappinProfile() 
        {
            CreateMap<Usuario,UsuarioDTO>().ReverseMap();
            CreateMap<Usuario,CreateUsuarioDTO>().ReverseMap();
        }
    }
}
