using Common.Log.Concrete;
using Common.Log.Contract;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Site.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext actionExecutedContext)
        {
            ILog _log = new Log();
            _log.LogError(actionExecutedContext.Exception);

            base.OnException(actionExecutedContext);
        }
    }
}