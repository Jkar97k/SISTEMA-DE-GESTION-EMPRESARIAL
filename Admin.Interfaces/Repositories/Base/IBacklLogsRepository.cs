using Admin.Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Interfaces.Repositories.Base
{
    public interface IBacklLogsRepository : IRepository<BacklogsEvent, SgeAdminContext>
    {
    }
}
