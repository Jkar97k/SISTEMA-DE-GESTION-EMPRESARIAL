using Admin.Entities.Modelos;
using Admin.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repositories.Repositories
{
    public class CecoRepository : Repository<Ceco>
    {
        public CecoRepository(SgeAdminContext context) : base(context)
        {
        }
    }
}
