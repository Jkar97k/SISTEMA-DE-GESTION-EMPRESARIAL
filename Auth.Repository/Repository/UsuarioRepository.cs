using Admin.Repositories.Base;
using Auth.Entities.Models;
using Auth.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SgeAuthContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
