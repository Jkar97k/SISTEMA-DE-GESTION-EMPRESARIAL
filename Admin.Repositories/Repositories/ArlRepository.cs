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
    public class ArlRepository : Repository<Arl>, IArlRepository
    {
        public ArlRepository(SgeAdminContext context) : base(context)
        {
        }
    }
}
