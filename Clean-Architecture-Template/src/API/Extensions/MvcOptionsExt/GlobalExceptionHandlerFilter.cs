namespace API.Extensions.MvcOptionsExt;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions.Response;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class GlobalExceptionHandlerFilter : ExceptionFilterAttribute
{
    private readonly ILogger<GlobalExceptionHandlerFilter> _logger;
    private readonly IWebHostEnvironment _env;
    private int _statusCode = 500;
    private string _exceptionMessage = "Internal Server Error";
    private readonly List<Type> _doNotReport = new()
    {
        // typeof(NotFoundException)
    };

    public GlobalExceptionHandlerFilter(ILogger<GlobalExceptionHandlerFilter> logger, IWebHostEnvironment env)
    {
        _logger = logger;
        _env = env;
    }

    public override Task OnExceptionAsync(ExceptionContext context)
    {
        Render(context: context);
        return base.OnExceptionAsync(context: context);
    }

    public override void OnException(ExceptionContext context)
    {
        Render(context: context);
        base.OnException(context: context);
    }

    private void Render(ExceptionContext context)
    {
        if (_env.IsDevelopment())
            return;

        Exception catchException = context.Exception;
        string? exceptionCode = Logger(exception: catchException);

        if (catchException is BaseHttpException httpException)
        {
            _statusCode = httpException.Status;
            _exceptionMessage = catchException.InnerException?.Message ?? catchException.Message;
        }

        JsonResponse<object> _result = new()
        {
            Success = false,
            Result = null,
            Error = new ErrorModel
            {
                Message = _exceptionMessage,
                Code = exceptionCode
            }
        };

        context.HttpContext.Response.StatusCode = _statusCode;
        context.Result = new ObjectResult(_result);
    }

    // TODO: we need to separate logs by level and channels
    private string? Logger(Exception exception)
    {
        string? exceptionCode = null;

        Type exceptionType = exception.GetType();
        if (!_doNotReport.Any(type => type.IsAssignableFrom(exceptionType)))
        {
            exceptionCode = Guid.NewGuid().ToString();
            _logger.LogError(exception, "Code: {exceptionCode}", exceptionCode);
        }

        return exceptionCode;
    }
}
