﻿using Admin.Entities.Modelos;
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
    public class CecoRepository : Repository<Ceco>, ICecoRepository
    {
        public CecoRepository(SgeAdminContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}