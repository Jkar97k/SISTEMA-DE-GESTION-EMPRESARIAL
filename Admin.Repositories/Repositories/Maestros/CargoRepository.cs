using Admin.Entities.Models;
using Admin.Interfaces;
using Admin.Repositories.Base;
using AutoMapper;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repositories.Repositories.Maestros
{
    public class CargoRepository : Repository<Cargo, SgeAdminContext>, ICargoRepository
    {
        public CargoRepository(SgeAdminContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
