using Auth.Entities.Models;
using Auth.Interfaces;
using Auth.Repositories;
using AutoMapper;

namespace Auth.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SgeAuthContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
