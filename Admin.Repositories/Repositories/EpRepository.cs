using Admin.Entities.Modelos;
using Admin.Interfaces.Repositories.Repositories;
using Admin.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repositories.Repositories
{
    public class EpRepository : Repository<Ep>,IEpRepository
    {
        public EpRepository(SgeAdminContext context) : base(context)
        {
        }
    }
}
