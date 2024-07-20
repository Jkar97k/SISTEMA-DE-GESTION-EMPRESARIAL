using Admin.Entities.Models;
using Admin.Interfaces;
using Admin.Interfaces.Repositories.Base;
using AutoMapper;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Repositories.Base
{
    public class BackLogsEventRepository : Repository<BacklogsEvent, SgeAdminContext>, IBacklLogsRepository
    {
        public BackLogsEventRepository(SgeAdminContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
