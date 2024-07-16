using Admin.Entities.Models;
using Admin.Interfaces;
using Admin.Repositories.Base;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repositories
{
    public class ContratosLaboraleRepository : Repository<ContratosLaborale>, IContratosLaboraleRepository
    {
        public ContratosLaboraleRepository(SgeAdminContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
