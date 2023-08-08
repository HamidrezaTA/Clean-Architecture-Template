namespace API.Extensions.MvcOptionsExt;

using API.Extensions.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ActionResultFilter : IActionFilter
{
    // TODO: using `is not` is not correct because sometimes we need to return other types like as file
    // TODO always response is successful
    // TODO set status code
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult objectResult)
        {
            if (objectResult.Value is not JsonResponse<object>)
            {
                ForceToJson(context: context, result: objectResult.Value);
            }
        }
        else if (context.Result is EmptyResult)
        {
            ForceToJson(context: context);
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {

    }

    private void ForceToJson(ActionExecutedContext context, object? result = null)
    {
        JsonResponse<object> response = new()
        {
            Success = true,
            Result = result
        };
        context.Result = new ObjectResult(response);
    }
}
