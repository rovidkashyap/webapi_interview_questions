using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace custom_ation_filter_in_web_api.Filters
{
    public class ExecutionTimeLoggerFilter : IActionFilter
    {
        private readonly ILogger<ExecutionTimeLoggerFilter> _logger;
        private Stopwatch _stopwatch;

        public ExecutionTimeLoggerFilter(ILogger<ExecutionTimeLoggerFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();

            var executionTime = _stopwatch.ElapsedMilliseconds;
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            _logger.LogInformation($"Action {controllerName}.{actionName} executed in {executionTime}ms ");
        }
    }
}
