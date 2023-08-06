using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Extensions.MvcOptionsExt
{
    public static class ActionExceptionHandlerOption
    {
        public static void AddExceptionHandler(this MvcOptions options)
        {
            options.Filters.Add(typeof(GlobalExceptionHandlerFilter));
        }
    }

    public class GlobalExceptionHandlerFilter : ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionHandlerFilter> _logger;
        readonly IWebHostEnvironment _env;

        public GlobalExceptionHandlerFilter(ILogger<GlobalExceptionHandlerFilter> logger,
            IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            Exception(context);
            return base.OnExceptionAsync(context);
        }

        void Exception(ExceptionContext context)
        {
            var _exception = context.Exception;
            var _message = _exception.InnerException?.Message ?? _exception.Message;

            if (_env.IsDevelopment())
                return;

            var _errorUniqueCode = Guid.NewGuid().ToString();
            var _result = new ActionResultModel();
            _result.Success = false;
            _result.Result = null;
            _result.Error = new Error();
            _result.Error.Code = _errorUniqueCode;

            if (_exception is CustomBaseException customException)
            {
                _logger.LogWarning(_exception, $"Message:{_message}, Code:{_errorUniqueCode}");
                _result.Error.Message = _message;
                context.HttpContext.Response.StatusCode = customException.Status;
            }
            else
            {
                _logger.LogError(_exception, $"Message:{_message}, Code:{_errorUniqueCode}");
                _result.Error.Message = "Internal Server Error";
                context.HttpContext.Response.StatusCode = 500;
            }

            context.Result = new ObjectResult(_result);
        }
    }
}