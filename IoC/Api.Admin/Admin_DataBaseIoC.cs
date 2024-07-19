using Admin.Entities.Models;
using IoC.Global;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC
{
    public class Admin_DataBaseIoC : DataBaseConect<SgeAdminContext>
    {
    }
}
