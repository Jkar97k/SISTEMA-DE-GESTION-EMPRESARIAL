using Admin.Entities.Modelos;
using Admin.Interfaces.Repositories.Repositories;
using Admin.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repositories.Repositories.Maestros
{
    public class TiposContratoRepository : Repository<TiposContrato>, ITipoContratoRepository
    {
        public TiposContratoRepository(SgeAdminContext context) : base(context)
        {
        }
    }
}
