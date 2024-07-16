using Admin.Entities.Models;
using Admin.Interfaces;
using Admin.Repositories.Base;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repositories.Repositories.Maestros
{
    public class FondosPensionRepository : Repository<FondosPensione>, IFondosPensionRepository
    {
        public FondosPensionRepository(SgeAdminContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
