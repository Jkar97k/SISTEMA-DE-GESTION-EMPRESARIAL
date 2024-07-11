﻿using Admin.Entities.Modelos;
using Admin.Interfaces;
using Admin.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repositories.Repositories.Maestros
{
    public class FondosPensionRepository : Repository<FondosPensione>, IFondosPensionRepository
    {
        public FondosPensionRepository(SgeAdminContext context) : base(context)
        {
        }
    }
}
