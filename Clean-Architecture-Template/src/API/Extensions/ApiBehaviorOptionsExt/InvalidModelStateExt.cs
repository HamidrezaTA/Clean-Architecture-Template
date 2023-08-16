using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions.Response;
using Microsoft.AspNetCore.Mvc;

namespace API.Extensions.ApiBehaviorOptionsExt
{
    public static class InvalidModelStateExt
    {
        public static void AddCustomInvalidModelResponse(this ApiBehaviorOptions options)
        {
            options.InvalidModelStateResponseFactory = context =>
            {
                context.HttpContext.Response.StatusCode = 400;

                var _bulkMessages = new Dictionary<string, List<string>>();

                foreach (var entry in context.ModelState)
                {
                    var key = entry.Key;
                    var errors = entry.Value.Errors;

                    var errorMessages = errors.Select(e => e.ErrorMessage).ToList();
                    _bulkMessages[key] = errorMessages;
                }

                return new ObjectResult(new JsonResponse<object>
                {
                    Success = false,
                    Result = null,
                    Error = new ErrorModel
                    {
                        Message = "Validation Exception",
                        BulkMessages = _bulkMessages,
                        Code = Guid.NewGuid().ToString()
                    }
                });
            };
        }
    }
}