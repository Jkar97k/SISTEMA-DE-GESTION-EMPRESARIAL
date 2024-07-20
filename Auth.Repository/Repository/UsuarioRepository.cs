using Auth.Entities.Models;
using Auth.Interfaces;
using AutoMapper;
using Repository;

namespace Auth.Repository
{
    public class UsuarioRepository : Repository<Usuario , SgeAuthContext>, IUsuarioRepository
    {
        public UsuarioRepository(SgeAuthContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
