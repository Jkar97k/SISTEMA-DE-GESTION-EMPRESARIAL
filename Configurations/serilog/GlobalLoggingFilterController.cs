using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurations.serilog
{
    public class GlobalLoggingFilterController : IActionFilter
    {
        private readonly ILogger<GlobalLoggingFilterController> _logger;

        public GlobalLoggingFilterController(ILogger<GlobalLoggingFilterController> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var parameters = context.ActionArguments;

            _logger.LogInformation("Executing action: {ActionName} with parameters: {@Parameters}", actionName, parameters);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var result = context.Result;

            _logger.LogInformation("Action {ActionName} executed with result: {@Result}", actionName, result);
        }
    }
}
