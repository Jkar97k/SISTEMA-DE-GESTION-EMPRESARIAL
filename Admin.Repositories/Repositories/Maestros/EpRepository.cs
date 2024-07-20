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
    public class EpRepository : Repository<Ep, SgeAdminContext>, IEpRepository
    {
        public EpRepository(SgeAdminContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
