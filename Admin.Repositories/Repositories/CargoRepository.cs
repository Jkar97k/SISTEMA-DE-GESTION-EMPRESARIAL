using Admin.Entities.Modelos;
using Admin.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repositories.Repositories
{
    public class CargoRepository : Repository<Cargo>
    {
        public CargoRepository(SgeAdminContext context) : base(context)
        {
        }
    }
}
