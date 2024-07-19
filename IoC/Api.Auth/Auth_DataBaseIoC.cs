using Auth.Entities.Models;
using IoC.Global;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public class Auth_DataBaseIoC : DataBaseConect<SgeAuthContext>
    {
    }
}
