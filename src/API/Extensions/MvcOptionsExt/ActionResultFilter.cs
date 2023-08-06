using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Extensions.MvcOptionsExt
{
    public static class ActionResultOption
    {
        public static void AddActionResult(this MvcOptions options)
        {
            options.Filters.Add(typeof(ActionResultFilter));
        }
    }

    public class ActionResultFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ObjectResult objectResult)
            {
                if (!(objectResult.Value is ActionResultModel<object>))
                {
                    var result = new ActionResultModel<object>(true)
                    {
                        Result = objectResult.Value
                    };
                    context.Result = new ObjectResult(result);
                }
            }
            else if (context.Result is EmptyResult)
            {
                var result = new ActionResultModel<string>(true);
                context.Result = new ObjectResult(result);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }

    public class ActionResultModel<T>
    {
        public ActionResultModel(bool success = false)
        {
            Success = success;

            if (!success)
            {
                Error = new Error();
            }
        }

        public bool Success { get; set; }
        public T Result { get; set; }
        public Error Error { get; set; }
    }

    public class ActionResultModel : ActionResultModel<object>
    {

    }

    public class Error
    {
        public string Message { get; set; }
        public string Code { get; set; }
    }
}